namespace EticaretApp.Dtos.Roles
{
    public class EndpointToRole
    {
        public EndpointToRole(string[] roles, string endpointCode, string menu)
        {

            Roles = roles;
            EndpointCode = endpointCode;
            Menu = menu;
        }
        public string[] Roles { get; set; }
        public string EndpointCode { get; set; }
        public string Menu { get; set; }
    }
}
