using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class KiemSoatCoController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/KiemSoatCo
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.KIEMSOATCOes select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaKSC = item.MaKSC,
                    PhuongPhap = item.PhuongPhap,
                    GhiChu = item.GhiChu,
                    MaKT = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where item.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.MaKT).ToList()

                });
            }
            return listSP;

        }

        // GET: api/KiemSoatCo/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.KIEMSOATCOes.FirstOrDefault(e => e.MaKSC == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kiem Soat Co with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var KSC = new Object();
                        KSC = new
                        {
                            MaKSC = entity.MaKSC,
                            PhuongPhap = entity.PhuongPhap,
                            GhiChu = entity.GhiChu,
                            MaKT = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where entity.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.MaKT).ToList()

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, KSC);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/KiemSoatCo
        public HttpResponseMessage Post([FromBody]KIEMSOATCO kiemsoatco)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.KIEMSOATCOes.Add(kiemsoatco);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, kiemsoatco);
                    message.Headers.Location = new Uri(Request.RequestUri + kiemsoatco.MaKSC.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/KiemSoatCo/5
        public HttpResponseMessage Put(int id, [FromBody]KIEMSOATCO kiemsoatco)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.KIEMSOATCOes.FirstOrDefault(e => e.MaKSC == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kiem Soat Co with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.MaKSC = Convert.ToInt32(kiemsoatco.MaKSC);
                        entity.PhuongPhap = kiemsoatco.PhuongPhap;
                        entity.GhiChu = kiemsoatco.GhiChu;
                        entity.MaKT = kiemsoatco.MaKT;
                       

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

        // DELETE: api/KiemSoatCo/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.KIEMSOATCOes.FirstOrDefault(e => e.MaKSC == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kiem Soat Co with id=" + id.ToString() + "not found to delete");
                }
                else
                {

                    db.KIEMSOATCOes.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
