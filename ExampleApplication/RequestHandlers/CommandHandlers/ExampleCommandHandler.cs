using ExampleApplication.Requests.Commands;
using ExampleDomain.Models;
using ExampleDomain.Repositories;
using ExampleDomain.Services.Clients;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleApplication.RequestHandlers.CommandHandlers
{
    public class ExampleCommandHandler : IRequestHandler<ExampleCommand, RequestResult<Example>>
    {
        private readonly IExampleRepository _exampleRepository;
        private readonly IExampleClient _exampleClient;

        public ExampleCommandHandler(IExampleRepository characterRepository, IExampleClient exampleClient)
        {
            _exampleRepository = characterRepository;
            _exampleClient = exampleClient;
        }

        public async Task<RequestResult<Example>> Handle(ExampleCommand request, CancellationToken cancellationToken)
        {
            var result = new RequestResult<Example>();

            var exampleResponse = await _exampleClient.GetExampleFromExternalResource(request.Value);
            if (exampleResponse == null)
            {
                result.AddError(new Error { Code = "EXAMPLE_CODE", Reason = "Response from external example call was null" });
                result.AddError("EXAMPLE_CODE", "Response from external example call was null");
                return result;
            }

            result.Payload = await _exampleRepository.InsertExample(exampleResponse.Value);

            return result;
        }
    }
}
