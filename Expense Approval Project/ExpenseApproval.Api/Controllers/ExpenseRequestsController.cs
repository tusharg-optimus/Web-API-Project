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
    public class ExpenseRequestsController : ControllerBase
    {
        private readonly IExpenseRequestService _expenseRequestService;

        public ExpenseRequestsController(IExpenseRequestService expenseRequestService)
        {
            _expenseRequestService = expenseRequestService;
        }

        // GET: api/ExpenseRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseRequestDTO>>> GetExpenseRequest()
        {
            try
            {
                return Ok(await _expenseRequestService.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
            
        }

        // GET: api/ExpenseRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseRequestDTO>> GetExpenseRequest(int id)
        {
            try
            {
                var expenseRequest = await _expenseRequestService.GetById(id);

                if (expenseRequest == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _expenseRequestService.SaveChanges();

                return expenseRequest;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
           
        }

        // PUT: api/ExpenseRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseRequest(int id, ExpenseRequestDTO expenseRequestDto)
        {
            try
            {
                if (id != expenseRequestDto.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var result = await _expenseRequestService.GetById(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _expenseRequestService.Update(id, expenseRequestDto);
                _expenseRequestService.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data");
            }

            
        }

        // POST: api/ExpenseRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpenseRequestDTO>> PostExpenseRequest(ExpenseRequestDTO expenseRequestDto)
        {
            try
            {
                await _expenseRequestService.Add(expenseRequestDto);
                _expenseRequestService.SaveChanges();

                return CreatedAtAction("GetExpenseRequest", new { id = expenseRequestDto.Id }, expenseRequestDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        // DELETE: api/ExpenseRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseRequest(int id)
        {
            try
            {
                var expenseRequest = await _expenseRequestService.GetById(id);
                if (expenseRequest == null)
                {
                    return NotFound();
                }

                _expenseRequestService.Delete(id);
                _expenseRequestService.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            
        }

        //private bool ExpenseRequestExists(int id)
        //{
        //    return _context.ExpenseRequest.Any(e => e.Id == id);
        //}
    }
}
