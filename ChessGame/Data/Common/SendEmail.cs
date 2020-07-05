using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common
{
    public class SendEmail
    {
        public static bool Send_Email(string SendTo, string pass)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");


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
                    smtp.Send(msg);
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
