using System.IdentityModel.Tokens.Jwt;

namespace EticaretApp.Areas.Admin.Helper
{
    public static class JwtHelper
    {
        public static IEnumerable<string> GetRolesFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            // "role" claim'lerini al
            var roles = token.Claims
                .Where(c => c.Type == "role" || c.Type == "roles") // API'deki claim adı "roles" olabilir.
                .Select(c => c.Value);

            return roles;
        }
    }
}
