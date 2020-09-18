using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MsOutlook;


namespace AtenasConsultoria.EmailService
{
    public class MailService
    {
        public enum MailSendType
        {
            SendDirect = 0,
            ShowModal = 1,
            ShowModeless = 2,
        }

        public bool SendMailWithOutlook(string subject, string htmlBody, string recipients, string[] filePaths, MailSendType sendType)
        {
            try
            {
                MsOutlook.Application outlookApp = new MsOutlook.Application();
                if (outlookApp == null)
                    return false;

                // create a new mail item.
                MsOutlook.MailItem mail = (MsOutlook.MailItem)outlookApp.CreateItem(MsOutlook.OlItemType.olMailItem);

                // set html body. 
                // add the body of the email
                mail.HTMLBody = htmlBody;

                //Add attachments.
                if (filePaths != null)
                {
                    foreach (string file in filePaths)
                    {
                        //attach the file
                        MsOutlook.Attachment oAttach = mail.Attachments.Add(file);
                    }
                }

                mail.Subject = subject;
                mail.To = recipients;

                if (sendType == MailSendType.SendDirect)
                    mail.Send();
                else if (sendType == MailSendType.ShowModal)
                    mail.Display(true);
                else if (sendType == MailSendType.ShowModeless)
                    mail.Display(false);

                mail = null;
                outlookApp = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
