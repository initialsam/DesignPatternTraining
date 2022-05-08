namespace ConsoleApp1
{
    public interface IMessageService
    {
        void SendTermsAndConditions(string mailAddress, string text);
    }
}