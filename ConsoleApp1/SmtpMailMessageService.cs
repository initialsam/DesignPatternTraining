using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SmtpMailMessageService : IMessageService
    {
        public SmtpMailMessageService()
        {
        }

        public void SendTermsAndConditions(string mailAddress, string text)
        {
            // TODO Implementation
            Debug.WriteLine($"Mail sent to {mailAddress}.");
        }
    }
}
