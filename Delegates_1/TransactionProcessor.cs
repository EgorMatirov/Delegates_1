using System;

namespace Delegates_1
{
    public class TransactionProcessor
    {
        private readonly Func<TransactionRequest, bool> _checkFunc;
        private readonly Func<TransactionRequest, Transaction> _registerFunc;
        private readonly Action<Transaction> _saveAction;

        public TransactionProcessor(Func<TransactionRequest, bool> checkFunc, Func<TransactionRequest,
            Transaction> registerFunc, Action<Transaction> saveAction)
        {
            _checkFunc = checkFunc;
            _registerFunc = registerFunc;
            _saveAction = saveAction;
        }

        public Transaction Process(TransactionRequest request )
        {
            if (!_checkFunc(request))
                throw new ArgumentException();
            var result = _registerFunc(request);
            _saveAction(result);
            return result;
        }
    }
}
