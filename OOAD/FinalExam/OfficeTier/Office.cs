using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Communication.Email;
using Azure.Communication.Email.Models;
using System.Data;
using MySql.Data.MySqlClient;
namespace FinalExam;
class BusinessLogic
{
   
    static void Main(string[] args)
    {
        bool _continue = true;
        User user;
        Program program;
        GuiTier appGUI = new GuiTier();
        Datatier database = new Datatier();


        // start GUI
        user = appGUI.Login();

       
        if (database.LoginCheck(user)){

            while(_continue){
                int option  = appGUI.Dashboard(user);
                switch(option)
                {
                    
                    case 1:
                        /*Console.WriteLine("Please input a unit number");
                        int unit_number = Convert.ToInt32(Console.ReadLine());


                        // Code for processing and sending notification email to resident 
                        string serviceConnectionString = "endpoint=https://hskarrweek10communicationservice.communication.azure.com/;accesskey=SWJw5rSI11E3kSiwuaP8Z6ik3A+hdAp3FcLeOht0eAMd7pu2SNzmSyJ1sca8d6SuF/dnzDMlAVKIlzMIqRY8aQ==";
                        EmailClient emailClient = new EmailClient(serviceConnectionString);
                        var subject = "Package Pending for Pickup at Amarillo Apartments";
                        var emailContent = new EmailContent(subject);
                        // use Multiline String @ to design html content
                        emailContent.Html = @"
                        <html>
                            <body>
                                <h1>We have recieved a package in the office for you.</h1>
                                <h4>Due to limited storing space you will have 5 days to pick up your package.
                                If you fail to pick up your package within 5 days, it will be returned.</h4>
                                <br>
                                <p>Thank you!</p>
                            </body>
                        </html>";

                        // mailfrom domain of your email service on Azure
                        var sender = "DoNotReply@18c47f2b-b626-4f60-8704-52dfbf265510.azurecomm.net";


                        /*string? inputEmail = resident_email;
                        var emailRecipients = new EmailRecipients(new List<EmailAddress> {
                            new EmailAddress(inputEmail) { DisplayName = "Testing" },
                        });

                        var emailMessage = new EmailMessage(sender, emailContent, emailRecipients);

                        try
                        {
                            SendEmailResult sendEmailResult = emailClient.Send(emailMessage);

                            string messageId = sendEmailResult.MessageId;
                            if (!string.IsNullOrEmpty(messageId))
                            {
                                Console.WriteLine($"Email sent, MessageId = {messageId}");
                            }
                            else
                            {
                                Console.WriteLine($"Failed to send email.");
                                return;
                            }
                            // wait max 2 minutes to check the send status for mail.
                            var cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(2));
                            do
                            {
                                SendStatusResult sendStatus = emailClient.GetSendStatus(messageId);
                                Console.WriteLine($"Send mail status for MessageId : <{messageId}>, Status: [{sendStatus.Status}]");

                                if (sendStatus.Status != SendStatus.Queued)
                                {
                                    break;
                                }
                                //await Task.Delay(TimeSpan.FromSeconds(10));

                            } while (!cancellationToken.IsCancellationRequested);

                            if (cancellationToken.IsCancellationRequested)
                            {
                                Console.WriteLine($"Looks like we timed out for email");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error in sending email, {ex}");
                        }*/

                        break;
                    // process unknown package
                    case 2:
                        Console.WriteLine("Input Package Name Listed:");
                        string? packageName = Console.ReadLine();
                        Console.WriteLine("Address:");
                        string? packageAddress = Console.ReadLine();
                        Console.WriteLine("Input service: (Fedex, USPS, etc.)");
                        string? packageService = Console.ReadLine();
                        database.UnknownPackage(packageName, packageAddress, packageService);
                        break;
                    // package history
                    case 3:
                        Console.WriteLine("To Be Implemented");
                        break;
                    // Log Out
                    case 4:
                        _continue = false;
                        Console.WriteLine("Log out, Goodbye.");
                        break;
                    // default: wrong input
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }

            }
        }
        else{
                Console.WriteLine("Login Failed, Goodbye.");
        }        
    }    
}
