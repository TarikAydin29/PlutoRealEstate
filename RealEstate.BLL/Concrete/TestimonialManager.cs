using RealEstate.BLL.Abstract;
using RealEstate.DAL.Abstract;
using RealEstate.Entities.Entities;

namespace RealEstate.BLL.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }
        public Task<Testimonial> TInsertAsync(Testimonial entity)
        {
            return _testimonialDal.InsertAsync(entity);
        }
        public void TDelete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }
        public Task<Guid> TUpdateAsync(Testimonial entity)
        {
            return _testimonialDal.UpdateAsync(entity);
        }

        public Task<List<Testimonial>> TGetAllAsync()
        {
            return _testimonialDal.GetAllAsync();
        }

        public Task<Testimonial> TGetByIdAsync(Guid Id)
        {
            return _testimonialDal.GetByIdAsync(Id);
        }

        public Task<int> TSaveAsync()
        {
            return (_testimonialDal.SaveAsync());
        }
    }
}
