namespace Traversal_Rezervasyon.Areas.Admin.Models
{
    public class AddGuideModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string TwitterURL { get; set; }

        public string InstagramURL { get; set; }

        public string ImageURL { get; set; }

        public IFormFile Image { get; set; }
        public bool Status { get; set; }
    }
}
