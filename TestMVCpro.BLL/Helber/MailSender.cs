using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.BLL.Models;

namespace TestMVCpro.BLL.Helber
{
   public class MailSender
    {
        public static string SendMail(MailVM model) 
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("fsabre118@gmail.com", "fatma_1999");
                smtp.Send("fsabre118@gmail.com", model.Mail, model.Title, model.Message);
               
                var reuselt = "Mail send Success";
                return reuselt;
            }
            catch (Exception ex)
            {

                var reuselt = "Mail Faild";
                return reuselt;
            }

        }
    }
}
