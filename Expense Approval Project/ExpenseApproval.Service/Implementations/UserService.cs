using AutoMapper;
using ExpenseApproval.DataAccess.Entity;
using ExpenseApproval.DataAccess.Repository.Interfaces;
using ExpenseApproval.Service.Interfaces;
using ExpenseApproval.Utility.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.Service.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
           _mapper = mapper;
        }
        public async Task<UserDTO> Add(UserDTO obj)
        {
            var user = _mapper.Map<User>(obj);
            var result = await _userRepository.Add(user);
            var userDto = _mapper.Map<UserDTO>(result);
            return userDto;
            
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            List<UserDTO> listuserDto = new List<UserDTO>();
            var result = await _userRepository.GetAll();
            foreach (var item in result)
            {
                var userDto = _mapper.Map<UserDTO>(item);
                listuserDto.Add(userDto);
            }

            return listuserDto;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var result = await _userRepository.GetById(id);
            var userDto = _mapper.Map<UserDTO>(result);
            return userDto;
        }

        public void SaveChanges()
        {
            _userRepository.SaveChanges();
        }

        public void Update(int id, UserDTO obj)
        {
            var user = _mapper.Map<User>(obj);
            _userRepository.Update(id, user);
        }
    }
}
