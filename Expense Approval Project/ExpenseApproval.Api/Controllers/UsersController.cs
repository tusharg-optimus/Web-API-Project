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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUser()
        {
            try
            {
                _userService.SaveChanges();
                return Ok(await _userService.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
            
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetById(id);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                _userService.SaveChanges();

                return user;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
            
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO userDto)
        {
            try
            {
                if (id != userDto.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                var result = await _userService.GetById(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _userService.Update(id, userDto);

                _userService.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data");
            }

            
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
        {
            try
            {
                await _userService.Add(userDto);
                _userService.SaveChanges();

                return CreatedAtAction("GetUser", new { id = userDto.Id }, userDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.GetById(id);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                _userService.Delete(id);
                _userService.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }

        
    }
}
