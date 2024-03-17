using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State.Bank
{
    class Active : IAccountState
    {

        public Active()
        {
           
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState Freeze() => new Frozen();
        public IAccountState HolderVerified() => this;
        public IAccountState Close() => new Closed();

        public string Show()
        {
            return nameof(Active);
        }
    }
}
