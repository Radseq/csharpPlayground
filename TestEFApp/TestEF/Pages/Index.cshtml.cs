using EFDataAccessLib.DataAccess;
using EmployessLib;
using MessageServices;
using MessageServices.Factory;
using MessageServices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using SystemLib;
using SystemLib.Logging;

namespace TestEF.Pages
{
    // Add-Migration AddEmployeeTable
    // Update-Database

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext db;
        private readonly IConfiguration Configuration;

        ILog Logger = new ConsoleLogger();

        public IndexModel(ILogger<IndexModel> logger, PeopleContext db, IConfiguration configuration)
        {
            _logger = logger;
            this.db = db;
            Configuration = configuration;
        }

        public void OnGet()
        {
            MessageService ms = new MailKitEmailSender();
            ILog cl = new ConsoleLogger();

            Action<MessageService> messageAction = EmailFuncPrepare;
            EmailFuncPrepare(ms);

            CheckObjectype(cl);

            var people = db.People.Include(a => a.Addresses)
                .Include(a => a.EmailsAddresses)
                .Where(a => a.Age >= 14)
                .ToList();

            List<IPersonModel> personModels = new List<IPersonModel>
            {
                new TesterEmpModel { FirstName = "Adam", LastName = "Molenda", Email = "AdamMolenda@email.eu", Age = 24 },
                new ManagerEmpModel { FirstName = "Jan", LastName = "Bednarek", Email = "AdamBednarek@email.eu", Age = 32 }
            };

            foreach (var perModel in personModels)
            {
                /*
                TesterEmpAccount newEmp = new TesterEmpAccount();
                //newEmp.SetLogger(logger);
                EmployeeModel empModel = newEmp.Create(perModel);
                employees.Add(empModel);*/
                people.Add(perModel.AccountProcces.Create(perModel));
            }

        }

        private static void CheckObjectype(ILog cl)
        {
            object obj = cl;
            ConsoleLogger consoleLog;

            bool ObjISConsoleLoggerType = obj.GetType() == typeof(ConsoleLogger);
            if (ObjISConsoleLoggerType)
                consoleLog = (ConsoleLogger)obj;
        }

        private void EmailFuncPrepare(MessageService obj)
        {
            obj = new MailKitEmailSender();
            obj.MessageSender += Ms_MessageSender;

            IMailKitMessageEmail mailKit = new MailKitMessageEmail();
            SetMailKitSenderSettings(ref mailKit);

            var mailFactory = new MessageFactory();

            mailFactory.MailKitEmailSystem = mailKit;

            obj.SendMessage(mailFactory);
        }

        private void SetMailKitSenderSettings(ref IMailKitMessageEmail mailKit)
        {
            mailKit.mailKitEmailSenderOptions = new MailKitEmailSenderOptions();

            mailKit.mailKitEmailSenderOptions.Host_Address = Configuration["ExternalProviders:MailKit:SMTP:Address"];
            mailKit.mailKitEmailSenderOptions.Host_Port = Convert.ToInt32(Configuration["ExternalProviders:MailKit:SMTP:Port"]);
            mailKit.mailKitEmailSenderOptions.Host_Username = Configuration["ExternalProviders:MailKit:SMTP:Account"];

            mailKit.mailKitEmailSenderOptions.Host_Password = Utils.ConvertToSecureString(Configuration["ExternalProviders:MailKit:SMTP:Password"]);

            mailKit.mailKitEmailSenderOptions.Sender_EMail = Configuration["ExternalProviders:MailKit:SMTP:SenderEmail"];
            mailKit.mailKitEmailSenderOptions.Sender_Name = Configuration["ExternalProviders:MailKit:SMTP:SenderName"];
        }

        private void Ms_MessageSender(object sender, MessageServiceEventArgs e)
        {
            if (e.m_Message.IsSended == true)
                Logger.INFO("Email Sended!");
            else
                Logger.WARN("Cant send email!");
        }
    }
}
