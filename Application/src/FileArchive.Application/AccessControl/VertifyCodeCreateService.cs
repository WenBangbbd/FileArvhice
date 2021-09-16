using System;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.Application
{
    public class VertifyCodeCreateService : IVertifyCodeCreateService
    {
        public const string Letters = "0123456789ABCDEFGHJKLMNPRTUVWXYZ";
        public static string GenerateCaptchaCode()
        {
            Random rand = new Random();
            int maxRand = Letters.Length - 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                int index = rand.Next(maxRand);
                sb.Append(Letters[index]);
            }
            return sb.ToString();
        }
        public Task<string> CreateAsync()
        {
            return Task.FromResult(GenerateCaptchaCode());
        }
    }
}
