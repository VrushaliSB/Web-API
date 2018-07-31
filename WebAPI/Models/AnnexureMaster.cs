using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PatientData
    {
        public string PFirstName { get; set; }
        public string PLastName { get; set; }
        public string PMiddleName { get; set; }
        public string PSuffix { get; set; }
        public string AddLn1 { get; set; }
        public string AddLn2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PPhNo { get; set; }
        public string PDOB { get; set; }
        public string PEmail { get; set; }
        public string PHeredityQue { get; set; }
        public string PhysName { get; set; }
        public string PhysLocation { get; set; }
        public string PhysEmail { get; set; }
        public string PhysTypedName { get; set; }
        public string DTSubmit { get; set; }
        public string SerialNo { get; set; }
        public int ID { get; set; }
        public string Active { get; set; }

        public string CreateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string InMsg { get; set; }





    }
}