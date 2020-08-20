using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.DTO
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTrasaction { get; set; }
        public string TypeTransaction { get; set; }
    }
}
