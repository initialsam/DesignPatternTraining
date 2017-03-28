using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._01_State
{
    public class SituationA_State
    {
        public Func<int, bool> Submit { get; set; }
        private bool IsFirst { get; set; }
        private IFakeService FakeService { get; set; }
        private IEventSender EventSender { get; set; }

        public SituationA_State(Func<int, bool> submit)
        {
            this.Submit = submit;
            this.EventSender = new NotExecuteEventSender(this.Submit);
        }
        public void Work()
        {
            var flow = FakeService.GetFlow();
            this.EventSender.SendEvent(flow);
            this.EventSender = this.EventSender.Open();
        }
    }

    internal interface IEventSender
    {
        bool SendEvent(int flow);
        IEventSender Open();
    }

    internal class NotExecuteEventSender : IEventSender
    {
        public Func<int, bool> Trigger { get; set; }
        public NotExecuteEventSender(Func<int, bool> trigger)
        {
            this.Trigger = trigger;
        }
        public IEventSender Open()
        {
            return new RegularEventSender(this.Trigger);
        }

        public bool SendEvent(int flow)
        {
            //第一次不處理
            return false;
        }
    }

    internal class RegularEventSender : IEventSender
    {
        public Func<int, bool> Trigger { get; set; }
        public RegularEventSender(Func<int, bool> trigger)
        {
            this.Trigger = trigger;
        }
        public IEventSender Open()
        {
            return this;
        }

        public bool SendEvent(int flow)
        {
            return this.Trigger(flow);
        }
    }
}
