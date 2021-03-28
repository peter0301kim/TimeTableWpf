using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.LogIn
{
    public interface ILogInService
    {
        Task<string> LoginAsync(string userId, string password);

    }
}
