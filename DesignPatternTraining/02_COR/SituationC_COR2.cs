using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTraining._02_COR
{
    public class SituationC_COR2
    {
        public bool IsVIP(CorUser user)
        {
            var handler = VIPCheckerContext2.GetHandlers();

            return handler.Handle(user);

        }
    }

    public class VIPCheckerContext2
    {
        public static VIPHandler GetHandlers()
        {
            var handler = new VIPHandler();
            handler.SetNext(new IdentityHandler());
            handler.SetNext(new AgeHandler());
            handler.SetNext(new HeightHandler());
            return handler;
        }
    }

    public interface IReceiver<T> where T : class
    {
        bool Handle(T request);
    }

    public class VIPHandler
    {
        private readonly IList<IReceiver<CorUser>> receivers;

        public VIPHandler()
        {
            receivers = new List<IReceiver<CorUser>>();
        }

        public bool Handle(CorUser user)
        {
            if (!receivers.Any()) return false;

            foreach (var receiver in receivers)
            {
                Console.WriteLine($"Running: {receiver.GetType().Name}");

                if (receiver.Handle(user))
                {
                    return false;
                }
            }
            return true;
        }

        public void SetNext(IReceiver<CorUser> next)
        {
            receivers.Add(next);
        }
    }


    public class IdentityHandler : IReceiver<CorUser>
    {
        public bool Handle(CorUser user)
        {
            return !user.Identity.StartsWith("A");
        }
    }

    public class AgeHandler : IReceiver<CorUser>
    {
        public bool Handle(CorUser user)
        {
            return user.Age < 18;
        }
    }

    public class HeightHandler : IReceiver<CorUser>
    {
        public bool Handle(CorUser user)
        {
            return user.Height < 180 && user.Weight > 90;
        }
    }

}
