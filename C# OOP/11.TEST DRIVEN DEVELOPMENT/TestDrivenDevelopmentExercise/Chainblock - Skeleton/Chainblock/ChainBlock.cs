using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chainblock
{
    public class ChainBlock : IChainblock
    {
        private ICollection<ITransaction> transactions;
        public ChainBlock()
        {
            this.transactions = new List<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx.Id))
            {
                throw new ArgumentException("Invalid Id");
            }
            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            var transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new ArgumentException("Id is not in the block");
            }
            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var toReturn = this.transactions
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            if (toReturn.Count == 0)
            {
                throw new InvalidOperationException("No Transactions with given Status");
            }
            return toReturn;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var toReturn = this.transactions
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            if (toReturn.Count == 0)
            {
                throw new InvalidOperationException("No Transactions with given Status");
            }
            return toReturn;
        }

        public ITransaction GetById(int id)
        {
            var transactionToReturn = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transactionToReturn == null)
            {
                throw new InvalidOperationException("Id is not int the block");
            }
            return transactionToReturn;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var collectionToReturn = this.transactions
                 .Where(t => t.Status == status)
                 .OrderByDescending(t => t.Amount)
                 .ToList();

            if (collectionToReturn.Count == 0)
            {
                throw new InvalidOperationException("No Transactions with given Status");
            }
            return collectionToReturn;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return this.transactions.GetEnumerator();
        }

        public void RemoveTransactionById(int id)
        {
            var transaction = this.GetById(id);
            this.transactions.Remove(transaction);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
