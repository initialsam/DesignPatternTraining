using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State
{
    public class SituationB_State
    {
        public Func<int, bool> Submit { get; set; }
        private IFakeService FakeService { get; set; }
        private IEventSenderB EventSender { get; set; }

        public SituationB_State(Func<int, bool> submit)
        {
            this.Submit = submit;
            this.EventSender = new OddEventSender(this.Submit);
        }
        public void Work()
        {
            var flow = FakeService.GetFlow();
            this.EventSender = this.EventSender.SendEvent(flow);
        }
    }

    internal interface IEventSenderB
    {
        IEventSenderB SendEvent(int flow);
    }

    internal class EvenEventSender : IEventSenderB
    {
        public Func<int, bool> Trigger { get; set; }
        public EvenEventSender(Func<int, bool> trigger)
        {
            this.Trigger = trigger;
        }
        public IEventSenderB SendEvent(int flow)
        {
            //偶數不處理
            return new OddEventSender(this.Trigger);
        }
    }

    internal class OddEventSender : IEventSenderB
    {
        public Func<int, bool> Trigger { get; set; }
        public OddEventSender(Func<int, bool> trigger)
        {
            this.Trigger = trigger;
        }

        public IEventSenderB SendEvent(int flow)
        {
            this.Trigger(flow);
            return new EvenEventSender(this.Trigger);
        }
    }
}
