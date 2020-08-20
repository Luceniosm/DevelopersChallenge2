using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.DTO;

namespace Aplicacao.Application.Interface
{
    public interface IExtractService
    {
        Task<List<DataBankDto>> GetAccount();
        Task<List<TransactionDto>> GetExtractsByIdDataBank(Guid idDataBank);
        Task<bool> SaveExtract(List<DataBankDto> dataBank);
        TransactionDto UpdateTransaction(TransactionDto dto);
        bool DeleteTransaction(Guid IdTransaction);
    }
}
