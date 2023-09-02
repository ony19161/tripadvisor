using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Dto.Response
{
    public class ApiResponse<T> where T : class
    {
        public T Data { get; set; }
    }
}
