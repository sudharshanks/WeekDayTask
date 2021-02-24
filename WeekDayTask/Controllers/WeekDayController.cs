using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeekDayTask.Models;

namespace WeekDayTask.Controllers
{
    public class WeekDayController : ApiController
    {  
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="param">Optional parameter</param>
        /// <returns>
        /// Returns an array of objects for seven days starting with the current day with each containing
        /// string property - array index + day of week (i.e. "0. Tuesday", "1. Wednesday", "2. Thursday")
        /// bool property - true if URL parameter was specified
        /// date property - set to current time + array index for additional days (as follows)
        /// current time (current time today)
        /// current time + 1 day (same time tomorrow) 
        /// </returns>
        // GET: api/WeekDay/5
        [HttpGet]
        public Response Get(int id = 0)
        {
            var outputArray = new Response();
            outputArray.WeekDaysList = new List<string>();
            outputArray.WeekDayTimesList = new List<string>();
            PopulateReponse(outputArray);
            if(id > 0){
                outputArray.paramPresent = true;
            }
            return outputArray;
        }

        // POST: api/WeekDay
        [HttpPost]
        public Response Post([FromBody]RequestedDates request)
        {
            //Request request = JsonConvert.DeserializeObject<Request>(value);
            var outputArray = new Response();
            outputArray.WeekDaysList = new List<string>();
            outputArray.WeekDayTimesList = new List<string>();
            PopulateReponse2(request, outputArray);
            return outputArray;
        }

        // DELETE: api/WeekDay/5
        public void Delete(int id)
        {
        }

        private void PopulateReponse(Response response)
        {
            var dateObj = DateTime.Now;
            for (int i = 0; i < 7; i++)
            {
                response.WeekDaysList.Add(i+". " + dateObj.DayOfWeek.ToString());
                response.WeekDayTimesList.Add(dateObj.AddDays(i).ToString());
                dateObj = dateObj.AddDays(1);
            }
        }

        private void PopulateReponse2(RequestedDates request, Response response)
        {
           
            for (int i = 0; i < 7; i++)
            {
                var dateObj = request.InputDates[i];
                response.WeekDaysList.Add(i + ". " + dateObj.DayOfWeek.ToString());
                response.WeekDayTimesList.Add(dateObj.ToString());
            }
        }
    }
}
