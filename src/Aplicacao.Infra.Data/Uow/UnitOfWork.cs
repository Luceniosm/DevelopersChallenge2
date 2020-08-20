using System;
using System.Diagnostics;
using Aplicacao.Domain.Uow;
using Aplicacao.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Infra.Data.Uow
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ExtractContext _context;

        public UnitOfWork(ExtractContext context)
        {
            _context = context;
        }


        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
