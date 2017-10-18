using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Controllers.API
{
    public class CouponsControllerTest : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Coupons
        public IQueryable<Coupon> GetCoupons()
        {
            return db.Coupons;
        }

        // GET: api/Coupons/5
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult GetCoupon(int id)
        {
            Coupon coupon = db.Coupons.Find(id);
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

            db.Entry(coupon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Coupons
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult PostCoupon(Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupons.Add(coupon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coupon.Id }, coupon);
        }

        // DELETE: api/Coupons/5
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult DeleteCoupon(int id)
        {
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return NotFound();
            }

            db.Coupons.Remove(coupon);
            db.SaveChanges();

            return Ok(coupon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CouponExists(int id)
        {
            return db.Coupons.Count(e => e.Id == id) > 0;
        }
    }
}