using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class GetPersons
    {
        public record Query() : IRequest<List<Person>>;
        public class Handler : IRequestHandler<Query, List<Person>>
        {
            private IDataAccess _dataAccess;
            public Handler(IDataAccess dataAccess)
            {
                _dataAccess = dataAccess;
            }
            public Task<List<Person>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_dataAccess.GetPeople());
            }
        }

        //Instead of List<Person> I could create a class response to this
    }
}
