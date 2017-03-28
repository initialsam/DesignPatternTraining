using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State
{
    public class SituationA_StateLite
    {
        public Func<int, bool> Submit { get; set; }
        private bool IsFirst { get; set; }
        private IFakeService FakeService { get; set; }
        private EventSender EventSender { get; set; }

        public SituationA_StateLite(Func<int, bool> submit)
        {
            this.Submit = submit;
            this.EventSender = new EventSender(x => false);
        }
        public void Work()
        {
            var flow = FakeService.GetFlow();
            this.EventSender.SendEvent(flow);
            this.EventSender.Open(this.Submit);
        }
    }

    
    internal class EventSender
    {
        public Func<int, bool> Trigger { get; set; }
        public EventSender(Func<int, bool> trigger)
        {
            //建構子進來的trigger是不做事的
            this.Trigger = trigger;
        }
        public void Open(Func<int, bool> trigger)
        {
            //Open 才會傳真正的事件
            this.Trigger = trigger;
        }

        public bool SendEvent(int flow)
        {
            return this.Trigger(flow);
        }
    }

    
}
