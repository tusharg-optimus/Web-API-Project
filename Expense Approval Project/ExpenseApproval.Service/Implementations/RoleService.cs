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
    public class RoleService : IRoleService
    {
        //Injecting Dependency
        private readonly IRoleRepository _roleRepository; 
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<RoleDTO> Add(RoleDTO obj)
        {
            var role = _mapper.Map<Role>(obj);

            var result = await _roleRepository.Add(role);

            var roleDto = _mapper.Map<RoleDTO>(result);
            return roleDto;
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

        public async Task<IEnumerable<RoleDTO>> GetAll()
        {
            List<RoleDTO> roleDTOs = new List<RoleDTO>();
            var result = await _roleRepository.GetAll();
            foreach (var item in result)
            {
                var roleDto = _mapper.Map<RoleDTO>(item);
                roleDTOs.Add(roleDto);

            }
            return roleDTOs;
        }

        public async Task<RoleDTO> GetById(int id)
        {
            var result = await _roleRepository.GetById(id);
            var roleDto = _mapper.Map<RoleDTO>(result);
            return roleDto;
        }

        public void SaveChanges()
        {
            _roleRepository.SaveChanges();
        }

        public void Update(int id,RoleDTO obj)
        {
            //Map roleDTO to Role

            var role = _mapper.Map<Role>(obj);

            _roleRepository.Update(id, role);
        }
    }
}
