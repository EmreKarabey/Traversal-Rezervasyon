using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Default
{
    public class _TestimonialComponent:ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonial());
        public IViewComponentResult Invoke()
        {
            var gstr = testimonialManager.list();
            return View(gstr);
        }
    }
}
