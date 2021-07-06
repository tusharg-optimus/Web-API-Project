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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRole()
        {
            try
            {

                _roleService.SaveChanges();
                return Ok(await _roleService.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
           
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            try
            {
                var role = await _roleService.GetById(id);

                if (role == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _roleService.SaveChanges();

                return role;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
           
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleDTO roleDto)
        {
            try
            {
                if (id != roleDto.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                var result = await _roleService.GetById(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

               _roleService.Update(id,roleDto);

                _roleService.SaveChanges();

                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data");
            }
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoleDTO>> PostRole(RoleDTO roleDto)
        {
            try
            {
                await _roleService.Add(roleDto);
                _roleService.SaveChanges();

                return CreatedAtAction("GetRole", new { id = roleDto.Id }, roleDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var role = await _roleService.GetById(id);
                if (role == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _roleService.Delete(id);

                _roleService.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {

                 return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        //private bool RoleExists(int id)
        //{
        //    return _context.Role.Any(e => e.Id == id);
        //}
    }
}
