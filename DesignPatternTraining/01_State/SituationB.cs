using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State
{
    public class SituationB
    {
        public Func<int, bool> Submit { get; set; }
        private bool IsOdd { get; set; }
        private IFakeService FakeService { get; set; }
        public SituationB()
        {
            IsOdd = true;
        }
        public void Work()
        {
            var flow = FakeService.GetFlow();
            //單數才處理
            if (IsOdd) 
            {
                Submit(flow);
                IsOdd = !IsOdd;
            }
        }
    }
}
