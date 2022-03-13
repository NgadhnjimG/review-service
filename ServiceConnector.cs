using ReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReviewService
{
    public class ServiceConnector
    {
    
        public async Task<string> GetUserByID(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:30225/api/...");
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;

        }
    }
}
