using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.DTO
{
    public class DataBankDto
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string CodeBank { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
