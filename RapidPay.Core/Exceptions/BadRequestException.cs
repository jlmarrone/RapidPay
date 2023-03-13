namespace RapidPay.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public string ErrorMessage { get; set; }
    }
}
