using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Library.Business;

namespace WebApplication.Library
{
public class EMail 
{     
    public static void Send(string userName, string sender, string subject, string body, string[] recipients) 
    {         
        SendWithLog(userName, sender, subject, body, recipients); 
    } 
    
    public static void Send(string userName, string sender, string subject, string body, string recipient) 
    {         
        SendWithLog(userName, sender, subject, body, new string[] {recipient});         
    }

    public static void AuthenticateSMTP(string FromEmail, string ToEmail, string Subj, string Body, string CCList)
    {
        //create the mail message
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        //set the addresses
        mail.From = new System.Net.Mail.MailAddress(FromEmail);
        mail.To.Add(ToEmail);
        if (CCList.Length > 0)
        {
            char[] delimitor = { ';' };
            string[] CCEmails = CCList.Split(delimitor); //(char)';');
            foreach (string s in CCEmails)
            {
                mail.Bcc.Add(s); 
            }
        } // Do nothing if no CClist

        //set the content
        mail.Subject = Subj;
        mail.Body = Body;

        //send the message
        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigSettings.SMTPServer);

        //to authenticate we set the username and password properites on the SmtpClient
        smtp.Credentials = new System.Net.NetworkCredential(ConfigSettings.SmtpServerUserName, ConfigSettings.SmtpServerPassword);
        
        // Do a Send
        try
        {
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            //LogFile.AppendtoDB("EMail.AuthenticateSMTP", ex.Message.ToString());
            //LogFile.AppendToFile(ex.Message.ToString() + ex.Source.ToString());
        }

    }

    public static string SendWithLog(string userName, string sender, string subject, string body, string[] recipients) 
    { 
        
        //EmailSPQLogEntry logSPQEntry = new EmailSPQLogEntry(); 
        MailMessage message; 
        string smtpServer = ConfigSettings.SMTPServer; 
        StringBuilder failedMessages = new StringBuilder(); 
        StringBuilder recipientList = new StringBuilder();

        message = new MailMessage(); 
        try {
            MailAddressCollection recipientListCollection = new MailAddressCollection();
            foreach (string recipient in recipients)
            {
                if (recipientList.Length > 0)
                {
                    recipientList.Append(";");
                }
                recipientList.Append(recipient);
                recipientListCollection.Add(new MailAddress(recipient));
                message.To.Add(new MailAddress(recipient));
            }

            //message = new MailMessage(); 
            message.From = new MailAddress("RichardWysocki@RichardWysocki.com");
            
            message.Subject = subject; 
            message.Body = body;



            //message.To = recipientListCollection; // recipientList.ToString(); 
            
            //Add SMTP authentication - 9/5/2006 - TJK - 
            //message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", ConfigSettings.SmtpServerUserName);
            //message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", ConfigSettings.SmtpServerPassword); 
            
            //logSPQEntry.SendTo = message.To.ToString(); 
            //logSPQEntry.Subject = message.Subject; 
            //logSPQEntry.Body = message.Body;

                        //send the message
            SmtpClient SmtpMail = new SmtpClient(ConfigSettings.SMTPServer);

            //to authenticate we set the username and password properites on the SmtpClient
            SmtpMail.Credentials = new System.Net.NetworkCredential(ConfigSettings.SmtpServerUserName, ConfigSettings.SmtpServerPassword);
            SmtpMail.Send(message);
            
        } 
        
        catch (Exception ex) {
            LogErrorBusiness.AddLogError("SendWithLog", ex.Message, ex.Source);

            failedMessages.Append(recipientList.ToString()); 
            //logSPQEntry.ErrorText = ex.ToString(); 
            //logSPQEntry.SendTo = message.To.ToString(); 
            //logSPQEntry.Subject = message.Subject; 
            //logSPQEntry.Body = message.Body; 
        } 
        finally 
        { 
            // RRW Comment Out Logging
            //LogSPQEmail(userName, new EmailSPQLogEntry[] {logSPQEntry}); 
        } 
        return failedMessages.ToString(); 
    } 
    
    } 
}
