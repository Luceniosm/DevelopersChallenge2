using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Application.Interface;
using Aplicacao.Domain.Interface.Service;
using Aplicacao.Domain.Models;
using Aplicacao.Domain.Uow;
using Aplicacao.DTO;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Aplicacao.Application.Service
{
    public class ExtractService : BaseAppService, IExtractService
    {
        private readonly ILogger<ExtractService> _logger;
        private readonly IMapper _mapper;
        private readonly IDataBankRepository _dataBankRepository;
        private readonly ITransactionRepository _transactionRepository;
        public ExtractService(
            IUnitOfWork uow, 
            IMapper mapper,
            ILogger<ExtractService> logger,
            IDataBankRepository dataBankRepository,             
            ITransactionRepository transactionRepository) : base(uow)
        {
            _mapper = mapper;
            _dataBankRepository = dataBankRepository;
            _logger = logger;
            _transactionRepository = transactionRepository;
        }

        public async Task<List<DataBankDto>> GetAccount()
        {
            var dataBank = await _dataBankRepository.GetAllAccount();
            return _mapper.Map<List<DataBankDto>>(dataBank);
        }

        public async Task<List<TransactionDto>> GetExtractsByIdDataBank(Guid idDataBank)
        {
            var transactions = await _transactionRepository.GetExtractsByIdDataBank(idDataBank);
            return _mapper.Map<List<TransactionDto>>(transactions);
        }

        public async Task<bool> SaveExtract(List<DataBankDto> dataBanks)
        {
            foreach (var dataInsert in dataBanks.Select(dataBank => new DataBank(
                dataBank.Id,
                dataBank.Account,
                dataBank.CodeBank,
                GetTransactions(dataBank.Transactions)
            )))
            {
                var existAccount = await _dataBankRepository.GetByIdAccount(dataInsert.Account);
                if(existAccount != null)
                {
                    existAccount.AddRangeTransactions(dataInsert.Transactions);
                    _dataBankRepository.Update(existAccount);
                }
                else                  
                    _dataBankRepository.Add(dataInsert);
            }

            try
            {
                Commit();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return false;
            }

            return true;
        }

        private List<Transaction> GetTransactions(List<TransactionDto> dataBankTransactions)
        {
            return dataBankTransactions.Select(transaction => new Transaction(transaction.Id, transaction.Description, transaction.Amount, transaction.DateTrasaction, transaction.TypeTransaction)).ToList();
        }


        public TransactionDto UpdateTransaction(TransactionDto dto)
        {
            var transaction = _transactionRepository.GetById(dto.Id);
            if (transaction == null) return null;

            transaction.AlterDescription(dto.Description);
            transaction.AlterTypeTransaction(dto.TypeTransaction);
            transaction.AlterDateTrasaction(dto.DateTrasaction);
            transaction.AlterAmount(dto.Amount);

            _transactionRepository.Update(transaction);

            try
            {
                Commit();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return null;
            }

            return dto;
        }


        public bool DeleteTransaction(Guid IdTransaction)
        {            
            try
            {
                _transactionRepository.Remove(IdTransaction);
                Commit();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return false;
            }

            return true;
        }


    }
}
