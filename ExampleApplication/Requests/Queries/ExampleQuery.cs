using ExampleDomain.Models;
using MediatR;

namespace ExampleApplication.Requests.Queries
{
    public class ExampleQuery : IRequest<RequestResult<Example>>
    {
        public string Value { get; set; }
    }
}
