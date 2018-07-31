using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;




namespace WebAPI.Controllers
{
    public class MasterController : ApiController
    {
        static MasterRepository repository = new MasterRepository();

        [Authorize]
        [RequiredHTTPS]
        [System.Web.Http.AcceptVerbs("POST", "GET")]
        [HttpPost]
        [ActionName("AddPatientData")]
        public string AddPatientData(PatientData P)
        {
            //calling EmpRepository Class Method and storing Repsonse   
            var response = repository.Add_Patient(P);
            return response;
        }


        [Authorize]
        [RequiredHTTPS]
        [HttpGet]
        [ActionName("GetPatientData")]
        public IEnumerable<PatientData> GetPatientData(string s)
        {


            var users = repository.GetPatientData(s);
            return users;
        }

        [Authorize]
        [RequiredHTTPS]
        [System.Web.Http.AcceptVerbs("POST", "GET")]
        [HttpPost]
        [ActionName("UpdatePatientData")]
        public string UpdatePatientData(PatientData P)
        {
            //calling EmpRepository Class Method and storing Repsonse   
            var response = repository.Update_Patient(P);
            return response;
        }


    }
}
