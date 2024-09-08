using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Direcciones.Models
{
    [Table("Address", Schema = "SalesLT")]
    public class Address
    {
        public int AddressID { get; set; }
        [Display(Name = "Dirección 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Dirección 2")]
        public string AddressLine2 { get; set; }
        [Display(Name = "Ciudad")]
        public string City { get; set; }
        [Display(Name = "Estado o Provincia")]
        public string StateProvince { get; set; }
        [Display(Name = "País o Región")]
        public string CountryRegion { get; set; }
        [Display(Name = "Código Postal")]
        public string PostalCode { get; set; }
        public Guid rowguid { get; set; }
        [Display(Name = "Fecha de Modificación")]
        public DateTime ModifiedDate { get; set; }
    }
}