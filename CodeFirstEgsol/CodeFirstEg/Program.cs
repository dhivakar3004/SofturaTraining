using Microsoft.EntityFrameworkCore;
using System;

namespace CodeFirstEg
{
    class Program
    {
        public static EFContext db = new EFContext();
        public static Product p = new Product();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            p = AcceptDetails();
            AddProduct(p);
            //Console.WriteLine("Enter the id to delete");
            //int id = Convert.ToInt32(Console.ReadLine());
            //DeleteProduct(id);
            //Console.WriteLine("Enter the ID To be update");
            //int id = Convert.ToInt32(Console.ReadLine());
            //UpdateProduct(id);
            DisplayProducts();
        }
        private static Product GetProductById(int id)
        {
            using (var db = new EFContext())
            {
                p = db.Products.Find(id);
            }
            return p;         
         }

        private static void UpdateProduct(int id)
        {
            using (var db=new EFContext())
            {
                p = GetProductById(id);
                Console.WriteLine(p.ToString());
                p=AcceptDetails();
                db.Entry(p).State =EntityState.Modified;
                db.SaveChanges();
            }
        }
        private static void DisplayProducts()
        {
            foreach (var item in db.Products)
            {
                Console.WriteLine(item.pId+" "+item.pName+" "+ item.Price+" "+item.Qty);
            }
        }
        private static void AddProduct(Product p1)
        {
            db.Products.Add(p1);
            db.SaveChanges();
            Console.WriteLine("Record added successfully");
        }
        private static Product AcceptDetails()
        {
            Console.WriteLine("Enter product name,Price and qty");
            p.pName = Console.ReadLine();
            p.Price = Convert.ToInt32(Console.ReadLine());
            p.Qty= Convert.ToInt32(Console.ReadLine());
            return p;
        }
        //private static Product AcceptDeleteDetails()
        //{
        //    Console.WriteLine("Enter product Id");
        //    a= Convert.ToInt32(Console.ReadLine());           
        //    return a;
        //}
        //private static void DeleteProduct(int p1)
        //{
        //    db.Products.Remove(p1);
        //    db.SaveChanges();
        //    Console.WriteLine("Record Removed successfully");
        //}
        private static void DeleteProduct(int id)
        {
            var e = db.Products.Find(id);
            if (e == null)
            {
                Console.WriteLine("No such products existed");
            }
            else
            {
                db.Products.Remove(e);
                db.SaveChanges();
                Console.WriteLine("Deleted products");
            }
        }
    }
}
