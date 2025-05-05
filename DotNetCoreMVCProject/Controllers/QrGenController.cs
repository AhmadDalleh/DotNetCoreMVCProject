using DotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace DotNetCoreMVCProject.Controllers
{
    public class QrGenController : Controller
    {


        public IActionResult Index()
        {
            MdlQrCoder mdl = new MdlQrCoder();
            return View(mdl);
        }

        //Post
        [HttpPost]
        public IActionResult Index(MdlQrCoder mdl)
        {
            Payload? payload = null;

            switch (mdl.QrCodeType)
            {
                case 1://Url
                    payload = new Url(mdl.ImageUrl ?? "");
                    break;
                case 2://Sms
                    payload = new SMS(mdl.SMSPhoneNumber!, mdl.SMSBody!);
                    break;
                case 3://Whatsapp
                    payload = new WhatsAppMessage(mdl.WhatsAppNumber!,mdl.WhatsAppMessage!);
                    break;
                case 4://mail
                    payload = new Mail(mdl.Email!,mdl.EmailSubject!,mdl.EmailBody!);
                    break;
                case 5://wifi
                    payload = new WiFi(mdl.Wi_fiName!, mdl.Wi_fiPassword!,WiFi.Authentication.WPA);
                    break;

            }

            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(payload);

            BitmapByteQRCode qRCode = new BitmapByteQRCode(qRCodeData);

            string base64String = Convert.ToBase64String(qRCode.GetGraphic(20));
            mdl.QrImageUrl = "data:image/png;base64," + base64String;

            return View("index", mdl);
        }
    }
}
