namespace EticaretApp.Models
{
    public class TokenRoot
    {
        public Token token { get; set; }
    }
    public class Token
    {
        public string accessToken { get; set; }
        public DateTime expiration { get; set; }
        public string refreshToken { get; set; }
    }
}
