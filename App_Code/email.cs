using System;

using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de email
/// </summary>
class email
{
    public email()
    { }
    public string enviarMail(string emailDestino, string asunto, string contenido)
    {
        //servidorres smtp gmail smtp.gmail.com
        //smtp.live.com
        asunto = "Gracias por escribirnos muy pronto un administrador del sitio se contactará con usted <br>Respuesta:" + asunto + "<br>" + contenido + "<br>";
        try
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress("nelsonromerouteq@gmail.com");
            email.To.Add(emailDestino);
            email.Body = contenido;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;
            email.Subject = asunto;


            SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential autenticacionBasica = new NetworkCredential("nelsonromero@gmail.com", "vbrazil2014");
            SmtpClient.Credentials = autenticacionBasica;
            SmtpClient.EnableSsl = true;
            SmtpClient.Send(email);
            return "enviado";
        }
        catch (Exception ex)
        {
            return "Error en: " + ex.Message;
        }


    }

}
