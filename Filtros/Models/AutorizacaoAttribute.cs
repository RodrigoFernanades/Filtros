using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Security.Principal;
using System.Web.Routing;

namespace Filtros.Models
{
    public class AutorizacaoAttribute : FilterAttribute, IAuthenticationFilter
    {
       public void OnAuthentication(AuthenticationContext context)
        {
            IIdentity ident = context.Principal.Identity;
            if(!ident.IsAuthenticated || !ident.Name.EndsWith("@k19.com.br"))
            {
                context.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext contex)
        {
            if(contex.Result == null || contex.Result is HttpUnauthorizedResult)
            {
                contex.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "K19Autenticador" },
                    {"action", "Logar" },
                    {"returnUrl", contex.HttpContext.Request.RawUrl }
                });


            }
        }
    }
}