using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus ts;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus ts, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = ts;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }
        public int Id
        {
            get => this.id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id must be positive number");
                }
                this.id = value;
            }
        }
        public TransactionStatus Status
        {
            get => this.ts;
            set => this.ts = value;
        }
        public string From 
        { 
            get => this.from;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid sender name");
                }
                this.from = value;
            }
        }
        public string To 
        {
            get => this.to;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid reciever name");
                }
                this.to = value;
            }
        }
        public double Amount
        {
            get => this.amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount must be positive number");
                }
                this.amount = value;
            }
        }
    }
}
