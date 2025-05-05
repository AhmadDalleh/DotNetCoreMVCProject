using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace DotNetCoreMVCProject.Models
{
    [NotMapped]
    public class MdlQrCoder
    {
        public int QrCodeType { get; set; }

        public string? ImageUrl { get; set; }

        public string? SMSPhoneNumber {  get; set; }
        public string? SMSBody { get; set; }

        public string? WhatsAppNumber {  get; set; }

        public string? WhatsAppMessage {  get; set; }


        public string? Email { get; set; }
        public string? EmailSubject { get; set; }

        public string? EmailBody {  get; set; }

        public string? Wi_fiName {  get; set; }

        public string? Wi_fiPassword {  get; set; }

        public string? QrImageUrl { get; set; }
    }
}

