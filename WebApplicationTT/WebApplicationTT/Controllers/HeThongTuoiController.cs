using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class HeThongTuoiController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/HeThongTuoi
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.HETHONGTUOIs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaHTT = item.MaHTT,
                    PhuongThuc = item.PhuongThuc,
                    NguonNuoc = item.NguonNuoc,
                    MaKT = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where item.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.MaKT).ToList()

                });
            }
            return listSP;

        }

        // GET: api/HeThongTuoi/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.HETHONGTUOIs.FirstOrDefault(e => e.MaHTT == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "He Thong Tuoi with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var HTT = new Object();
                        HTT = new
                        {
                            MaHTT = Convert.ToInt32(entity.MaHTT),
                            PhuongThuc = entity.PhuongThuc,
                            NguonNuoc = entity.NguonNuoc,
                            MaKT = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where entity.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.MaKT).ToList()

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, HTT);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/HeThongTuoi
        public HttpResponseMessage Post([FromBody]HETHONGTUOI hethongtuoi)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.HETHONGTUOIs.Add(hethongtuoi);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, hethongtuoi);
                    message.Headers.Location = new Uri(Request.RequestUri + hethongtuoi.MaHTT.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/HeThongTuoi/5
        public HttpResponseMessage Put(int id, [FromBody]HETHONGTUOI hethongtuoi)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.HETHONGTUOIs.FirstOrDefault(e => e.MaHTT == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "He Thong Tuoi with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.MaHTT = Convert.ToInt32(hethongtuoi.MaHTT);
                        entity.PhuongThuc = hethongtuoi.PhuongThuc;
                        entity.NguonNuoc=hethongtuoi.NguonNuoc;
                        entity.MaKT = hethongtuoi.MaKT;


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


        // DELETE: api/HeThongTuoi/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.HETHONGTUOIs.FirstOrDefault(e => e.MaHTT == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "He Thong Tuoi with id=" + id.ToString() + "not found to delete");
                }
                else
                {

                    db.HETHONGTUOIs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
