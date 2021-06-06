
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CARAPI.Models

{
    public class Car
    {
        public int CarNumber { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
        public Car()
        {

        }
        public Car(int carno,string model,string brand,float price)
        {
            CarNumber = carno;
            Model = model;
            Brand = brand;
            Price = price;
        }
        public static List<Car> cars = new List<Car>();
        public List<Car> GetCars()
        {
            cars.Add(new Car(1789, "Amaze", "Honda", 4890393));
            cars.Add(new Car(1563, "Getz", "Hyundai", 4890393));
            cars.Add(new Car(1023, "Ertiga", "Maruthi", 4890393));
            cars.Add(new Car(1876, "Vento", "Vols", 4890393));
            cars.Add(new Car(1812, "Tavera", "Honda", 4890393));
            return cars;
        }
        public void  AddCar(Car c)
        {
            cars.Add(c);
        }
        public void Deletecar(int id)

        {
            Car c = (from i in GetCars()
                     where i.CarNumber == id
                     select i).FirstOrDefault();
            cars.Remove(c);
        }
    }
}
