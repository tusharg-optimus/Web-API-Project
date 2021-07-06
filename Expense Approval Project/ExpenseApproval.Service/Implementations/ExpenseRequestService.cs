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
    public class ExpenseRequestService : IExpenseRequestService
    {
        //Injecting Dependencies.
        private readonly IExpenseRequestRepository _expenseRequestRepository;
        private readonly IMapper _mapper;

        public ExpenseRequestService(IExpenseRequestRepository expenseRequestRepository, IMapper mapper)
        {
            _expenseRequestRepository = expenseRequestRepository;
            _mapper = mapper;
        }
        public async Task<ExpenseRequestDTO> Add(ExpenseRequestDTO obj)
        {
            var expesne = _mapper.Map<ExpenseRequest>(obj);
            var result = await _expenseRequestRepository.Add(expesne);
            var expenseDto = _mapper.Map<ExpenseRequestDTO>(result);
            return expenseDto;
        }

        public void Delete(int id)
        {
            _expenseRequestRepository.Delete(id);

        }

        public async Task<IEnumerable<ExpenseRequestDTO>> GetAll()
        {
            List<ExpenseRequestDTO> listExpenseDto = new List<ExpenseRequestDTO>();
            var result = await _expenseRequestRepository.GetAll();
            foreach (var item in result)
            {
                var expenseDto = _mapper.Map<ExpenseRequestDTO>(item);
                listExpenseDto.Add(expenseDto);
            }
            return listExpenseDto;
        }

        public async Task<ExpenseRequestDTO> GetById(int id)
        {
           var result = await _expenseRequestRepository.GetById(id);
            var expenseDto = _mapper.Map<ExpenseRequestDTO>(result);
            return expenseDto;
        }

        public void SaveChanges()
        {
            _expenseRequestRepository.SaveChanges();
        }

        public void Update(int id, ExpenseRequestDTO obj)
        {
            var expense = _mapper.Map<ExpenseRequest>(obj);
            _expenseRequestRepository.Update(id, expense);
            
        }
    }
}
