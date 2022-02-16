using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity_2_Core.AuthService
{
    public class AgeHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var currentUserDateOfBirth = context.User.FindFirst(i => i.Type == ClaimTypes.DateOfBirth).Value;
                var userAgeTimeSpan = DateTime.Now - Convert.ToDateTime(currentUserDateOfBirth);
                var userAgeDays = userAgeTimeSpan.TotalDays;
                var userAge = userAgeDays / 365;
                if (userAge >= requirement.Age)
                {
                    context.Succeed(requirement);
                }
            }
                return Task.CompletedTask;
        }
    }
}