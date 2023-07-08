using UnityEngine;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

public class SendMailController : MonoBehaviour
{
    public static async Task Execute(
        string toEmail,
        string subjectText,
        string contentText,
        string verifyCodeText
    )
    {
        var apiKey = "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";
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("spacerealmsgame@gmail.com", "Space Realms Team");
        var subject = subjectText;
        var to = new EmailAddress(toEmail, "Ruler Of The REALMS");
        var plainTextContent = "Hi, Ruler Of The REALM!";
        var htmlContent =
            plainTextContent
            + "<br>"
            + "<br>"
            + contentText
            + "<br>"
            + "<br>"
            + "<strong>"
            + verifyCodeText
            + "</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
        Debug.Log(response);
    }
}
