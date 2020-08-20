using System;
using System.Collections.Generic;

namespace Aplicacao.Domain.Models
{
    public class DataBank
    {
        public Guid Id { get; private set; }
        public string Account { get; private set; }
        public string CodeBank { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public DataBank(Guid id, string account, string codeBank, List<Transaction> transactions)
        {
            Id = id;
            Account = account;
            CodeBank = codeBank;
            Transactions = transactions;
        }
        public DataBank()
        { }

        public void AddRangeTransactions(List<Transaction> transactions)
        {
            Transactions.AddRange(transactions);
        }
    }
}
