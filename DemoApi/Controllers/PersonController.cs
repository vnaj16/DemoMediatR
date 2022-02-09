using DataAccess;
using DataAccess.Commands;
using DataAccess.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await _mediator.Send(new GetPersons.Query());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _mediator.Send(new GetPersonById.Query(id));
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<Person> Post([FromBody] Person value)
        {
            var model = new InsertPerson.Command(value.FirstName, value.LastName);
            return await _mediator.Send(model);
        }
    }
}
