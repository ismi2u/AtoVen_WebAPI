using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AtoVen_WebAPI.Models;


namespace AtoVen_WebAPI.Model
{
    public class ContactInformation
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ContactIDPK { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompInformation CompInformation { get; set; }
        public int CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FormofAdress { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
    }
}
