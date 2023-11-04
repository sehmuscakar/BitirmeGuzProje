using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PresentationLayer.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostContactManager _postContactManager;
        private readonly IBookingManager _bookingManager;

        public HomeController(IPostContactManager postContactManager, IBookingManager bookingManager)
        {
            _postContactManager = postContactManager;
            _bookingManager = bookingManager;
        }

        public IActionResult Anasayfa()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(PostContact postContact)
        {


            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Web'ten Mesajınız", "scakar542@gmail.com");//kimden geleceği isim ve mail

            mimeMessage.From.Add(mailboxAddressFrom);//kimden gelecek ekle
                                                     //alacak olan kişin bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", postContact.Mail);//kime gideği isim ve adres

            mimeMessage.To.Add(mailboxAddressTo);//kime gidecek ekle

            //  mimeMessage.Subject = contact.Subject;// bu direk mail başlığında yazar
            mimeMessage.Subject = "Çiftlikköy Restaurant";// bu direk mail başlığında yazar

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Gönderen Adı: " + postContact.Name + "***" + "Konu: " + postContact.Subject + "***" + "Gönderilen Mesaj: " + postContact.Message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();   //mesaja ekle body kısmına 

            //mimeMessage.Subject = "Easy Cash Onay Kodu";//konu kısmı

            SmtpClient client = new SmtpClient();// mail trnsfer nesne örneği protokol
            client.Connect("smtp.gmail.com", 587, false);//prokol gereklikleri bağlantı kurma ,burda bağlatı güvenliğine false dedik çünkü ConfirmMailController da true işlemi yapacaz emailconfirmed

            client.Authenticate("scakar542@gmail.com", "ayny upod zimi yote");//mail ve mailde oluşturduğun güvenlik kodu,bunu her bir ayrı projede ayrı al bu güvenlik kodunu mail üzerinden bazı işlmlerle alırsın
            client.Send(mimeMessage);//gönder
            client.Disconnect(true);//gövenli çıkış yap 
                                    //bu işlemi yapman için iki adımlı doğrulamyı mail de açman lazım
            _postContactManager.Add(postContact);
            return View();
        }

        public async Task<IActionResult> Booking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Booking(Booking booking)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Rezervasyon Bilgileri", "scakar542@gmail.com");//kimden geleceği isim ve mail

            mimeMessage.From.Add(mailboxAddressFrom);//kimden gelecek ekle
                                                     //alacak olan kişin bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", booking.Mail);//kime gideği isim ve adres

            mimeMessage.To.Add(mailboxAddressTo);//kime gidecek ekle

            //  mimeMessage.Subject = contact.Subject;// bu direk mail başlığında yazar
            mimeMessage.Subject = "Çiftlikköy Restaurant";// bu direk mail başlığında yazar

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Gönderen Adı: " +booking.Name + "***" + "Telefon: " + booking.Phone + "***" + "Kişi Sayısı: " + booking.PeopleCount + "***" +"Rezervasyon Tarihi: " + booking.Time;
            mimeMessage.Body = bodyBuilder.ToMessageBody();   //mesaja ekle body kısmına 

            //mimeMessage.Subject = "Easy Cash Onay Kodu";//konu kısmı

            SmtpClient client = new SmtpClient();// mail trnsfer nesne örneği protokol
            client.Connect("smtp.gmail.com", 587, false);//prokol gereklikleri bağlantı kurma ,burda bağlatı güvenliğine false dedik çünkü ConfirmMailController da true işlemi yapacaz emailconfirmed

            client.Authenticate("scakar542@gmail.com", "ayny upod zimi yote");//mail ve mailde oluşturduğun güvenlik kodu,bunu her bir ayrı projede ayrı al bu güvenlik kodunu mail üzerinden bazı işlmlerle alırsın
            client.Send(mimeMessage);//gönder
            client.Disconnect(true);//gövenli çıkış yap 
                                    //bu işlemi yapman için iki adımlı doğrulamyı mail de açman lazım
           _bookingManager.Add(booking);
            return View();
        }

    }
}