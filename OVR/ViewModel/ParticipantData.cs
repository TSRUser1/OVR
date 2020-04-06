using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.DataClass
{
    class ParticipantData
    {
        public int ParticipantID { get; set; }

        public string AccreditationNumber { get; set; }
        public string FullName { get; set; }
        public string FamilyName { get; set; }
        public string GenderID { get; set; }
        public string CountryID { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public string ModifiedBy { get; set; }
        public string GivenName { get; set; }
        public string IPCNo { get; set; }
        public string CardPhotoPath { get; set; }

        public string CardPhotoPathThumbnail { get; set; }

        public string CardPhotoPathExternal { get; set; }

        public int ExternalParticipantID { get; set; }
    }
}
