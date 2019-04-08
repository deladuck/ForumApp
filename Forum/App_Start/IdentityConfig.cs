using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Forum.App_Start {
    public class IdentityConfig {

    }

    public class EmailService : IIdentityMessageService {
        public Task SendAsync(IdentityMessage message) {
            // настройка логина, пароля отправителя
            var from = "noreply@neoncoin.top";
            var pass = "Y60sL2cV3cnP";

            // адрес и порт smtp-сервера, с которого мы и будем отправлять 
            SmtpClient client = new SmtpClient("mail.adm.tools", 2525);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pass);
            client.EnableSsl = true;

            // создаем письмо: message.Destination - адрес получателя
            var mail = new MailMessage(from, message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.IsBodyHtml = true;

            return client.SendMailAsync(mail);
        }
    }
}