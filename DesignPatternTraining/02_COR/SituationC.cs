using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._02_COR
{
    public class SituationC
    {

        public bool IsVIP(CorUser user)
        {
            if (!user.Identity.StartsWith("A"))
            {
                return false;
            }
            else if (user.Age < 18)
            {
                return false;
            }
            else if (user.Height < 180 && user.Weight > 90)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class CorUser
    {
        public int Age { get; set; }
        public string Identity { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
