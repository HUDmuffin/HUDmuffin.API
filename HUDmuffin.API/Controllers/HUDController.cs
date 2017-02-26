using HUDmuffin.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace HUDmuffin.API.Controllers
{
    public class HUDController : ApiController
    {

        [OutputCache(Duration = 86400, VaryByParam = "none")]
        public IHttpActionResult Get(string message)
        {
            string calBinaryContent = "empty";
            if (!string.IsNullOrEmpty(message))
                if (!string.IsNullOrEmpty(message))
                {
                    switch (message.ToLower())
                    {
                        case "welcome":
                            calBinaryContent = "welcome_default";
                            break;
                        case "february":
                            calBinaryContent = "feb2017";
                            break;
                        case "december":
                        default:
                            calBinaryContent = "welcome_default";
                            break;
                    }

                }
                else
                    calBinaryContent = "welcome_default";


            HUDCalmodel model = new HUDCalmodel();
            model.image = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/app_data/" + calBinaryContent + ".txt"));
            model.ReceivedOn = DateTime.Now.ToString();
            model.RecievedBy = "JohnDoe@HUDmuffin.com";
            model.status = HttpStatusCode.OK.ToString();

            return Ok<HUDCalmodel>(model);
        }
    }
}
