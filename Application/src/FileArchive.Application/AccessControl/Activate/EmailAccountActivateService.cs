using FileArchive.AccessControl.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FileArchive.Application
{
    public class EmailAccountActivateService : IAccountActivateService
    {
        public readonly IOptions<EmailActivateOptions> _options;
        public readonly IActivateRecordRepository _activateRep;
        public EmailAccountActivateService(IOptions<EmailActivateOptions> options)
        {
            _options = options;
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

        public async Task SendActivateCodeAsync(string activateCode, UserInput userInfo)
        {
            var mailClient = new SmtpClient(_options.Value.Domain);
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;

            //授权,不是密码
            mailClient.Credentials = new NetworkCredential(_options.Value.MailUserName, _options.Value.MailPassword);
            //信息，
            var message = new MailMessage(new MailAddress(_options.Value.MailUserName), new MailAddress(userInfo.Email));
            message.IsBodyHtml = false;
            message.Body = new PathString(_options.Value.ActivatePath)
                                .Add(userInfo.Name)
                                .Add(activateCode);
            message.Subject = _options.Value.MailSubject;
            //发送邮件
            mailClient.Send(message);
           await _activateRep.InsertAsync(new ActivateRecord { ActivateCode = activateCode, UserName = userInfo.Name, Activated = false });
        }
    }
}
