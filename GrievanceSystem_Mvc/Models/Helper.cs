using GrievanceSystem_Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace GrievanceSystem_Mvc.Models
{
    internal class Helper
    {
        public static string SetFilePath()
        {
            return "~/File";
        }


        public static void SendMail(string toEmail, string emailBody)
        {

            MailMessage message = new MailMessage("akashghadage.68@gmail.com", toEmail);
            //message.To.Add(new MailAddress(toEmail));  // replace with valid value 
            message.Subject = "Grievance Submitted Successfully.";
            message.Body = emailBody;
            message.IsBodyHtml = true;


            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;


                var credential = new NetworkCredential
                {
                    UserName = "akashghadage.68@gmail.com",  // replace with valid value
                    Password = "AkashOne7"  // replace with valid value
                };

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credential;

                try
                {

                    smtp.Send(message);
                }
                catch (Exception ex)
                {

                    string msg = ex.Message; ;
                }

            }


        }

        public static string GenerateEmailBody(string userName, string emailAddress, NewGrievanceViewModel g)
        {
            string emailBody = "<table><tbody>" +
                "<tr><td>Name</td><td>" + "   " + userName + "</td></tr>" +
                "<tr><td>Email ID</td><td>" + "   " + emailAddress + "</td></tr>" +
                "<tr><td>Grievance Type</td><td>" + "   " + g.subject + "</td></tr>" +
                "<tr><td>Comment</td><td>" + "   " + g.description + "</td></tr>" +
                "</tbody></table>" +
                "<p>Grievance Submitted Successfully <br/> Thanks and Regards,</p>";
            return emailBody;
        }
    }
}


