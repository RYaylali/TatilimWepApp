using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Tatilim.WebUI.Models.Mail;

namespace Tatilim.WebUI.Controllers
{
	public class AdminMailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(AdminMailVM adminMailVM)
		{
			MimeMessage mimeMessage = new MimeMessage();
			//kimden olacağı
			MailboxAddress mailboxAddressFrom = new MailboxAddress("TatilimAdmin", "1test12test212@gmail.com");//birinci gönderen kişinin adı, 2.si ise mailim
			mimeMessage.From.Add(mailboxAddressFrom);//mailboxadress den gelen ismi ve maili ekler
			//kime gideceği
			MailboxAddress mailboxAddressTo = new MailboxAddress("User" , adminMailVM.ReceiverMail);//mailin nereye gönderileceği
			mimeMessage.To.Add(mailboxAddressTo);
			//mesaj içeriği
			var bodyBuilder= new BodyBuilder();
			bodyBuilder.TextBody = adminMailVM.Body;
			mimeMessage.Body=bodyBuilder.ToMessageBody();
			//mWAjın bŞLIĞI 
			mimeMessage.Subject = adminMailVM.Subject;
			//manager packet olarak indirdiğimiz mailkit ile bağlantı kurmamızı sağlar
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);//bağlantı maili, portu ve token üretme durumunu belirler
			client.Authenticate("", "");//Maili gönderecek adresden alınan key ve adresin kendisini yazmam gerek ve çalışması 2 adımlı doğrulamayı açmalısın
			client.Send(mimeMessage);
			client.Disconnect(true); 
			return View();
		}
	}
}
