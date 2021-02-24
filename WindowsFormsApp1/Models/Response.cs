using System.Collections.Generic;

namespace WindowsFormsApp1.Models
{
    public class Response
    {
        public List<string> WeekDaysList { get; set; }
        public List<string> WeekDayTimesList { get; set; }
        public bool paramPresent { get; set; }
    }
}
