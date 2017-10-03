using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace IOT.Philips.WebAPI.Models
{
    public class Helper
    {
        public void CallAPI(string url,string methodName,object param)
        {
            using (WebClient client = new WebClient())
            {
                client.BaseAddress = url;
                //client.
            }
            
        }
    }
}