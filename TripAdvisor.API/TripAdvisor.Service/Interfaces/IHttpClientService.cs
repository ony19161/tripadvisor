using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Service.Interfaces
{
    public interface IHttpClientService
    {
        Task<T> SendGetRequest<T>(string queryParams);
    }
}
