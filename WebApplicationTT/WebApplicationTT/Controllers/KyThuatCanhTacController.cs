using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class KyThuatCanhTacController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/KyThuatCanhTac
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.KYTHUATCANHTACs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaKT = item.MaKT,
                    KhoangCachHang = item.KhoangCachHang,
                    LenMo = item.LenMo,
                    HeThongTuoi = (from HETHONGTUOI in db.HETHONGTUOIs where item.MaKT == HETHONGTUOI.MaKT select HETHONGTUOI.PhuongThuc).ToList(),
                    KiemSoatCo = (from KIEMSOATCO in db.KIEMSOATCOes where item.MaKT == KIEMSOATCO.MaKT select KIEMSOATCO.PhuongPhap).ToList()

                });
            }
            return listSP;

        }

        // GET: api/KyThuatCanhTac/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.KYTHUATCANHTACs.FirstOrDefault(e => e.MaKT == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ky Thuat Canh Tac with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var KTCT = new Object();
                        KTCT = new
                        {
                            MaKT = entity.MaKT,
                            KhoangCachHang = entity.KhoangCachHang,
                            LenMo = entity.LenMo,
                            HeThongTuoi = (from HETHONGTUOI in db.HETHONGTUOIs where entity.MaKT == HETHONGTUOI.MaKT select HETHONGTUOI.PhuongThuc).ToList(),
                            KiemSoatCo = (from KIEMSOATCO in db.KIEMSOATCOes where entity.MaKT == KIEMSOATCO.MaKT select KIEMSOATCO.PhuongPhap).ToList()

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, KTCT);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/KyThuatCanhTac
        public HttpResponseMessage Post([FromBody]KYTHUATCANHTAC kythuatcanhtac)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.KYTHUATCANHTACs.Add(kythuatcanhtac);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, kythuatcanhtac);
                    message.Headers.Location = new Uri(Request.RequestUri + kythuatcanhtac.MaKT.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/KyThuatCanhTac/5
        public HttpResponseMessage Put(int id, [FromBody]KYTHUATCANHTAC kythuatcanhtac)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.KYTHUATCANHTACs.FirstOrDefault(e => e.MaKT == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ky Thuat Canh Tac with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.MaKT = Convert.ToInt32(kythuatcanhtac.MaKT);
                        entity.KhoangCachHang = kythuatcanhtac.KhoangCachHang;
                        entity.LenMo = kythuatcanhtac.LenMo;
                       


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

        // DELETE: api/KyThuatCanhTac/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.KYTHUATCANHTACs.FirstOrDefault(e => e.MaKT == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ky Thuat Canh Tac with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                    var query = (from prods in db.HETHONGTUOIs where prods.MaHTT == id select prods).ToList();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            db.HETHONGTUOIs.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    var query1 = (from prods in db.KIEMSOATCOes where prods.MaKSC == id select prods).ToList();
                    if (query1 != null)
                    {
                        foreach (var item in query1)
                        {
                            db.KIEMSOATCOes.Remove(item);
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

                    db.KYTHUATCANHTACs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
