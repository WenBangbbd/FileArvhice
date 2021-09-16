using FileArchive.AccessControl.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FileArchive.AccessControl.Activate
{
    public class EmailAccountActivateService : IAccountActivateService
    {
        public readonly IOptions<ActivateOptions> _options;
        public readonly IActivateRecordRepository _activateRep;
        public EmailAccountActivateService(IOptions<ActivateOptions> options, IActivateRecordRepository activateRep)
        {
            _options = options;
            _activateRep = activateRep;
        }
        public async Task ActivateAsync(string userName, string activateCode)
        {
            var record = await _activateRep.FindByAsync(userName, activateCode);
            if (record == null)
                throw new ApplicationException("没有待激活记录");
            if (record.Activated)
                throw new ApplicationException("已激活");
            record.Activated = true;
            await _activateRep.UpdateAsync(record);
        }

        public async Task SendActivateCodeAsync(string activateCode, IUser userInfo)
        {
            var uriBuilder = new UriBuilder();
            var uri = new Uri(_options.Value.ActivatePath);
            uriBuilder.Scheme = uri.Scheme;
            uriBuilder.Host = uri.Host;
            uriBuilder.Port = uri.Port;
            var path = new PathString(uri.LocalPath)
                .Add($"/{userInfo.Name}")
                     .Add($"/{activateCode}");
            uriBuilder.Path = path;
            var content = uriBuilder.Uri.ToString();

            await SendEmailAsync(userInfo.Email, content);
            await _activateRep.InsertAsync(new ActivateRecord { ActivateCode = activateCode, UserName = userInfo.Name, Activated = false });
        }

        public async Task SendEmailAsync(string email, string content)
        {
            var mailClient = new SmtpClient(_options.Value.Domain);
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;
            //授权,不是密码
            mailClient.Credentials = new NetworkCredential(_options.Value.MailUserName, _options.Value.MailPassword);
            //信息，
            var message = new MailMessage(new MailAddress(_options.Value.MailUserName), new MailAddress(email));

            message.Subject = _options.Value.MailSubject;
            message.Body = content;
            message.IsBodyHtml = false;
            mailClient.Send(message);
        }
    }
}
