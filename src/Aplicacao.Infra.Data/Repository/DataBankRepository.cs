



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Domain.Interface.Service;
using Aplicacao.Domain.Models;
using Aplicacao.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Infra.Data.Repository
{
    public class DataBankRepository : _Base.Repository<DataBank>, IDataBankRepository
    {
        public DataBankRepository(ExtractContext context)
            : base(context)
        { }

        public async Task<DataBank> GetByIdAccount(string account)
        {
            return await Db.DataBanks
                .Include(_ => _.Transactions)
                .Where(_ => _.Account == account)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<DataBank>> GetAllAccount()
        {
            return await Db.DataBanks                
                .ToListAsync();
        }
    }
}
