using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State.Bank
{
    class NotVerified : IAccountState
    {
        public NotVerified()
        {
           
        }

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active();

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public string Show()
        {
            return nameof(NotVerified);
        }
    }
}
