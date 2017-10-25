using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Controllers.API
{
    public class CouponsControllerTest : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/Coupons
        public IQueryable<Coupon> GetCoupons()
        {
            return _db.Coupons;
        }

        // GET: api/Coupons/5
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult GetCoupon(int id)
        {
            var coupon = _db.Coupons.Find(id);

            if (coupon == null)
            {
                return NotFound();
            }

            return Ok(coupon);
        }

        // PUT: api/Coupons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoupon(int id, Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupon.Id)
            {
                return BadRequest();
            }

            _db.Entry(coupon).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(id))
                    return NotFound();  
               
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Coupons
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult PostCoupon(Coupon coupon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            _db.Coupons.Add(coupon);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coupon.Id }, coupon);
        }

        // DELETE: api/Coupons/5
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult DeleteCoupon(int id)
        {
            var coupon = _db.Coupons.Find(id);

            if (coupon == null)
                return NotFound();
            

            _db.Coupons.Remove(coupon);
            _db.SaveChanges();

            return Ok(coupon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
            
            base.Dispose(disposing);
        }

        private bool CouponExists(int id)
        {
            return _db.Coupons.Count(e => e.Id == id) > 0;
        }
    }
}