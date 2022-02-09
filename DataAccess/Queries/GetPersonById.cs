using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class GetPersonById
    {
        public record Query(int Id) : IRequest<Person>;

        public class Handler : IRequestHandler<Query, Person>
        {
            private IDataAccess _dataAccess;
            private IMediator _mediator;
            public Handler(IDataAccess dataAccess, IMediator mediator)
            {
                _dataAccess = dataAccess;
                _mediator = mediator;
            }

            public async Task<Person> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await _mediator.Send(new GetPersons.Query());
                return results.FirstOrDefault(x=>x.Id == request.Id);
            }
        }
    }
}
