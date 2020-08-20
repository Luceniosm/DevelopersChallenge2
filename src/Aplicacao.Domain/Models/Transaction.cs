using System;

namespace Aplicacao.Domain.Models
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public Guid IdDataBank { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DateTrasaction { get; private set; }
        public string TypeTransaction { get; private set; }
        public DataBank DataBank { get; set; }

        public Transaction(Guid id, string description, decimal amount, DateTime dateTrasaction, string typeTransaction)
        {
            Id = id;            
            Description = description;
            Amount = amount;
            DateTrasaction = dateTrasaction;
            TypeTransaction = typeTransaction;
        }

        public Transaction()
        { }

        public void AlterDescription(string description)
        {
            this.Description = description?.Trim();
        }

        public void AlterAmount(decimal amount)
        {
            this.Amount = amount;
        }

        public void AlterDateTrasaction(DateTime dateTrasaction)
        {
            this.DateTrasaction = dateTrasaction;
        }

        public void AlterTypeTransaction(string typeTransaction)
        {
            this.TypeTransaction = typeTransaction?.Trim();
        }
    }
}
