using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Services
{
    public interface IAppUserService
    {
        string GetUserId();
        string GetUserName();
    }


    public class AppUserService : IAppUserService
    {
        public string GetUserId() => string.Empty;
        public string GetUserName() => string.Empty;
    }
}
