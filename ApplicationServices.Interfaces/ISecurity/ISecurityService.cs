namespace ApplicationServices.Interfaces.ISecurity
{
    public interface ISecurityService
    {
        bool IsCurrentUserAdmin { get; }

        string[] CurrentUserPermissions { get; }
    }
}