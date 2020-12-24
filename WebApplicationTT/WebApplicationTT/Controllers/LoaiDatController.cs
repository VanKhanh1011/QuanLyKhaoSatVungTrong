using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class LoaiDatController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/LoaiDat
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.LOAIDATs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaLD = item.MaLD,
                    TenLD = item.TenLD,
                    DoAm = item.DoAm,
                    DacTrung = item.DacTrung,
                    soluongLD = (from VUON in db.VUONs where item.MaLD == VUON.MaLD select VUON).Count(),


                });
            }
            return listSP;

        }

        // GET: api/LoaiDat/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.LOAIDATs.FirstOrDefault(e => e.MaLD == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Loai Dat with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var LD = new LOAIDAT
                        {
                            MaLD = entity.MaLD,
                            TenLD = entity.TenLD,
                            DoAm = entity.DoAm,
                            DacTrung = entity.DacTrung,


                        };
                        return Request.CreateResponse(HttpStatusCode.OK, LD);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        // POST: api/LoaiDat
        public HttpResponseMessage Post([FromBody]LOAIDAT loaidat)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.LOAIDATs.Add(loaidat);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, loaidat);
                    message.Headers.Location = new Uri(Request.RequestUri + loaidat.MaLD.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/LoaiDat/5
        public HttpResponseMessage Put(int id, [FromBody]LOAIDAT loaidat)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.LOAIDATs.FirstOrDefault(e => e.MaLD == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Loai Dat with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {




                        entity.MaLD= Convert.ToInt32(loaidat.MaLD);
                        entity.TenLD = loaidat.TenLD;
                        entity.DoAm = loaidat.DoAm;
                        entity.DacTrung = loaidat.DacTrung;
                    
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

        // DELETE: api/LoaiDat/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.LOAIDATs.FirstOrDefault(e => e.MaLD == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Loai Dat with id=" + id.ToString() + "not found to delete");
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
                    db.LOAIDATs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
