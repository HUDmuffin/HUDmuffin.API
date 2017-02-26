using HUDmuffin.API.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace HUDmuffin.API.Controllers
{
    public class CalendarController : ApiController
    {
        // GET: api/Calendar
        //[Route("Calendar")]
        [OutputCache(Duration = 86400, VaryByParam = "none")]
        [ResponseType(typeof(HUDCalmodel))]
        public IHttpActionResult Get(string id, string month)
        {
            string calBinaryContent1 = "empty";
            string calBinaryContent2 = "empty";
            if (!string.IsNullOrEmpty(id))
                if (id == "101")
                {
                    if(!string.IsNullOrEmpty(month))
                    {
                        switch (month.ToLower())
                        {
                            case "january":
                                calBinaryContent1 = "mar2017";
                                calBinaryContent2 = "mar2017";
                                break;
                            case "february":
                                calBinaryContent1 = "feb2017";
                                calBinaryContent2 = "mar2017";
                                break;
                            case "march":
                                calBinaryContent1 = "feb2017";
                                calBinaryContent2 = "mar2017";
                                break;
                            case "december":
                            default:
                                calBinaryContent1 = "binarycal1";
                                calBinaryContent2 = "binarycal1";
                                break;
                        }

                    }
                    else
                    {
                        calBinaryContent1 = "binarycal1";
                        calBinaryContent2 = "binarycal1";
                    }
                }
                else
                {
                    calBinaryContent1 = "binarycal2";
                    calBinaryContent2 = "binarycal2";
                }

            HUDCalmodel model = new HUDCalmodel();
            model.image1 = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/app_data/"+ calBinaryContent1+ ".txt"));
            model.image2 = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/app_data/" + calBinaryContent2 + ".txt"));
            model.ReceivedOn = DateTime.Now.ToString();
            model.RecievedBy = "JohnDoe@HUDmuffin.com";
            model.status = HttpStatusCode.OK.ToString();

            //var result = new JsonResult();
            //result.Data = model;
            //result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //return result;
            return Ok<HUDCalmodel>(model);
        }

      
    }
}
