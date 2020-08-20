using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.Domain.Interface.Repository;
using Aplicacao.Domain.Models;

namespace Aplicacao.Domain.Interface.Service
{
    public interface IDataBankRepository: IRepository<DataBank>
    {
        Task<DataBank> GetByIdAccount(string account);
        Task<ICollection<DataBank>> GetAllAccount();
    }
}
