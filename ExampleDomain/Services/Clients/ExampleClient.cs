using ExampleDomain.Models;
using System.Threading.Tasks;

namespace ExampleDomain.Services.Clients
{
    public interface IExampleClient
    {
        Task<Example> GetExampleFromExternalResource(string exampleValue);
    }

    public class ExampleClient : IExampleClient
    {
        public async Task<Example> GetExampleFromExternalResource(string exampleValue)
        {
            //DO EXTERNAL WORK HERE
            //IE, HTTP CALL TO DIFFERENT RESOURCE
            return new Example { Value = exampleValue };
        }
    }
}
