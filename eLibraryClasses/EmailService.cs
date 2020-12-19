using eLibraryClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace eLibraryClasses
{
    public static class EmailService
    {
        //Sending welcome email after creating a new user
        public static void SendWelcomeEmail(string to, string name)
        {
            //Receiving basic infos wrote in appsettings
            MailAddress fromMailAddress = new MailAddress(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("senderDisplayName"));

            MailMessage mail = new MailMessage();

            mail.From = fromMailAddress;

            //Creating personalized subject for mail
            mail.Subject = $"Dziękuje { name } za utworzenie konta w mojej aplikacji!";

            StringBuilder body = new StringBuilder();

            body.AppendLine("<h1> eLibrary - Twój elektroniczny zbiór </h1>");
            body.AppendLine("<p>Twoje konto zostało pomyślnie utworzone w serwisie!</p>");
            body.AppendLine("<br />");
            body.AppendLine("<p> Jeśli nie czytałeś(aś) pliku README poinformuje Cię iż: </p>");
            body.AppendLine("<p> -Jedyną kopią zapisanych danych jest plik UsersFile znajdujący się na Twoim komputerze </p>");
            body.AppendLine("<p> -Istnieje możliwość przypomnienia hasła, lecz zostanie ono wysłane wraz z loginem na Twój email w sposób niezaszyfrowany </p>");
            body.AppendLine("<p> Mam nadzieję, że analiza aplikacji będzie równie satysfakconująca co moje programowanie :) </p>");
            body.AppendLine("~Krzysztof Aniśkiewicz, +48 572 435 029");

            mail.Body = body.ToString();

            mail.IsBodyHtml = true;

            mail.To.Add(to);

            SmtpClient client = new SmtpClient();

            client.Send(mail);
        }

        //When new person uses my application and create user account, I will get information about it
        //I will not get any personal information like email address or password. 
        //Just first name and last name, just to let me know that somebody is testing my app.
        public static void SendEmailToAppCreator(string name, string surname)
        {
            MailAddress fromMailAddress = new MailAddress(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("senderDisplayName"));

            MailMessage mail = new MailMessage();

            mail.From = fromMailAddress;

            mail.Subject = $"Użytkownik { name } {surname} utworzył konto w Twojej aplikacji!";

            StringBuilder body = new StringBuilder();

            body.AppendLine("<h1> eLibrary - Twój elektroniczny zbiór </h1>");
            body.AppendLine("<p>Konto nowej osoby zostało pomyślnie utworzone w serwisie!</p>");
            body.AppendLine("<br />");
            body.AppendLine("<p> ---- </p>");

            mail.Body = body.ToString();

            mail.IsBodyHtml = true;

            mail.To.Add("krzysanisk@gmail.com");

            SmtpClient client = new SmtpClient();

            client.Send(mail);
        }

        //Sending email with password and username on demand
        public static void SendRemindEmail(string to, string name, string userName, string password)
        {
            MailAddress fromMailAddress = new MailAddress(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("senderDisplayName"));

            MailMessage mail = new MailMessage();

            mail.From = fromMailAddress;

            mail.Subject = $"{ name } oto Twoje dane do eLibrary!";

            StringBuilder body = new StringBuilder();

            body.AppendLine("<h1> eLibrary - Twój elektroniczny zbiór </h1>");
            body.AppendLine("<p>Otrzymałem żądanie przypomnienia danych do Twojego konta eLibrary!</p>");
            body.AppendLine("<br />");
            body.AppendLine($"<p> Twój login to {userName} </p>");
            body.AppendLine($"<p> Twoje hasło to {password} </p>");
            body.AppendLine("~Krzysztof Aniśkiewicz, +48 572 435 029");

            mail.Body = body.ToString();

            mail.IsBodyHtml = true;

            mail.To.Add(to);

            SmtpClient client = new SmtpClient();

            client.Send(mail);
        }
    }
}
