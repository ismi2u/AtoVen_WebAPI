using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtoVen_WebAPI.Data;
using AtoVen_WebAPI.Models;
using AtoVen_WebAPI.Model;

namespace AtoVen_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompInformationsController : ControllerBase
    {
        private readonly AtoVen_WebAPIContext _context;

        public CompInformationsController(AtoVen_WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/CompInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompInformation>>> GetCompInformation()
        {
            return await _context.CompInformation.ToListAsync();
        }

        // GET: api/CompInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompInformation>> GetCompInformation(int id)
        {
            var compInformation = await _context.CompInformation.FindAsync(id);

            if (compInformation == null)
            {
                return NotFound();
            }

            return compInformation;
        }

        // PUT: api/CompInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompInformation(int id, CompInformation compInformation)
        {
            if (id != compInformation.CompanyIDPK)
            {
                return BadRequest();
            }

            _context.Entry(compInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CompInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCompInformation(CompInformation compInformation)
        {
            CompInformation _objcompInformation = new CompInformation();

            _objcompInformation.AccountGroup = compInformation.AccountGroup;
            _objcompInformation.Building = compInformation.Building;
            _objcompInformation.City = compInformation.City;
            _objcompInformation.CommResidenceNo = compInformation.CommResidenceNo;
            _objcompInformation.CompanyName = compInformation.CompanyName;
            _objcompInformation.Country = compInformation.Country;
            _objcompInformation.District = compInformation.District;
            _objcompInformation.Email = compInformation.Email;
            _objcompInformation.FaxNumber = compInformation.FaxNumber;
            _objcompInformation.Floor = compInformation.Floor;
            _objcompInformation.HouseNo = compInformation.HouseNo;
            _objcompInformation.Language = compInformation.Language;
            _objcompInformation.MobileNo = compInformation.MobileNo;
            _objcompInformation.Notes = compInformation.Notes;
            _objcompInformation.PhoneNo = compInformation.PhoneNo;
            _objcompInformation.POBox = compInformation.POBox;
            _objcompInformation.PostalCode = compInformation.PostalCode;
            _objcompInformation.Region = compInformation.Region;
            _objcompInformation.Room = compInformation.Room;
            _objcompInformation.Street = compInformation.Street;
            _objcompInformation.VatNo = compInformation.VatNo;
            _objcompInformation.VendorType = compInformation.VendorType;
            _objcompInformation.Website = compInformation.Website;
            _context.CompInformation.Add(_objcompInformation);

            await _context.SaveChangesAsync();


            foreach (ContactInformation contactInformation in compInformation._lstcontactInformation)
            {
                ContactInformation contact = new ContactInformation
                {
                    CompanyID = _objcompInformation.CompanyIDPK,
                    Country = contactInformation.Country,
                    Email = contactInformation.Email,
                    FaxNo = contactInformation.FaxNo,
                    Language = contactInformation.Language,
                    PhoneNo = contactInformation.PhoneNo,
                    Department = contactInformation.Department,
                    FirstName = contactInformation.FirstName,
                    FormofAdress = contactInformation.FormofAdress,
                    LastName = contactInformation.LastName,
                    Position = contactInformation.Position
                };
                _context.ContactInformation.Add(contact);
            }


            foreach (BankInformation bankInformation in compInformation.BankInformation)
            {
                BankInformation bank = new BankInformation
                {
                    CompanyID = _objcompInformation.CompanyIDPK,
                    AccountHolder = bankInformation.AccountHolder,
                    BankAccount = bankInformation.BankAccount,
                    Country = bankInformation.Country,
                    BankKey = bankInformation.BankKey,
                    BankName = bankInformation.BankName,
                    Currency = bankInformation.Currency,
                    IBAN = bankInformation.IBAN,
                    SwiftCode = bankInformation.SwiftCode

                };

                _context.BankInformation.Add(bank);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompInformation", new { id = _objcompInformation.CompanyIDPK }, compInformation);
          
        }

        // DELETE: api/CompInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompInformation(int id)
        {
            var compInformation = await _context.CompInformation.FindAsync(id);
            if (compInformation == null)
            {
                return NotFound();
            }

            _context.CompInformation.Remove(compInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompInformationExists(int id)
        {
            return _context.CompInformation.Any(e => e.CompanyIDPK == id);
        }
    }
}
