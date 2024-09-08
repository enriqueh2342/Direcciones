using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Direcciones.Models
{
    [Table("BuildVersion")]
    public class BuildVersion
    {
        [Key]
        public int SystemInformationID { get; set; }

        [Column("Data Version")]
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}