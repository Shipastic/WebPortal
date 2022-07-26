using ApplicationServices.Interfaces.ISecurity;

namespace ApplicationServices.Implementation.Security
{
    public class Securityservice : ISecurityService
    {
        public bool IsCurrentUserAdmin => throw new NotImplementedException();

        public string[] CurrentUserPermissions => throw new NotImplementedException();
    }
}





