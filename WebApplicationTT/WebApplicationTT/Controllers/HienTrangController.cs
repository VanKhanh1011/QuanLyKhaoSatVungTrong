using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class HienTrangController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/HienTrang
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.HIENTRANGs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaHT = item.MaHT,
                    NangSuat = item.NangSuat,
                    SoLuongCay=item.SoLuongCay,
                   TiLe = item.TiLe,
                    GhiChu = item.GhiChu,
                    TT = item.TT,
                    CayTrong= (from VUON in db.VUONs where item.MaHT == VUON.MaVuon select VUON.CAYTRONG.Loai).ToList()

                });
            }
            return listSP;

        }

        // GET: api/HienTrang/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.HIENTRANGs.FirstOrDefault(e => e.MaHT == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "He Thong Tuoi with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var HT = new Object();
                        HT = new
                        {
                            MaHT = entity.MaHT,
                            NangSuat = entity.NangSuat,
                            SoLuongCay = entity.SoLuongCay,
                            TiLe = entity.TiLe,
                            GhiChu = entity.GhiChu,
                            TT = entity.TT,
                            CayTrong = (from VUON in db.VUONs where entity.MaHT == VUON.MaVuon select VUON.CAYTRONG.Loai).ToList()
                        };
                        return Request.CreateResponse(HttpStatusCode.OK, HT);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/HienTrang
        public HttpResponseMessage Post([FromBody]HIENTRANG hientrang)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.HIENTRANGs.Add(hientrang);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, hientrang);
                    message.Headers.Location = new Uri(Request.RequestUri + hientrang.MaHT.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        // PUT: api/HienTrang/5
        public HttpResponseMessage Put(int id, [FromBody]HIENTRANG hientrang)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.HIENTRANGs.FirstOrDefault(e => e.MaHT == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hien Trang with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.MaHT = Convert.ToInt32(hientrang.MaHT);
                        entity.NangSuat = hientrang.NangSuat;
                        entity.SoLuongCay = hientrang.SoLuongCay;
                        entity.TiLe = hientrang.TiLe;
                        entity.GhiChu = hientrang.GhiChu;
                        entity.TT = hientrang.TT;
                     

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

        // DELETE: api/HienTrang/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.HIENTRANGs.FirstOrDefault(e => e.MaHT == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hien Trang with id=" + id.ToString() + "not found to delete");
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
                    db.HIENTRANGs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
