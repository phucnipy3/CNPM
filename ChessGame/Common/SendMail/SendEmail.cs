using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.SendMail
{
    public class SendEmail
    {
        public static async Task<bool> SendEmailAsync(string SendTo, string pass)
        {
            try
            {
                Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                bool result = regex.IsMatch(SendTo);
                if (result == false)
                {
                    return false;
                }
                else
                {
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("phamxuanduc1201@gmail.com", "phamxuanduc");
                    MailMessage msg = new MailMessage("phamxuanduc1201@gmail.com", SendTo);
                    msg.Subject = "Mật khẩu";
                    msg.Body = pass;
                    msg.IsBodyHtml = true;
                    await smtp.SendMailAsync(msg);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
