using DesignPatternTraining._02_COR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new SituationC_COR2();
            var b = a.IsVIP(new CorUser
            {
                Age = 20,
                Height = 190,
                Weight = 80,
                Identity = "A123456789"
            });
        }
    }
}
