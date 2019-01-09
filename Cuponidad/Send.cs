using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuponidad
{
    public class Send
    {
       
        private static SendGridClient GetClient(IConfiguration rIconfig)
        {
            return GetClient(rIconfig.GetSection("SendGrid").GetSection("Api_Key").Value);
        }
        private static SendGridClient GetClient(string pApiKey)
        {
            var client = new SendGridClient(pApiKey);
            return client;
        }
        public static async Task SendEmail(IConfiguration rIconfig, string pFrom, string pTo, string pSubject, string pTextContent, string pHtmlContent)
        {
            SendGridClient oClient = GetClient(rIconfig);
            var vFrom = new EmailAddress(pFrom, "Cuponidad");
            var vTo = new EmailAddress(pTo, "User");
            var vMsg = MailHelper.CreateSingleEmail(vFrom, vTo, pSubject, pTextContent, pHtmlContent);
            await oClient.SendEmailAsync(vMsg);
        }
    }
}
