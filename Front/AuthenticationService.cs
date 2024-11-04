namespace Front;
public interface IAuthenticationService
{
    string GetAuthenticationCookie(HttpContext httpContext);
}

public class AuthenticationService : IAuthenticationService
{
    public string GetAuthenticationCookie(HttpContext httpContext)
    {
        if (httpContext == null || httpContext.Request.Cookies == null)
        {
            return null;
        }
        return httpContext.Request.Cookies[".AspNetCore.Identity.Application"];
    }
}
