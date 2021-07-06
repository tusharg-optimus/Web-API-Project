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
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceDTO> Add(InvoiceDTO obj)
        {
            var invoice = _mapper.Map<Invoice>(obj);
            var result = await _invoiceRepository.Add(invoice);
            var invoiceDto = _mapper.Map<InvoiceDTO>(result);
            return invoiceDto;
        }

        public void Delete(int id)
        {
            _invoiceRepository.Delete(id);
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAll()
        {
            List<InvoiceDTO> listInvoiceDto = new List<InvoiceDTO>();
            var result = await _invoiceRepository.GetAll();
            foreach (var item in result)
            {
                var invoiceDto = _mapper.Map<InvoiceDTO>(item);
                listInvoiceDto.Add(invoiceDto);
            }
            return listInvoiceDto;
        }

        public async Task<InvoiceDTO> GetById(int id)
        {
            var result = await _invoiceRepository.GetById(id);
            var invoiceDto = _mapper.Map<InvoiceDTO>(result);
            return invoiceDto;
        }

        public void SaveChanges()
        {
            _invoiceRepository.SaveChanges();
        }

        public void Update(int id, InvoiceDTO obj)
        {
            var invoice = _mapper.Map<Invoice>(obj);
            _invoiceRepository.Update(id, invoice);
        }
    }
}
