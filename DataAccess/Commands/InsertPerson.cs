using DataAccess.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commands
{
    public static class InsertPerson
    {
        public record Command(string FirstName, string LastName) : IRequest<Person>;

        public class Handler : IRequestHandler<Command, Person>
        {
            private IDataAccess _dataAccess;
            private IMediator _mediator;
            public Handler(IDataAccess dataAccess, IMediator mediator)
            {
                _dataAccess = dataAccess;
                _mediator = mediator;
            }

            public async Task<Person> Handle(Command request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(_dataAccess.InsertPerson(request.FirstName, request.LastName));
            }
        }
    }
}
