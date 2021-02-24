using System.Collections.Generic;

namespace WeekDayTask.Models
{
    public class Response
    {
        public List<string> WeekDaysList { get; set; }
        public List<string> WeekDayTimesList { get; set; }
        public bool paramPresent { get; set; }
    }
}