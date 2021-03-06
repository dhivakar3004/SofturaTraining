//using System.Runtime.InteropServices;

//// In SDK-style projects such as this one, several assembly attributes that were historically
//// defined in this file are now automatically added during build and populated with
//// values defined in project properties. For details of which attributes are included
//// and how to customise this process see: https://aka.ms/assembly-info-properties


//// Setting ComVisible to false makes the types in this assembly not visible to COM
//// components.  If you need to access a type in this assembly from COM, set the ComVisible
//// attribute to true on that type.

//[assembly: ComVisible(false)]

//// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("7ccfbab7-4584-48ce-89b4-567a8055358e")]
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaClient.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        public string Name { get; set; }
        public String Speciality { get; set; }
        [Display (Name="Veg")]
        public bool Isveg { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
    }
}


