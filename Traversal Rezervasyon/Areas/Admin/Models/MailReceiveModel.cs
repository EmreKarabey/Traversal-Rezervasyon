namespace Traversal_Rezervasyon.Areas.Admin.Models
{
    public class MailReceiveModel
    {
        public string Name { get; set; }

        public string SenderEmail { get; set; }
        public string ReceieverEmail { get; set; }

        public string MessageBody { get; set; }
        public string Subject { get; set; }
    }
}
