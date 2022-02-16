using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity_2_Core.AuthService
{
    public class StartWithHandler : AuthorizationHandler<StartWithRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, StartWithRequirement requirement)
        {
            var currenUsername = context.User.FindFirst(u => u.Type == ClaimTypes.Name).Value;
            var currentUsernameStartWithLetter = currenUsername[0].ToString();



            if (currentUsernameStartWithLetter == requirement.StartWithLetter)
            {
                context.Succeed(requirement);
            }



            return Task.CompletedTask;
        }
    }
}