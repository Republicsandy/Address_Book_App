using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly IContactRl contactBl;
        public AddressController(IContactRl contactBl)
        {
            this.contactBl = contactBl;
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult AddContact(PhoneBook contactModel)
        {
            try
            {

                var result = contactBl.AddContact(contactModel);
                if (result != null)
                {
                    return Ok(new { sucess = true, message = "contact Created Successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "contact Created Unsuccessful" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("View")]
        public IActionResult ViewContact(long ContactId)
        {
            try
            {
                List<PhoneBook> result = contactBl.ViewContact(ContactId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = " Contact Display Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Contact not Available" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateContact(PhoneBook contactModel, long ContactId)
        {
            try
            {
                var result = contactBl.UpdateContact(contactModel, ContactId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Contact Updated Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "No Contact Found" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteContact(long ContactId)
        {
            try
            {
                var delete = contactBl.DeleteContact(ContactId);
                if (delete != null)
                {
                    return this.Ok(new { Success = true, message = "Contact Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Contact Deleted Unsuccessful" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
