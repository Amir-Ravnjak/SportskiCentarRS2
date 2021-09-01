using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.HelperModels
{
    public class Result
    {
        internal Result(bool succeeded, string title, IEnumerable<string> errors, string successMessage = null)
        {
            Succeeded = succeeded;
            SuccessMessage = successMessage;
            if(!string.IsNullOrEmpty(title))
                Errors = new Dictionary<string, string[]>() { { title, errors.ToArray() } };
        }
        internal Result(Dictionary<string,string[]> errors)
        {
            Succeeded = false;
            Errors = errors;
        }
        public bool Succeeded { get; set; }

        public Dictionary<string,string[]> Errors { get; set; }
        public string SuccessMessage { get; set; }

        public static Result Success(string successMessage = null)
        {
            return new Result(true, string.Empty, Array.Empty<string>(), successMessage);
        }

        public static Result Failure(string title, IEnumerable<string> errors)
        {
            return new Result(false, title, errors);
        }
        public static Result Failure(Dictionary<string,string[]> errors)
        {
            return new Result(errors);
        }
    }
}
