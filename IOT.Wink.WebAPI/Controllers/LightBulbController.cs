using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IOT.Wink.WebAPI.Controllers
{
    public class LightBulbController : ApiController
    {
        public async Task<string> GetLightBuldById(string id)
        {
            var baseAddress = new Uri("https://api.wink.com/light_bulb/" + id);

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                using (var response = await httpClient.GetAsync("undefined"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
            }
        }
    }
}
