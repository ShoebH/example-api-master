using ExampleDomain.Models;
using MediatR;

namespace ExampleApplication.Requests.Commands
{
    public class ExampleCommand : IRequest<RequestResult<Example>>
    {
        public string Value { get; set; }
    }
}
