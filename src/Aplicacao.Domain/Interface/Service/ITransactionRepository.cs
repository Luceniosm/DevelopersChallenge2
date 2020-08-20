using Aplicacao.Domain.Interface.Repository;
using Aplicacao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Domain.Interface.Service
{
    public interface ITransactionRepository: IRepository<Transaction>
    {        
        Task<ICollection<Transaction>> GetExtractsByIdDataBank(Guid idDataBank);
    }
}
