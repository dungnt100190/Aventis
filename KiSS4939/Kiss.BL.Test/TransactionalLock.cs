using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Transactions;

namespace Kiss.BL.Test
{
    public class TransactionalLock
    {
        private readonly LinkedList<KeyValuePair<Transaction, ManualResetEvent>>
            _pendingTransactions =
                new LinkedList<KeyValuePair<Transaction, ManualResetEvent>>();

        public bool Locked
        {
            get
            {
                return OwningTransaction != null;
            }
        }

        public Transaction OwningTransaction { get; private set; }

        public void Lock()
        {
            Lock(Transaction.Current);
        }

        public void Unlock()
        {
            Debug.Assert(Locked);
            lock (this)
            {
                OwningTransaction = null;

                LinkedListNode<KeyValuePair<Transaction, ManualResetEvent>>
                    node = null;

                if (_pendingTransactions.Count > 0)
                {
                    node = _pendingTransactions.First;
                    _pendingTransactions.RemoveFirst();
                }

                if (node != null)
                {
                    var transaction = node.Value.Key;
                    var manualEvent = node.Value.Value;
                    Lock(transaction);
                    lock (manualEvent)
                    {
                        if (!manualEvent.SafeWaitHandle.IsClosed)
                        {
                            manualEvent.Set();
                        }
                    }
                }
            }
        }

        private void Lock(Transaction transaction)
        {
            Monitor.Enter(this);
            if (OwningTransaction == null)
            {
                //Acquire the transaction lock
                if (transaction != null) OwningTransaction = transaction;
                Monitor.Exit(this);
                return;
            }

            //We're done if it's the same one as the method parameter
            if (OwningTransaction == transaction)
            {
                Monitor.Exit(this);
                return;
            }

            //Otherwise, need to acquire the transaction lock
            var manualEvent = new ManualResetEvent(false);

            var pair =
                new KeyValuePair<Transaction, ManualResetEvent>(
                    transaction, manualEvent);

            _pendingTransactions.AddLast(pair);

            if (transaction != null)
            {
                transaction.TransactionCompleted += delegate
                    {
                        lock (this)
                        {
                            //Pair may have already been removed if unlocked
                            _pendingTransactions.Remove(pair);
                        }
                        lock (manualEvent)
                        {
                            if (!manualEvent.SafeWaitHandle.IsClosed)
                            {
                                manualEvent.Set();
                            }
                        }
                    };
            }
            Monitor.Exit(this);

            //Block the transaction or the calling thread
            manualEvent.WaitOne();
            lock (manualEvent) manualEvent.Close();
        }
    }
}