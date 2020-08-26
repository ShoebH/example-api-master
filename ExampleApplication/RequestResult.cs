using ExampleDomain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExampleApplication
{
    public class RequestResult<T> : RequestResult
    {
        public T Payload { get; set; }
    }

    public class RequestResult
    {
        private List<Error> _errors;
        public IEnumerable<Error> Errors => _errors;

        public bool HasErrors => Errors?.Any() ?? false;

        public void AddError(Error error)
        {
            if (_errors == null)
                _errors = new List<Error>();

            _errors.Add(error);
        }

        public void AddError(string code, string reason)
        {
            if (_errors == null)
                _errors = new List<Error>();

            _errors.Add(new Error { Code = code, Reason = reason});
        }
    }
}
