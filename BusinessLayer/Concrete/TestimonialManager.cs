using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialServices
    {
        private readonly ITestimonial _ITestimonial;

        public TestimonialManager(ITestimonial testimonial)
        {
            _ITestimonial = testimonial;
        }
        public void Add(Testimonial t)
        {
            _ITestimonial.Add(t);
        }

        public void Delete(Testimonial t)
        {
            _ITestimonial.Delete(t);
        }

        public Testimonial GetById(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> list()
        {
            var gstr = _ITestimonial.list();

            return gstr;
        }

        public void Update(Testimonial t)
        {
            _ITestimonial.Update(t);
        }
    }
}
