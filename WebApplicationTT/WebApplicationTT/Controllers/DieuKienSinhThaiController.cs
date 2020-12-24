using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class DieuKienSinhThaiController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/DieuKienSinhThai
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.DIEUKIENSINHTHAIs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                   MaDKST= item.MaDKST,
                   Mua = item.Mua,
                   NhietDoMuaNang = item.NhietDoMuaNang,
                   SuongMuoi = item.SuongMuoi,
                    Gio = item.Gio,
                    Lu = item.Lu,
                    TrieuCuong = item.TrieuCuong,
                    DoPH = item.DoPH,
                });
            }
            return listSP;

        }

        // GET: api/DieuKienSinhThai/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.DIEUKIENSINHTHAIs.FirstOrDefault(e => e.MaDKST == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dieu Kien Sinh Thai with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var DieuKienSinhThai = new DIEUKIENSINHTHAI
                        {
                            MaDKST = Convert.ToInt32(entity.MaDKST),
                            Mua = entity.Mua,
                            NhietDoMuaNang = entity.NhietDoMuaNang,
                            SuongMuoi = entity.SuongMuoi,
                            Gio = entity.Gio,
                            Lu = entity.Lu,
                            TrieuCuong = entity.TrieuCuong,
                               DoPH = entity.DoPH,
                        };
                        return Request.CreateResponse(HttpStatusCode.OK, DieuKienSinhThai);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/DieuKienSinhThai
        public HttpResponseMessage Post([FromBody]DIEUKIENSINHTHAI dieukiensinhthai)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.DIEUKIENSINHTHAIs.Add(dieukiensinhthai);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, dieukiensinhthai);
                    message.Headers.Location = new Uri(Request.RequestUri + dieukiensinhthai.MaDKST.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/DieuKienSinhThai/5
        public HttpResponseMessage Put(int id, [FromBody]DIEUKIENSINHTHAI dieukiensinhthai)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.DIEUKIENSINHTHAIs.FirstOrDefault(e => e.MaDKST == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dieu Kien Sinh Thai with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {

                        entity.MaDKST = Convert.ToInt32(dieukiensinhthai.MaDKST);
                        entity.Mua = dieukiensinhthai.Mua;
                        entity.NhietDoMuaNang = dieukiensinhthai.NhietDoMuaNang;
                        entity.SuongMuoi = dieukiensinhthai.SuongMuoi;
                        entity.Gio = dieukiensinhthai.Gio;
                        entity.Lu = dieukiensinhthai.Lu;
                        entity.TrieuCuong = dieukiensinhthai.TrieuCuong;
                        entity.DoPH = dieukiensinhthai.DoPH;

                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // DELETE: api/DieuKienSinhThai/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.DIEUKIENSINHTHAIs.FirstOrDefault(e => e.MaDKST == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dieu Kien Sinh Thai with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                    var query2 = (from prods in db.VUONs where prods.MaVuon == id select prods).ToList();
                    if (query2 != null)
                    {
                        foreach (var item in query2)
                        {
                            db.VUONs.Remove(item);
                            db.SaveChanges();
                        }
                    }

                    db.DIEUKIENSINHTHAIs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
