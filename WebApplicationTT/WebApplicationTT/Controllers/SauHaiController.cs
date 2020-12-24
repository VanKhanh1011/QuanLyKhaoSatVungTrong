using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class SauHaiController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/SauHai
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.SAUHAIs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaSH = item.MaSH,
                    TenSH = item.TenSH,
                    GhiChu=item.GhiChu,
                    TT=item.TT,
                    MaCT = (from CAYTRONG in db.CAYTRONGs where item.MaCT == CAYTRONG.MaCT select CAYTRONG.Loai)

                });
            }
            return listSP;
        }

        // GET: api/SauHai/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.SAUHAIs.FirstOrDefault(e => e.MaSH == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sau Hai with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var SH = new Object();
                        SH = new
                        {
                            MaSH = entity.MaSH,
                            TenSH = entity.TenSH,
                            GhiChu = entity.GhiChu,
                            TT = entity.TT,
                            MaCT = (from CAYTRONG in db.CAYTRONGs where entity.MaCT == CAYTRONG.MaCT select CAYTRONG.MaCT).ToList()
                        };
                        return Request.CreateResponse(HttpStatusCode.OK, SH);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/SauHai
        public HttpResponseMessage Post([FromBody]SAUHAI sauhai)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.SAUHAIs.Add(sauhai);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, sauhai);
                    message.Headers.Location = new Uri(Request.RequestUri + sauhai.MaSH.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/SauHai/5
        public HttpResponseMessage Put(int id, [FromBody]SAUHAI sauhai)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.SAUHAIs.FirstOrDefault(e => e.MaSH == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sau Hai with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                     


                        entity.MaSH= Convert.ToInt32(sauhai.MaSH);
                        entity.TenSH = sauhai.TenSH;
                        entity.GhiChu = sauhai.GhiChu;
                        entity.TT = sauhai.TT;
                        entity.MaCT = sauhai.MaCT;
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

        // DELETE: api/SauHai/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.SAUHAIs.FirstOrDefault(e => e.MaSH == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Benh Hai with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                   
                    db.SAUHAIs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
