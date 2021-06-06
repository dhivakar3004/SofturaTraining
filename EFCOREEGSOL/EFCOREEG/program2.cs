using EFCOREEG.pubs;
using System;
using System.Linq;

namespace EFCOREEG
{
    class Program2
    {
        public static pubsContext db = new pubsContext();
       public static TblMovie e = new TblMovie();
        static void Main(string[] args)
        {
            //TblMovie emp = AcceptData();
            //InsertData(emp);
            //Console.WriteLine("Record added Successfully");
            //SelectDataMethod();
            Console.WriteLine("Enter the Id to delete the movie");
            int id = Convert.ToInt32(Console.ReadLine());
            DeleteData(id);
            Console.WriteLine("The movie is deleted");
        }
        private static void SelectDataMethod()
        {
            pubsContext db = new pubsContext();
            var result = db.TblMovies.ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " " + item.Duration);
                Console.WriteLine("_____________________________________");
            }
        }
        private static GetProductById(int id)
        {
            using (var db = new EFContext())
            {
                e = db.Products.Find(id);
            }
            return e;
        }
        private static void UpdateMovie(int id)
        {
            using (var db = new EFContext())
            {
                p = GetProductById(id);
                Console.WriteLine(p.ToString());
                p = AcceptDetails();
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private static void InsertData(TblMovie em)
        {
            db.TblMovies.Add(em);
            db.SaveChanges();
        }
        private static TblMovie AcceptData()
        {
            Console.WriteLine("Enter Name,Duration");
            TblMovie e = new TblMovie();           
            e.Name = Console.ReadLine();
            e.Duration = Convert.ToDouble(Console.ReadLine());
            return e;
        }
        private static void DeleteData(int id)
        {
            e = db.TblMovies.Find(id);
            if(e==null)
            {
                Console.WriteLine("No movie is found ");
            }
            else
            {
                db.TblMovies.Remove(e);
                db.SaveChanges();
                Console.WriteLine("The movie is Deleted Succesfully");
            }
        }
    }
}

