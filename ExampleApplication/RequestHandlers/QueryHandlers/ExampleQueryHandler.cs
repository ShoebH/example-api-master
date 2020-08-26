using ExampleApplication.Requests.Queries;
using ExampleDomain.Models;
using ExampleDomain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleApplication.RequestHandlers.QueryHandlers
{
    internal class ExampleQueryHandler : IRequestHandler<ExampleQuery, RequestResult<Example>>
    {
        private readonly IExampleRepository _exampleRepository;

        public ExampleQueryHandler(IExampleRepository characterRepository)
        {
            _exampleRepository = characterRepository;
        }

        public async Task<RequestResult<Example>> Handle(ExampleQuery request, CancellationToken cancellationToken)
        {
            var result = new RequestResult<Example>();

            result.Payload = await _exampleRepository.FetchExample(request.Value);

            return result;
        }
    }
}
