using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;



using TranDinhHiep_5951071028_Buoi4Phan1.Models;

namespace TranDinhHiep_5951071028_Buoi4Phan1.Models
{
    public class db
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NOA56JL\\SQLEXPRESS;Initial Catalog=DemoCRUD.;Integrated Security=True");

        //Select
        public DataSet Empget(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp Employee", con); 
                com.CommandType = CommandType.StoredProcedure; 
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no); 
                com.Parameters.AddWithValue("@Emp_name", emp.Emp_name); 
                com.Parameters.AddWithValue("@City", emp.City); 
                com.Parameters.AddWithValue("@STATE", emp.State); 
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter da = new SqlDataAdapter(com); 
                da.Fill(ds); 
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }

        //insert and update
        public String Empdml(Employee emp, out string msg)
        {
            msg = "";
            try
            {
                SqlCommand command = new SqlCommand("Sp Employee", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                command.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                command.Parameters.AddWithValue("@City", emp.City);
                command.Parameters.AddWithValue("@STATE", emp.State);
                command.Parameters.AddWithValue("@Country", emp.Country);
                command.Parameters.AddWithValue("@Department", emp.Department);
                command.Parameters.AddWithValue("@flag", emp.flag);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = ex.Message;
                return msg;
            }
        }
    }
}
