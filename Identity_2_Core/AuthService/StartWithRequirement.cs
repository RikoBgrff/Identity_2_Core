
using Microsoft.AspNetCore.Authorization;

namespace Identity_2_Core.AuthService
{
    public class StartWithRequirement : IAuthorizationRequirement
    {
        public string StartWithLetter { get; set; }
        public StartWithRequirement(string startWithLetter)
        {
            StartWithLetter = startWithLetter;
        }
    }
}