using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace ExploreDb
{
    class Program
    {   //Exception 
        //Avoid Abortion-Abruptly stopping of an application

        public void InsertBooks()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            ////SqlCommand cmd = new SqlCommand("Insert into  tbl_Books values('The 5 Am club',4,450)", con);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "Insert into tbl_Books values('Two States',1,650)";
            //cmd.Connection = con;
            string qry = "insert into tbl_Books values(@Title,@authorID,@Price)";
            SqlCommand cmd = new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("@Title", "Davinci Code");
            cmd.Parameters.AddWithValue("@authorID", 7);
            cmd.Parameters.AddWithValue("@Price", 600);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Server Not Working");
            }
            finally
            {
                con.Close();
            }
        }
        public string StoredProcedureInsertBook(string title, int aid, double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_InsertBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Title",SqlDbType.NVarChar).Value=title;
            //cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            //cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@Title";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Value = title;
            cmd.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@AuthorID";
            p2.SqlDbType = SqlDbType.Int;
            p2.Value = aid;
            cmd.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@Price";
            p3.SqlDbType = SqlDbType.Money;
            p3.Value = price;
            cmd.Parameters.Add(p3);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public void UpdateBooks()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            //SqlCommand cmd = new SqlCommand("update into  tbl_Books values('The 5 Am club',4,4450) where BookId=1009 ", con);
           //SqlCommand cmd = new SqlCommand("UPDATE tbl_Books SET Price = 4450  where BookId=1009 ", con);
            SqlCommand cmd = new SqlCommand("UPDATE tbl_Books SET Price = 9450  where BookId=1008 ", con);

            con.Open();
            cmd.ExecuteReader();
            con.Close();

        }
        public string StoredProcedureUpdateBook(int id, string title, int aid, double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_UpdateBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookId", SqlDbType.Int).Value = id;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            con.Open();
            //cmd.ExecuteNonQuery();
            cmd.ExecuteReader();
            con.Close();
            res = "success";
            return res;
        }
        public void DeleteBooks()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Books WHERE BookId = 1019 ", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();

        }
        public string StoredProcedureDeleteBook(int id)
        {
            string res = null;
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_DeleteBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookId", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            res = "success";
            return res;
        }

      
            public void InsertAuthor()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("Insert into  tbl_author values('Jayakanthan')", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        public string StoredProcedureInsertAuthor(string authorName)
        {
            string res = null;
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_InsertAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;            
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.VarChar).Value = authorName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "success";
            return res;


        }
            public void UpdateAuthor()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("UPDATE tbl_author SET AuthorName = 'Jayakanthan D'  where AuthorId=8", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        public string StoredProcedureUpdateAuthor(int id, string AuthorName)
        {
            string res = null;
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_UpdateAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorId", SqlDbType.Int).Value = id;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = AuthorName;            
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            res = "success";
            return res;
        }
        public void DeleteAuthor()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl_author WHERE AuthorId = 8 ", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();

        }
        public string StoredProcedureDeleteAuthor(int id)
        {
            string res = null;
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_DeleteAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorId", SqlDbType.Int).Value = id;            
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            res = "success";
            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.InsertBooks();
            //program.UpdateBooks();
            //program.StoredProcedureInsertBook("Fantastic Beasts and Where to Find Them", 3, 480);
            //program.StoredProcedureInsertBook("Shivagamiyin", 2, 430);
            //program.DeleteBooks();
            //program.InsertAuthor();
            //program.UpdateAuthor();
            //program.DeleteAuthor();
            //program.StoredProcedureUpdateBook(1003,"Deception .", 7, 5070);
            //program.StoredProcedureUpdateAuthor(1, "Chetan Bhagat CB");
            //program.StoredProcedureInsertAuthor("Rajam Krishnan");
            //program.StoredProcedureDeleteAuthor(11);
            program.StoredProcedureDeleteBook(1018);
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("Select * from tbl_Books", con);
            //SqlCommand cmd = new SqlCommand("Select * from tbl_author", con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())

                Console.WriteLine(rdr["BooKId"] + " "+ rdr["Title"]+ " " +rdr["Price"].ToString());
                //Console.WriteLine(rdr["AuthorId"] + " " + rdr["AuthorName"].ToString());
            con.Close();
            Console.ReadLine();
        }
    }
}
