using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Projeto_Mobile_Sustentabilidade.Services
{
    public interface IMailer
    {
        Task Send(string to, string subject, string content);
        //void Send(IEnumerable<string> to, string content);
    }
     public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
    }
    public class SendGridService : IMailer
    {
        protected SendGridClient client;
        protected EmailAddress from;
        protected List<string> recipients;
        protected List<string> bcc;
        protected IViewRenderService viewRender;
        protected IConfiguration configuration;

        public SendGridService(IConfiguration configuration, IViewRenderService viewRender)
        {
            this.configuration = configuration;
            var sendgridConfig = configuration.GetSection("SendGrid");
            var senderEmail = sendgridConfig.GetValue<string>("Sender_Email");
            var senderName = sendgridConfig.GetValue<string>("Sender_Name");
            var apiKey = sendgridConfig.GetValue<string>("Api_Key");
            var recipients = sendgridConfig.GetValue<string>("Recipients");
            var bcc = sendgridConfig.GetValue<string>("Bcc");

            if (!string.IsNullOrEmpty(apiKey))
            {
                var settings = GetSettings();
                client = new SendGridClient(settings.ApiKey);
                from = new EmailAddress(senderEmail, senderName);
                this.viewRender = viewRender;

                if (recipients?.Length > 0) {
                    this.recipients = recipients.Split(",").Select(e => e.Trim()).ToList();
                }

                if (bcc?.Length > 0) {
                    this.bcc = bcc.Split(",").Select(e => e.Trim()).ToList();
                }
            }
            else
            {
                // @todo Log erro
            }
        }

        public async Task Send(string to, string subject, string content)
        {
            await Send(new List<string> {to}, subject, content);
        }

        public async Task Send(IEnumerable<string> tos, string subject, string content)
        {
            try
            {
                if (client == null)
                {
                    throw new NullReferenceException();
                }

                if (this.recipients != null)
                {
                    tos = this.recipients;
                }

                var viewContent = await viewRender.RenderToStringAsync("Email/Simple", content);

                var message = MailHelper.CreateSingleEmailToMultipleRecipients(@from,
                    tos.Select(to => new EmailAddress(to)).ToList(),
                    subject, content, viewContent);

                if (this.bcc != null)
                {
                    message.AddBccs(this.bcc.Select(to => new EmailAddress(to)).ToList());
                }

                await client.SendEmailAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // @todo Log Send email
            }
        }

        public async Task Send(IEnumerable<string> tos, string subject, string viewName, object model, IEnumerable<Attachment> attachments = null)
        {
            try
            {
                if (client == null)
                {
                    throw new NullReferenceException();
                }

                if (this.recipients != null)
                {
                    tos = this.recipients;
                }

                var viewContent = await viewRender.RenderToStringAsync(viewName, model);
                var message = MailHelper.CreateSingleEmailToMultipleRecipients(@from,
                    tos.Select(to => new EmailAddress(to)).ToList(),
                    subject, "", viewContent);

                if (this.bcc != null)
                {
                    message.AddBccs(this.bcc.Select(to => new EmailAddress(to)).ToList());
                }

                if (attachments != null)
                {
                    message.AddAttachments(attachments);
                }

                await client.SendEmailAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // @todo Log Send email
            }
        }

        public async Task Send(string to, string subject, string viewName, object model, IEnumerable<Attachment> attachments = null)
        {
            await Send(new List<string>() {to}, subject, viewName, model, attachments);
        }

        public EmailSettings GetSettings()
        {
            var sendgridConfig = configuration.GetSection("SendGrid");
            var senderEmail = sendgridConfig.GetValue<string>("Sender_Email");
            var senderName = sendgridConfig.GetValue<string>("Sender_Name");
            var apiKey = sendgridConfig.GetValue<string>("Api_Key");
            return new EmailSettings()
            {
                // SistemaService.GetOption<string>("SENDGRID_API_KEY"),
                ApiKey = apiKey,
                // SistemaService.GetOption<string>("SENDER_EMAIL", "no-reply@taesa.com.br"),
                SenderEmail = senderEmail,
                //SistemaService.GetOption<string>("SENDER_NAME", "No Reply")
                SenderName = senderName
            };
        }
    }
}