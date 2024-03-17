using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State.Bank
{
    class Frozen : IAccountState
    {
        public Frozen()
        {
            
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return new Active();
        }

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;
        public IAccountState Close() => new Closed();

        public string Show()
        {
            return nameof(Frozen);
        }
    }
}
