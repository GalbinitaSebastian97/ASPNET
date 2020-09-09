using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoAutoService.Controllers
{
    public class ContactClientController : Controller
    {
        public IActionResult ContactClient()
        {
            return View();
        }
        public IActionResult SendMailToClient(string MailClient, string Description)
        {
            Console.WriteLine(MailClient + "  " + Description);
            try
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    MailMessage msg = new MailMessage();
                    
                    msg.To.Add(MailClient);
             
                    MailAddress address = new MailAddress("demoautoservice@aol.com");
                    msg.From = address;
                    msg.Subject = "DemoAutoService - Client Info";
                    msg.Body = Description;

       
                    SmtpClient client = new SmtpClient();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Host = "smtp.aol.com";
                    client.Port = 465;

                  
                    NetworkCredential credentials = new NetworkCredential("demoautoservice@aol.com", "ParolaRebeja2020");
                    client.UseDefaultCredentials = false;
                    client.Credentials = credentials;

                    //Send the msg
                    client.Send(msg);
                }).Start();



                return View("ContactClientSended");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail Sending Service Failed  " + MailClient + "  " + ex.ToString()); return RedirectToAction("ContactClient");
            }


        }





    }
}
