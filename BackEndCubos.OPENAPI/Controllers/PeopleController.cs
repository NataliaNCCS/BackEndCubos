using BackEndCubos.Domain.Core.DTOs;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCubos.OPENAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class PeopleController : Controller
    {
        private readonly IServicePerson servicePerson;
        private readonly IServicePersonAccount servicePersonAccount;
        private readonly IServiceCard serviceCard;
        public PeopleController(IServicePerson servicePerson, IServicePersonAccount servicePersonAccount, IServiceCard serviceCard)
        {
            this.servicePerson = servicePerson;
            this.servicePersonAccount = servicePersonAccount;
            this.serviceCard = serviceCard;
        }

        [HttpPost("people")]
        public ActionResult Post([FromBody] Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var personResponse = servicePerson.CreatePerson(person);

                return Ok(personResponse);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }

        [HttpPost("people/{peopleId}/accounts")]
        public ActionResult PostAccount(Guid peopleId, [FromBody] PersonAccount account)
        {
            try
            {
                if (peopleId == Guid.Empty || !ModelState.IsValid)
                    return BadRequest();

                var accountResponse = servicePersonAccount.CreateAccount(peopleId, account);

                return Ok(accountResponse);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }

        [HttpGet("people/{peopleId}/accounts")]
        public ActionResult GetAccounts(Guid peopleId)
        {
            try
            {
                if (peopleId == Guid.Empty || !ModelState.IsValid)
                    return BadRequest();

                var accounts = servicePersonAccount.GetAccounts(peopleId);

                return Ok(accounts);

            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }

        [HttpGet("people/{peopleId}/cards")]
        public ActionResult GetCards(Guid peopleId, [FromQuery] Pagination pagination)
        {
            try
            {
                if (peopleId == Guid.Empty || !ModelState.IsValid)
                    return BadRequest();

                var cards = serviceCard.GetCardsByPerson(peopleId, pagination);

                return Ok(cards);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(message);
            }
        }
    }
}
