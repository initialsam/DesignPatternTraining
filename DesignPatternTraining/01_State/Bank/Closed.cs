using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State.Bank
{
    class Closed : IAccountState
    {
        public IAccountState Deposit(Action addToBalance) => this;
        public IAccountState Withdraw(Action subtractFromBalance) => this;
        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;
        public IAccountState Close() => this;

        public string Show()
        {
            return nameof(Closed);
        }
    }
}
