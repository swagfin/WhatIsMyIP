using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WhatIsMyIP.Models;

namespace WhatIsMyIP.Controllers
{
    [Route("/")]
    [Route("/api/[controller]")]
    public class IpController : ControllerBase
    {
        public async Task<IpLookupInfo> Index(int lookup = 0)
        {
            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var response = new IpLookupInfo(ipAddress);
            if (lookup == 0)
                return response;
            //Query External Info
            return await QueryIPInformationAsync(ipAddress);
        }


        private async Task<IpLookupInfo> QueryIPInformationAsync(string ipAddress)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ipAddress))
                    throw new Exception("Ip Address was not Provided");
                //Proceeed
                string url = $"http://ipinfo.io/{ipAddress}/json";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(5);
                //End of Headers
                var response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(content))
                    throw new Exception("Response returned was empty");
                return JsonConvert.DeserializeObject<IpLookupInfo>(content);
            }
            catch (Exception)
            {
                return null;
            }


        }
    }

}
