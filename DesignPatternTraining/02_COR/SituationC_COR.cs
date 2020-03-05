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
            //這樣寫的好處 直覺先檢查 Identity -> Age -> HeightWeight
            //缺點 很多時 程式碼會很長很多括號
            //return new IdentityChecker(new AgeChecker(new HeightWeightChecker(null)));

            //這樣寫的好處 程式碼都會比較短 變成很多行 比較好看
            //缺點 檢查順序 是由下到上 不小心會搞混
            //VIPChecker heightWeightChecker = new HeightWeightChecker(null);
            //VIPChecker ageChecker = new AgeChecker(heightWeightChecker);
            //return new IdentityChecker(ageChecker);

            //不用建構子 建立SetNext去指定下一個VIPChecker
            VIPChecker identityChecker = new IdentityChecker();
            identityChecker.SetNext(new AgeChecker())
                           .SetNext(new HeightWeightChecker());
            
            return identityChecker;
        }
    }

    public abstract class VIPChecker
    {
        protected VIPChecker _checker;
        public VIPChecker SetNext(VIPChecker checker)
        {
            _checker = checker;
            return _checker;
        }

        protected abstract bool InternalCheck(CorUser user);
        public bool Check(CorUser user)
        {
            if (InternalCheck(user))
            {
                // 檢查結果為 false, 則跳出, 不再往下處理
                return false;
            }

            if (_checker == null)
            {
                //若沒有後繼者,表示檢查結束
                return true;
            }

            //有後繼者則繼續往下處理
            return _checker.Check(user);
        }

       
    }

    public class IdentityChecker : VIPChecker
    {
        protected override bool InternalCheck(CorUser user)
        {
            return !user.Identity.StartsWith("A");
        }
    }

    public class AgeChecker : VIPChecker
    {
        protected override bool InternalCheck(CorUser user)
        {
            return user.Age < 18;
        }
    }

    public class HeightWeightChecker : VIPChecker
    {
        protected override bool InternalCheck(CorUser user)
        {
            return user.Height < 180 && user.Weight > 90;
        }
    }

}
