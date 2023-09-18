using BackEndCubos.Application.DTOs;
using BackEndCubos.Application.Interfaces;
using BackEndCubos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BackEndCubos.OPENAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IApplicationServicePerson applicationServicePerson;
        public PersonController(IApplicationServicePerson applicationServicePerson)
        {
            this.applicationServicePerson = applicationServicePerson;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            try
            {
                if (person == null)
                    return BadRequest();

                applicationServicePerson.Add(person);

                PersonDTO responseDTO = new PersonDTO
                {
                    Id = person.Id,
                    Name = person.Name,
                    Document = person.Document,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("account")]
        public ActionResult PostAccount(Guid peopleId, [FromBody] PersonAccount account)
        {
            try
            {
                if (peopleId == Guid.Empty || account == null)
                    return BadRequest();

                applicationServicePerson.PostAccount(peopleId, account);

                PersonAccountDTO responseDTO = new PersonAccountDTO
                {
                    Id = account.Id,
                    Branch = account.Branch,
                    Account = account.Account,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAccounts")]
        public ActionResult GetAccounts(Guid peopleId)
        {
            try
            {
                if (peopleId == Guid.Empty)
                    return BadRequest();

                var accounts = applicationServicePerson.GetAccounts(peopleId);
                var accountsDTO = new List<PersonAccountDTO>();
                foreach (var account in accounts)
                {
                    PersonAccountDTO responseDTO = new PersonAccountDTO
                    {
                        Id = account.Id,
                        Branch = account.Branch,
                        Account = account.Account,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };

                    accountsDTO.Add(responseDTO);
                }

                return Ok(accountsDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
