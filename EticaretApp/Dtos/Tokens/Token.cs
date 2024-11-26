namespace EticaretApp.Dtos.Tokens
{
    public class TokenRoot
    {
        public Token Token { get; set; }
    }
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
