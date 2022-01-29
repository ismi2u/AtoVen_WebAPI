﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AtoVen_WebAPI.Model;

namespace AtoVen_WebAPI.Models
{
    public class CompInformation
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CompanyIDPK { get; set; }

        public string CompanyName { get; set; }

        public string CommResidenceNo { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNo { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string POBox { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Website { get; set; }
        public string VendorType { get; set; }
        public string AccountGroup { get; set; }
        public string Notes { get; set; }
        public string VatNo { get; set; }
        public List<ContactInformation> _lstcontactInformation { get; set; }

        public List<BankInformation> BankInformation { get; set; }

    }

   
}
