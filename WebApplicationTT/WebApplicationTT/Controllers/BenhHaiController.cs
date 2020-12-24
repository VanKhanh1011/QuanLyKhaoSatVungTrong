using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class BenhHaiController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/BenhHai
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.BENHHAIs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaBH = item.MaBH,
                    TenBH = item.TenBH,
                    GhiChu = item.GhiChu,
                    TT = item.TT,
                    MaCT = (from CAYTRONG in db.CAYTRONGs where item.MaCT == CAYTRONG.MaCT select CAYTRONG.Loai),
                     LoaiCT = (from CAYTRONG in db.CAYTRONGs where item.MaCT == CAYTRONG.MaCT select CAYTRONG.MaCT)

                });
            }
            return listSP;
        }

        // GET: api/BenhHai/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.BENHHAIs.FirstOrDefault(e => e.MaBH == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Benh Hai with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var bh = new Object();
                        bh = new
                        {
                            MaBH = Convert.ToInt32(entity.MaBH),
                            TenBH = entity.TenBH,

                            GhiChu = entity.GhiChu,
                            TT = entity.TT,
                            MaCT = (from CAYTRONG in db.CAYTRONGs where CAYTRONG.MaCT == entity.MaCT select CAYTRONG.MaCT).ToList()
                      

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, bh);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        // POST: api/BenhHai
        public HttpResponseMessage Post([FromBody]BENHHAI benhhai)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.BENHHAIs.Add(benhhai);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, benhhai);
                    message.Headers.Location = new Uri(Request.RequestUri + benhhai.MaBH.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/BenhHai/5
        public HttpResponseMessage Put(int id, [FromBody]BENHHAI benhhai)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.BENHHAIs.FirstOrDefault(e => e.MaBH == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Benh Hai with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {



                        entity.MaBH = Convert.ToInt32(benhhai.MaBH);
                        entity.TenBH = benhhai.TenBH;
                        entity.GhiChu = benhhai.GhiChu;
                        entity.TT = benhhai.TT;
                        entity.MaCT = benhhai.MaCT;
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

        // DELETE: api/BenhHai/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.BENHHAIs.FirstOrDefault(e => e.MaBH == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Benh Hai with id=" + id.ToString() + "not found to delete");
                }
                else
                {

                    db.BENHHAIs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
