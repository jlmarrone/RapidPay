namespace RapidPay.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public string ErrorMessage { get; set; }
    }
}
