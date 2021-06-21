using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MVCwithADO2.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("select BookId,Title,AuthorName,Price from tbl_Books tb join tbl_author ta on tb.AuthorID = ta.AuthorID", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewBook(string Title,int Aid,Double Price)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@AuthorID", Aid);
            cmd.Parameters.AddWithValue("@Price", Price);
            return cmd.ExecuteNonQuery();
        }
        public DataTable DisplayAuthor()
        {
            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("select AuthorID,AuthorName from tbl_author", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            con.Close();
            return data;
        }
        public DataTable BookbyId(int bookid)
        {
            DataTable datatable = new DataTable();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Books where bookid=" + bookid, con);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
            dataadapter.Fill(datatable);
            con.Close();
            return datatable;
        }

        public int UpdateBook(int Bid,string Title,int Aid,double Price)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            con.Open();
            string sqlqry = "Update tbl_Books set Title=@title, AuthorID=@aid,Price=@price where BookId=@bid";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@aid", Aid);
            cmd.Parameters.AddWithValue("@price", Price);
            cmd.Parameters.AddWithValue("@bid", Bid);
            return cmd.ExecuteNonQuery();


        }
        public int DeleteBook(int bookid)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from tbl_Books where bookid=@bkid",con);
            cmd.Parameters.AddWithValue("@bkid",bookid);
            return cmd.ExecuteNonQuery();
        }
        
        public DataTable ViewAuthorJoin()
        {
            CRUDModel model = new CRUDModel();
            DataTable datatable = new DataTable();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("select BookId,Title,AuthorName,Price from tbl_Books tb join tbl_author ta on tb.AuthorID = ta.AuthorID", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(datatable);
            con.Close();
            return datatable;
        }

        public int NewBookAuthorIdName(string Title, string aname, double Price)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS;database=BooksDB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into tbl_Books values(@Title,(select AuthorID from tbl_author where AuthorName=@AuthorName),@Price)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@AuthorName", aname);
            cmd.Parameters.AddWithValue("@Price", Price);
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public int NewBookAuthorIdNameSecMethod(string Title, string aname, double Price)
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-874O3SVO\\SQLEXPRESS;database=BooksDB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Books(Title,AuthorID,Price) values(@Title, @AuthorID, @Price)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@AuthorID", SelectAuthorByID(aname));
            cmd.Parameters.AddWithValue("@Price", Price);
            return cmd.ExecuteNonQuery();
            con.Close();
        }



        public int SelectAuthorByID(string aname)
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-874O3SVO\\SQLEXPRESS;database=BooksDB;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select AuthorID from tbl_author where AuthorName=@authorName", con);
            cmd.Parameters.AddWithValue("@authorName", aname);
            string c = cmd.ExecuteScalar().ToString();
            con.Close();
            return Convert.ToInt32(c);
        }
    }
}