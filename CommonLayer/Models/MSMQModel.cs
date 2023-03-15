using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Models
{
    public class MSMQModel
    {
        MessageQueue mQ = new MessageQueue();
        private void sendData2Queue(string token)
        {
            mQ.Path = @".\private$\Bills";
            if (!MessageQueue.Exists(mQ.Path))
            {
                MessageQueue.Create(mQ.Path);
            }
            mQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            mQ.ReceiveCompleted += MQ_ReceiveCompleted;
            mQ.Send(token);
            mQ.BeginReceive();
            mQ.Close();
        }

        private void MQ_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var message = mQ.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            string subject = "Token Receive";
            string body = token;
            var smpt = new SmtpClient("smpt.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("siddharth.bridgelabz@gmail.com", "hfpbrqxkfxnuqfqj"),
                EnableSsl = true
            };
            smpt.Send("siddharth.bridgelabz@gmail.com", "siddharth.bridgelabz@gmail.com", subject, body);
            mQ.BeginReceive();
        }
    }
}

