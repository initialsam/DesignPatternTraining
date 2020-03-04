using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._02_COR
{
    public class SituationC_COR
    {

        public bool IsVIP(CorUser user)
        {
            var checker = VIPCheckerContext.GetCheckers();
            return checker.Check(user);
        }
    }

    public class VIPCheckerContext
    {
        public static VIPChecker GetCheckers()
        {
            return new IdentityChecker(new AgeChecker(new HeightWeightChecker((null))));
        }
    }

    public abstract class VIPChecker
    {
        protected VIPChecker _successor;
        protected abstract bool InternalCheck(CorUser user);
        public bool Check(CorUser user)
        {
            if (InternalCheck(user))
            {
                // 檢查結果為 false, 則跳出, 不再往下處理
                return false;
            }

            if (_successor == null)
            {
                //若沒有後繼者,表示檢查結束
                return true;
            }

            //有後繼者則繼續往下處理
            return _successor.Check(user);
        }

        protected VIPChecker(VIPChecker successor)
        {
            _successor = successor;
        }
    }

    public class IdentityChecker : VIPChecker
    {
        public IdentityChecker(VIPChecker successor) : base(successor)
        {
        }

        protected override bool InternalCheck(CorUser user)
        {
            return !user.Identity.StartsWith("A");
        }
    }

    public class AgeChecker : VIPChecker
    {
        public AgeChecker(VIPChecker successor) : base(successor)
        {
        }

        protected override bool InternalCheck(CorUser user)
        {
            return user.Age < 18;
        }
    }

    public class HeightWeightChecker : VIPChecker
    {
        public HeightWeightChecker(VIPChecker successor) : base(successor)
        {
        }

        protected override bool InternalCheck(CorUser user)
        {
            return user.Height < 180 && user.Weight > 90;
        }
    }

}
