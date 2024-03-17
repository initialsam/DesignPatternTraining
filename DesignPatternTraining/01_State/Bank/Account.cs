using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State.Bank
{
    internal class Account
    {
        public int Balance { get; private set; }

        private bool _isClosed = false;
        private bool _isFrozen = false;
        private bool _isVerified = false;

        public void Deposit(int amount)
        {
            if(_isClosed) return;

            if (_isFrozen == false)
            {
                _isFrozen = true;
            }

            Balance += amount;
        }
        public void Withdraw(int amount)
        {
            if (_isClosed) return;

            if (_isFrozen) return;

            if (_isVerified == false) return;

            Balance -= amount;
        }
        public void HolderVerified()
        {
            this._isVerified = true;
        }

        public void Close()
        {
            this._isClosed = true;
        }

        public void Freeze()
        {
            if (_isVerified == false) return;

            if (_isClosed) return;

            _isFrozen = true;
        }
    }
}
