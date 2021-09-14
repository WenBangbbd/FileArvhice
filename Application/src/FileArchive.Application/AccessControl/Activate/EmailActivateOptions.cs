namespace FileArchive.Application
{
    public class EmailActivateOptions
    {
        public const string Position = "EmailActivate";
        /// <summary>
        /// 域
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 邮件用户名
        /// </summary>
        public string MailUserName { get; set; }
        /// <summary>
        /// 邮件密码
        /// </summary>
        public string MailPassword { get; set; }
        /// <summary>
        /// 激活地址
        /// </summary>
        public string ActivatePath { get; set; }
        /// <summary>
        /// 邮件主题
        /// </summary>
        public string MailSubject { get; internal set; }
    }
}
