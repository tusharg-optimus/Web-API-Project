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
    public class ApprovalService : IApprovalService
    {
        private readonly IApprovalRepository _approvalRepository;
        private readonly IMapper _mapper;
       

        public ApprovalService(IApprovalRepository approvalRepository, IMapper mapper)
        {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }
        public async Task<ApprovalDTO> Add(ApprovalDTO obj)
        {
            var approval = _mapper.Map<Approval>(obj);
            var result = await _approvalRepository.Add(approval) ;
            var approvalDto = _mapper.Map<ApprovalDTO>(result);
            return approvalDto;
        }

        public void Delete(int id)
        {
            _approvalRepository.Delete(id);
        }

        public async Task<IEnumerable<ApprovalDTO>> GetAll()
        {
            List<ApprovalDTO> listApprovalDto = new List<ApprovalDTO>();
            var result = await _approvalRepository.GetAll();
            foreach (var item in result)
            {
                var approvalDto = _mapper.Map<ApprovalDTO>(item);

                listApprovalDto.Add(approvalDto);
               
            }

            return listApprovalDto;
        }
        
        public async Task<ApprovalDTO> GetById(int id)
        {
            
            var result = await _approvalRepository.GetById(id);
            var approvalDto = _mapper.Map<ApprovalDTO>(result);
            return approvalDto;
        }

        public void SaveChanges()
        {
            _approvalRepository.SaveChanges();
        }

        public void Update(int id, ApprovalDTO obj)
        {
            var approval = _mapper.Map<Approval>(obj);
            _approvalRepository.Update(id, approval);
        }
    }
}
