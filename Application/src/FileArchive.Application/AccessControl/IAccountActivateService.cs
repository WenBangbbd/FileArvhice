using FileArchive.AccessControl.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.Application
{
    public interface IAccountActivateService
    {
        Task SendActivateCodeAsync(string activateCode, UserInput userInfo);
        Task ActivateAsync(string userName, string activateCode);
    }
}
