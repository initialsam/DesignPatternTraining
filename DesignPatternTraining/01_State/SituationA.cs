using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State
{
    public class SituationA
    {
        public Func<int, bool> Submit { get; set; }
        private bool IsFirst { get; set; }
        private IFakeService FakeService { get; set; }
        public SituationA()
        {
            IsFirst = true;
        }
        public void Work()
        {
            var flow = FakeService.GetFlow();
            //第一次不處理
            if (!IsFirst) 
            {
                Submit(flow);
            }
            IsFirst = false;
        }
    }


}
