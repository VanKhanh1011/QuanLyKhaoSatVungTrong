using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
  
    public class CayTrongController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/CayTrong
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.CAYTRONGs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaCT = item.MaCT,
                    Loai = item.Loai,
                    Giong = item.Giong,
                    Tuoi = item.Tuoi,
                    MoTa = item.MoTa,
                    TT = item.TT,
                    BH = (from BENHHAI in db.BENHHAIs where item.MaCT == BENHHAI.MaCT select BENHHAI.TenBH).ToList(),
                    SH = (from SAUHAI in db.SAUHAIs where item.MaCT == SAUHAI.MaCT select SAUHAI.TenSH).ToList(),
                    soluong=(from SAUHAI in db.SAUHAIs where item.MaCT==SAUHAI.MaCT select SAUHAI).Count(),
                    soluongBH= (from BENHHAI in db.BENHHAIs where item.MaCT == BENHHAI.MaCT select BENHHAI).Count(),
                    soluongVuon = (from VUON in db.VUONs where item.MaCT == VUON.MaCT select VUON).Count()
                });
            }
            return listSP;

        }

        // GET: api/CayTrong/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.CAYTRONGs.FirstOrDefault(e => e.MaCT == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cay Trong with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var CayTrong = new CAYTRONG
                        {
                            MaCT = Convert.ToInt32(entity.MaCT),
                            Loai = entity.Loai,
                            Giong = entity.Giong,
                            Tuoi = entity.Tuoi,
                            MoTa = entity.MoTa,
                            TT = entity.TT,
                        
                        };
                        return Request.CreateResponse(HttpStatusCode.OK, CayTrong);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/CayTrong
        public HttpResponseMessage Post([FromBody]CAYTRONG caytrong)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.CAYTRONGs.Add(caytrong);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, caytrong);
                    message.Headers.Location = new Uri(Request.RequestUri + caytrong.MaCT.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/CayTrong/5
        public HttpResponseMessage Put(int id, [FromBody]CAYTRONG caytrong)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.CAYTRONGs.FirstOrDefault(e => e.MaCT == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nhan Vien with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {



                        entity.MaCT = Convert.ToInt32(caytrong.MaCT);
                        entity.Loai = caytrong.Loai;
                        entity.Giong = caytrong.Giong;
                        entity.TT =caytrong.TT;
                        entity.Tuoi = caytrong.Tuoi;
                        entity.MoTa = caytrong.MoTa;
                     
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

        // DELETE: api/CayTrong/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.CAYTRONGs.FirstOrDefault(e => e.MaCT == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cay Trong  with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                    var query = (from prods in db.BENHHAIs where prods.MaBH == id select prods).ToList();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            db.BENHHAIs.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    var query1 = (from prods in db.SAUHAIs where prods.MaSH == id select prods).ToList();
                    if (query1 != null)
                    {
                        foreach (var item in query1)
                        {
                            db.SAUHAIs.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    var query2 = (from prods in db.VUONs where prods.MaVuon == id select prods).ToList();
                    if (query2 != null)
                    {
                        foreach (var item in query2)
                        {
                            db.VUONs.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    db.CAYTRONGs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
