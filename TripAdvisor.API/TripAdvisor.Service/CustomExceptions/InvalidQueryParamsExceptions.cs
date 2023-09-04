using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Service.CustomExceptions
{
    public class InvalidQueryParamsExceptions : Exception
    {
        public InvalidQueryParamsExceptions(string message) : base(message)
        {

        }
    }
}
