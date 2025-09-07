namespace Traversal_Rezervasyon.Areas.Members.Models
{
    public class UserProfileEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string BackgroundImageURL { get; set; }
        public IFormFile Background { get; set; }
    }
}
