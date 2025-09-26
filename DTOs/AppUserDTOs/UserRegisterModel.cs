using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DTOs.AppUserDTOs
{
    public class UserRegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ComparePassword { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string BackgroundImageURL { get; set; }
        public IFormFile BackgroundImage { get; set; }
    }
}
