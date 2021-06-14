using System;
using System.Collections.Generic;

using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace AtomicSeller
{
    public class Email
    {
        /*
        public static void EmailReportingJob(DailyJob _DailyJob)
        {
            Tools.ErrorHandler("EmailReportingJob: ClientID=" + _DailyJob.ClientID.ToString()+ " JobType=" + _DailyJob.JobType.ToString() + " SettingID=" + _DailyJob.SettingID.ToString(), null,false,true,false);

            if (_DailyJob.ClientID == null) return;
            if (_DailyJob.ClientID == 0) return;

            int ClientID = (int)_DailyJob.ClientID;

            string Recipient = null;
            string ConnectionString = "";

            using (var dbLD = new AtomicLoginDataEntities())
            {
                ConnectionString = dbLD.Clients.FirstOrDefault(c => c.ClientID == ClientID).ConnectionString;
                Recipient = dbLD.Clients.FirstOrDefault(c => c.ClientID == ClientID).ReportingEmails;
                //Recipient = dbLD.DailyJobs.FirstOrDefault(j => j.ClientID == ClientID && j.JobType == (int)JobScheduler.JobType.EmailReporting).EmailRecipient;
            }

            using (var db = new AtomicMTEntities(ConnectionString))
            {
                string Body = "";
                //var ShipmentsOfTheDay = db.Shipment.Where(s => s.ShipmentStatus == "P").Count();

                DateTime Yesterday = DateTime.Now.AddDays(-1);

                int OrdersOfTheDay =
                    (from s in db.Shipment
                     where s.ShippingDate >= Yesterday.Date
                     select s.Shipment_ID).Count();

                int ShipmentsOfTheDay =
                    (from s in db.Shipment
                     where s.ShippingDate >= Yesterday.Date
                     &&
                     s.ShipmentStatus == "P"
                     select s.Shipment_ID).Count();

                int ErrorsOfTheDay =
                    (from s in db.Shipment
                     where s.ShippingDate >= Yesterday.Date
                     &&
                     s.ShipmentStatus == "T"
                     &&
                     (s.ErrorStatus == "E" && s.ErrorStatus == "U")
                     select s.Shipment_ID).Count();

                string NL = "<br />";
                Body = NL + NL +
                    "AtomicSeller daily reporting -" + DateTime.Today +
                    NL + NL +
                    "Labels to be printed : " + ShipmentsOfTheDay.ToString() +
                    NL + NL +
                    "Errors : " + ErrorsOfTheDay.ToString() +
                    NL + NL +
                    "Total Orders : " + OrdersOfTheDay.ToString();

                if (!string.IsNullOrEmpty(Recipient))
                    Email.SendMail("AtomicSeller daily reporting - " + DateTime.Today.ToString(), Body, Recipient);
                else
                    Tools.ErrorHandler("AtomicSeller daily reporting - " + DateTime.Today.ToString() + " " + Recipient, null, false, true, false);
            }

        }
        */

        public static void EmailReporting(string Recipient=null, int ClientID=0)
        {
            /*
            if (ClientID == 0)
                ClientID  = SessionBag.Instance.ClientID;
            string ConnectionString="";

            using (var db2 = new AtomicLoginDataEntities())
            {
                Recipient = db2.JobTriggers.FirstOrDefault(j => j.ClientID == ClientID && j.JobType.ToUpper() == "EMAILREPORTING").EmailRecipient;
                ConnectionString = db2.Clients.FirstOrDefault(c => c.ClientID == ClientID).ConnectionString;
            }

            //string Recipient =  SQLServerEntities.GetSetting("EmailSettingRecipient");  //"support@atomicseller.com"; 
            if (string.IsNullOrEmpty(Recipient))
            {
                if (ClientID > 0)
                    using (var db2 = new AtomicLoginDataEntities())
                    {
                        Recipient = db2.JobTriggers.FirstOrDefault(j => j.ClientID == ClientID && j.JobType.ToUpper() == "EMAILREPORTING").EmailRecipient;
                    }
            }


            using (var db = new AtomicMTEntities(ConnectionString))
            {
                string Body = "";
                //var ShipmentsOfTheDay = db.Shipment.Where(s => s.ShipmentStatus == "P").Count();

                DateTime Yesterday = DateTime.Now.AddDays(-1);

                int OrdersOfTheDay =
                    (from s in db.Shipment
                     where s.ShippingDate >= Yesterday.Date
                     select s.Shipment_ID).Count();

                int ShipmentsOfTheDay =
                    (from s in db.Shipment
                     where s.ShippingDate >= Yesterday.Date
                     &&
                     s.ShipmentStatus == "P"
                     select s.Shipment_ID).Count();

                int ErrorsOfTheDay =
                    (from s in db.Shipment
                     where s.ShippingDate >= Yesterday.Date
                     &&
                     s.ShipmentStatus == "T"
                     &&
                     (s.ErrorStatus == "E" && s.ErrorStatus == "U")
                     select s.Shipment_ID).Count();

                string NL= "<br />";
                Body = NL+ NL +
                    "AtomicSeller daily reporting -" + DateTime.Today + 
                    NL + NL +
                    "Labels to be printed : " + ShipmentsOfTheDay.ToString() +
                    NL + NL +
                    "Errors : " + ErrorsOfTheDay.ToString() +
                    NL + NL +
                    "Total Orders : " + OrdersOfTheDay.ToString();

                if (!string.IsNullOrEmpty(Recipient))
                    Email.SendMail("AtomicSeller daily reporting - " + DateTime.Today.ToString(), Body, Recipient);
                else
                    Tools.ErrorHandler("AtomicSeller daily reporting - " + DateTime.Today.ToString() + " " + Recipient,null,false ,true ,false);            
            }
            */
        }

        public static void SendMail(string Title, string Body, string Recipient)
        {

            const string Sender = "reporting@atomicshipment.com";
            const string CredentialUserName = "reporting@atomicshipment.com";
            const string CredentialPassword = "J27sqh%%";
            const string SmtpServer = "pro2.mail.ovh.net";
            const int SmtpPort = 587; // Not SSL (SSL=465)


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Sender);

                List <string> RecipientList = new Tools().ExtractEmails(Recipient);

                foreach (string _RecipEmail in RecipientList)
                    mail.To.Add(_RecipEmail);

                mail.Subject = Title;
                mail.Body = Body;

                mail.IsBodyHtml = true;

                using (SmtpClient _smtpClient = new SmtpClient(SmtpServer, SmtpPort))
                //using (SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    _smtpClient.Credentials = new NetworkCredential(CredentialUserName, CredentialPassword);
                    //_smtpClient.EnableSsl = true;
                    try
                    {
                        ServicePointManager.ServerCertificateValidationCallback =
                        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                        { return true; };

                        //_smtpClient.Send(mail);

                        ServicePointManager.ServerCertificateValidationCallback =
                        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                        { return false; };
                    }
                    catch (Exception ex)
                    {
                        Tools.ErrorHandler("", ex, false, true, true);
                        return;
                    }
                }
            }

        }

    }
}