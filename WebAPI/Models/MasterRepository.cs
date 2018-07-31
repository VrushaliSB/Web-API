using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI.Models
{
    public class MasterRepository
    {

        private SqlConnection con;
        private SqlCommand com;


        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }

        public IEnumerable<PatientData> GetPatientData(string s)
        {


            connection();
            com = new SqlCommand("SP_Display_Patient", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("SerialNo", s);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToString(row["SerialNo"]) == "" || Convert.ToString(row["SerialNo"]) == null || Convert.ToString(row["SerialNo"]) == "null")
                    {
                        yield return new PatientData
                        {
                            InMsg = "Serial no. " + Convert.ToString(row["Str"]) + " not found."
                        };
                    }
                    else
                    {
                        yield return new PatientData
                        {
                            PFirstName = Convert.ToString(row["PFirstName"]),
                            PLastName = Convert.ToString(row["PLastName"]),
                            PMiddleName = Convert.ToString(row["PMiddleName"]),
                            PSuffix = Convert.ToString(row["PSuffix"]),
                            AddLn1 = Convert.ToString(row["AddLn1"]),
                            AddLn2 = Convert.ToString(row["AddLn2"]),
                            City = Convert.ToString(row["City"]),
                            State = Convert.ToString(row["State"]),
                            Zip = Convert.ToString(row["Zip"]),
                            PhysName = Convert.ToString(row["PhysName"]),
                            PhysLocation = Convert.ToString(row["PhysLocation"]),
                            SerialNo = Convert.ToString(row["SerialNo"]),
                            Active = Convert.ToString(row["Active"]),
                            ID = Convert.ToInt32(row["ID"]),
                            PPhNo = Convert.ToString(row["PPhNo"]),
                            PEmail = Convert.ToString(row["PEmail"]),
                            PHeredityQue = Convert.ToString(row["PHeredityQue"]),
                            PhysEmail = Convert.ToString(row["PhysEmail"]),
                            PhysTypedName = Convert.ToString(row["PhysTypedName"]),
                            PDOB = Convert.ToString(row["PDOB"]),
                            DTSubmit = Convert.ToString(row["DTSubmit"]),
                            CreateBy = Convert.ToString(row["CreateBy"]),
                            CreatedDate = Convert.ToString(row["CreatedDate"]),
                            UpdatedBy = Convert.ToString(row["UpdatedBy"]),
                            UpdatedDate = Convert.ToString(row["UpdatedDate"]),


                            InMsg = "Serial no. " + Convert.ToString(row["SerialNo"]) + " is found."
                        };
                    }
                }
            }
        }

        public string Add_Patient(PatientData cs)

        {
            connection();


            com = new SqlCommand("SP_Add_Patient", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("PFirstName", cs.PFirstName);
            com.Parameters.AddWithValue("PLastName", cs.PLastName);

            com.Parameters.AddWithValue("PMiddleName", cs.PMiddleName);

            com.Parameters.AddWithValue("PSuffix", cs.PSuffix);

            com.Parameters.AddWithValue("AddLn1", cs.AddLn1);

            com.Parameters.AddWithValue("AddLn2", cs.AddLn2);
            com.Parameters.AddWithValue("City", cs.City);
            com.Parameters.AddWithValue("State", cs.State);
            com.Parameters.AddWithValue("Zip", cs.Zip);
            com.Parameters.AddWithValue("PhysName", cs.PhysName);
            com.Parameters.AddWithValue("PhysLocation", cs.PhysLocation);
            com.Parameters.AddWithValue("SerialNo", cs.SerialNo);

            com.Parameters.AddWithValue("PPhNo", cs.PPhNo);
            com.Parameters.AddWithValue("PEmail", cs.PEmail);
            com.Parameters.AddWithValue("PHeredityQue", cs.PHeredityQue);
            com.Parameters.AddWithValue("PhysEmail", cs.PhysEmail);
            com.Parameters.AddWithValue("PhysTypedName", cs.PhysTypedName);
            com.Parameters.AddWithValue("PDOB", cs.PDOB);
            com.Parameters.AddWithValue("DTSubmit", cs.DTSubmit);



            con.Open();

            int i = com.ExecuteNonQuery();

            con.Close();
            if (i >= 1)
            {
                return "Record added for Serial No " + cs.SerialNo;
            }
            else
            {
                return "Serial No " + cs.SerialNo + " already exists.";
            }
        }

        public string Update_Patient(PatientData cs)
        {
            connection();


            com = new SqlCommand("SP_Update_Patient", con);

            com.CommandType = CommandType.StoredProcedure;


            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("SerialNo", cs.SerialNo);
            com.Parameters.AddWithValue("PhysTypedName", cs.PhysTypedName);
            com.Parameters.AddWithValue("DTSubmit", cs.DTSubmit);



            con.Open();

            int i = com.ExecuteNonQuery();

            con.Close();
            if (i >= 1)
            {
                return "Record updated for Serial No " + cs.SerialNo;
            }
            else
            {
                return "Serial No " + cs.SerialNo + " not exists.";
            }
        }

    }
}