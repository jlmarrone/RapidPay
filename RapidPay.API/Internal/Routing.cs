namespace RapidPay.API.Internal
{
    public static class Routing
    {
        private const string _baseUrl = "api";

        public static class Cards
        {
            public const string Create = $"{_baseUrl}/cards/";
            public const string Pay = $"{_baseUrl}/cards/{{id:guid}}/pay";
            public const string Balance = $"{_baseUrl}/cards/{{id:guid}}/balance";
        }
    }
}
