using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Obligatorio.Filtros
{
    public class User : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            //no loguado
            if (context.HttpContext.Session.Keys.IsNullOrEmpty())
            {
                context.Result = new RedirectResult("/");
                return;
            }
        }
    }
}
