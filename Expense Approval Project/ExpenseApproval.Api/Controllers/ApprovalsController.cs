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
    public class ApprovalsController : ControllerBase
    {
        private readonly IApprovalService _approvalService;

        public ApprovalsController(IApprovalService approvalService)
        {
            _approvalService = approvalService;
        }

        // GET: api/Approvals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApprovalDTO>>> GetApproval()
        {
            try
            {
                return Ok(await _approvalService.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
           
        }

        // GET: api/Approvals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApprovalDTO>> GetApproval(int id)
        {
            try
            {
                var approval = await _approvalService.GetById(id);

                if (approval == null)
                {
                    return NotFound();
                }

                _approvalService.SaveChanges();
                return approval;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }

            
        }

        // PUT: api/Approvals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApproval(int id, ApprovalDTO approvalDto)
        {
            try
            {
                if (id != approvalDto.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var result = await _approvalService.GetById(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _approvalService.Update(id, approvalDto);
                _approvalService.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data");
            }

           
        }

        // POST: api/Approvals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApprovalDTO>> PostApproval(ApprovalDTO approvalDto)
        {
            try
            {
                await _approvalService.Add(approvalDto);
                _approvalService.SaveChanges();

                return CreatedAtAction("GetApproval", new { id = approvalDto.Id }, approvalDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }

        // DELETE: api/Approvals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApproval(int id)
        {
            try
            {
                var approval = await _approvalService.GetById(id);
                if (approval == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _approvalService.Delete(id);
                _approvalService.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }

        
    }
}
