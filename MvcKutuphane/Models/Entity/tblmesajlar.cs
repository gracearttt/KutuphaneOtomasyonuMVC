//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblmesajlar
    {
        public int id { get; set; }
        public string gonderen { get; set; }
        public string alici { get; set; }
        public string konu { get; set; }
        public string icerik { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
    }
}
