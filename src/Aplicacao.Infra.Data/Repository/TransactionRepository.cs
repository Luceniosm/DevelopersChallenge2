using Aplicacao.Domain.Interface.Service;
using Aplicacao.Domain.Models;
using Aplicacao.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Infra.Data.Repository
{
    public class TransactionRepository : _Base.Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ExtractContext context)
            : base(context)
        { }

      
        public async Task<ICollection<Transaction>> GetExtractsByIdDataBank(Guid idDataBank)
        {
            return await Db.Transactions
                           .Where(_ => _.IdDataBank == idDataBank)
                           .ToListAsync();
        }
    }
}
