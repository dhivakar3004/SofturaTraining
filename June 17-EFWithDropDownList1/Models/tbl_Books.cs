//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFWithDropDownList1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Books
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Nullable<int> AuthorID { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
