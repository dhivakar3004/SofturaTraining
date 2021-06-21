using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DepartmentTask.Models
{
    public class DeptModel
    {

        public DataTable GetDepartment()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS;database=AdventureWorks2019;integrated security=true");
            SqlCommand cmd = new SqlCommand("Select departmentId,name from humanresources.Department",con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;

        }

    }
}