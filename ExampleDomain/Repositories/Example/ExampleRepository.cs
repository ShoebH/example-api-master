using ExampleDomain.Models;
using System.Threading.Tasks;

namespace ExampleDomain.Repositories
{
    public interface IExampleRepository
    {
        Task<Example> FetchExample(string exampleValue);
        Task<Example> InsertExample(string exampleValue);
        Task<Example> UpdateExample(Example exampleValue);
        Task DeleteExample(Example exampleValue);
    }

    public class ExampleRepository : IExampleRepository
    {
        public async Task<Example> FetchExample(string exampleValue)
        {
            //FETCH FROM DATABASE
            return new Example { Value = exampleValue };
        }

        public async Task<Example> InsertExample(string exampleValue)
        {
            //INSERT INTO DATABASE
            return new Example { Value = exampleValue };
        }

        public async Task<Example> UpdateExample(Example exampleValue)
        {
            //UPDATE IN DATABASE
            return exampleValue;
        }

        public async Task DeleteExample(Example exampleValue)
        {
            //DELETE FROM DATABASE
            return;
        }
    }
}
