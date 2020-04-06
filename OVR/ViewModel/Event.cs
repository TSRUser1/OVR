using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.DataClass
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventCode { get; set; }
        public int SportID { get; set; }
        public int GenderID { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }
    }
}
