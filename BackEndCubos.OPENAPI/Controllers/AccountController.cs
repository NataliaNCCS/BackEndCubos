using BackEndCubos.Domain.Core.DTOs;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BackEndCubos.OPENAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class AccountController : Controller
    {
        private readonly IServicePersonAccount servicePersonAccount;
        private readonly IServiceTransaction serviceTransaction;
        private readonly IServiceCard serviceCard;

        public AccountController(IServicePersonAccount servicePersonAccount, IServiceTransaction serviceTransaction, IServiceCard serviceCard)
        {
            this.servicePersonAccount = servicePersonAccount; this.serviceTransaction = serviceTransaction;
            this.serviceTransaction = serviceTransaction;
            this.serviceCard = serviceCard;
        }

        [HttpPost("accounts/{accountId}/cards")]
        public ActionResult PostCard(Guid accountId, [FromBody] Card card)
        {
            try
            {
                if (accountId == Guid.Empty || !ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    return BadRequest(errors);
                }

                if (card.Type == Domain.Utils.Enums.CardType.Physical && serviceCard.AlreadyHasPhysicalCard(accountId))
                    return BadRequest("Essa conta já possui um cartão físico.");

                var responseCard = serviceCard.CreateCard(accountId, card);

                return Ok(responseCard);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }

        [HttpPost("accounts/{accountId}/transactions")]
        public ActionResult PostTransaction(Guid accountId, [FromBody] Transaction transaction)
        {
            try
            {
                if (accountId == Guid.Empty || !ModelState.IsValid)
                    return BadRequest();

                var responseTransaction = serviceTransaction.CreateTransaction(accountId, transaction);

                if(responseTransaction.Description == "Falha")
                    return BadRequest("Valor inválido");

                return Ok(responseTransaction);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }

        [HttpGet("accounts/{accountId}/cards")]
        public ActionResult GetCards(Guid accountId)
        {
            try
            {
                if (accountId == Guid.Empty || !ModelState.IsValid)
                    return BadRequest();

                var cards = servicePersonAccount.GetCards(accountId);

                return Ok(cards);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }

        [HttpGet("accounts/{accountId}/transactions")]
        public ActionResult GetTransactions(Guid accountId, [FromQuery] Pagination pagination, [FromQuery] string? startDate, [FromQuery] string? endDate)
        {
            try
            {
                if (accountId == Guid.Empty || !ModelState.IsValid)
                    return BadRequest();


                if (pagination.ItemsPerPage <= 0 || pagination.CurrentPage <= 0)
                {
                    pagination.ItemsPerPage = 100;
                    pagination.CurrentPage = 1;
                }

                if (startDate is not null
                     && !DateTime.TryParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    return BadRequest("Formato de data de início inválido");


                if (endDate is not null
                    && !DateTime.TryParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    return BadRequest("Formato de data final inválido");

                if (startDate is null)
                    startDate = "01/01/0001 00:00:00";


                if (endDate == null ||
                   (endDate.Substring(0, 2).PadLeft(2, '0') == DateTime.Now.Day.ToString().PadLeft(2, '0') &&
                    endDate.Substring(3, 2).PadLeft(2, '0') == DateTime.Now.Month.ToString().PadLeft(2, '0') &&
                    endDate.Substring(6, 4) == DateTime.Now.Year.ToString()))
                {
                    endDate = "31/12/9999 23:59:59.9999999";
                }

                var transactions = serviceTransaction.GetTransactions(accountId, pagination, startDate, endDate);

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }

        [HttpGet("accounts/{accountId}/balance")]
        public ActionResult GetBalance(Guid accountId)
        {
            try
            {
                if (accountId == Guid.Empty || !ModelState.IsValid)
                    return BadRequest();

                var balance = servicePersonAccount.GetBalance(accountId);

                return Ok(balance);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }

        [HttpPost("accounts/{accountId}/transactions/{transactionId}/revert")]
        public ActionResult ReverTransaction(Guid accountId, Guid transactionId)
        {
            try
            {
                if (accountId == Guid.Empty || transactionId == Guid.Empty)
                    return BadRequest();

                var revertedTransaction = serviceTransaction.RevertTransaction(accountId, transactionId);

                return Ok(revertedTransaction);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }
    }
}
