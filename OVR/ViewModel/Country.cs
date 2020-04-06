using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.DataClass
{
    public class Country
    {
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public string SportCode { get; set; }

        public string IconFilePath { get; set; }

        public string IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime  ModifiedDateTime { get; set; }

        public string  ModifiedBy { get; set; }
    }
}
