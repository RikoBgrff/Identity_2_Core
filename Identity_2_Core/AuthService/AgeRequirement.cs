using Microsoft.AspNetCore.Authorization;

namespace Identity_2_Core.AuthService
{
    public class AgeRequirement : IAuthorizationRequirement
    {
        public int Age { get; set; }
        public AgeRequirement(int age)
        {
            Age = age;
        }
    }
}
