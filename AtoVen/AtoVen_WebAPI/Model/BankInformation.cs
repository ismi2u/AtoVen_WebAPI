using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AtoVen_WebAPI.Models;

namespace AtoVen_WebAPI.Model
{
    public class BankInformation
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BankIDPK { get; set; }

        [ForeignKey("CompanyID")]
        public virtual CompInformation CompInformation { get; set; }
        public int CompanyID { get; set; }
        public string Country { get; set; }
        public string BankKey { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string BankAccount { get; set; }
        public string AccountHolder { get; set; }
        public string IBAN { get; set; }
        public string Currency { get; set; }
    }
}
