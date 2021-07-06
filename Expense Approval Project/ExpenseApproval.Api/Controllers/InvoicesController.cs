using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseApproval.DataAccess;
using ExpenseApproval.DataAccess.Entity;
using ExpenseApproval.Service.Interfaces;
using ExpenseApproval.Utility.DTOs;

namespace ExpenseApproval.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetInvoice()
        {
            try
            {
                return Ok(await _invoiceService.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
            
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDTO>> GetInvoice(int id)
        {
            try
            {
                var invoice = await _invoiceService.GetById(id);

                if (invoice == null)
                {
                    return NotFound();
                }

                _invoiceService.SaveChanges();

                return invoice;
            }
            catch (Exception)
            {

               return  StatusCode(StatusCodes.Status404NotFound);
            }

            
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, InvoiceDTO invoiceDto)
        {
            try
            {
                if (id != invoiceDto.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var result = await _invoiceService.GetById(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _invoiceService.Update(id, invoiceDto);
                _invoiceService.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data");
            }

            
        }

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceDTO>> PostInvoice(InvoiceDTO invoiceDto)
        {
            try
            {
                await _invoiceService.Add(invoiceDto);
                _invoiceService.SaveChanges();

                return CreatedAtAction("GetInvoice", new { id = invoiceDto.Id }, invoiceDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            try
            {
                var invoice = await _invoiceService.GetById(id);
                if (invoice == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _invoiceService.Delete(id);
                _invoiceService.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

           
        }

        
    }
}
