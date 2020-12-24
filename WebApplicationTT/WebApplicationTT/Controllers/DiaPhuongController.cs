using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class DiaPhuongController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/DiaPhuong
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.DIAPHUONGs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaDP = item.MaDP,
                    Tinh = item.Tinh,
                    Huyen = item.Huyen,
                    Xa = item.Xa,
                    Ap = item.Ap,
                    soluongVuon = (from VUON in db.VUONs where item.MaDP == VUON.MaDP select VUON).Count()

                });
            }
            return listSP;

        }

        // GET: api/DiaPhuong/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.DIAPHUONGs.FirstOrDefault(e => e.MaDP == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dia Phuong with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var DiaPhuong = new DIAPHUONG
                        {
                            MaDP = Convert.ToInt32(entity.MaDP),
                            Tinh = entity.Tinh,
                            Huyen = entity.Huyen,
                            Xa = entity.Xa,
                            Ap = entity.Ap,


                        };
                        return Request.CreateResponse(HttpStatusCode.OK, DiaPhuong);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/DiaPhuong
        public HttpResponseMessage Post([FromBody]DIAPHUONG diaphuong)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.DIAPHUONGs.Add(diaphuong);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, diaphuong);
                    message.Headers.Location = new Uri(Request.RequestUri + diaphuong.MaDP.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/DiaPhuong/5
        public HttpResponseMessage Put(int id, [FromBody]DIAPHUONG diaphuong)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.DIAPHUONGs.FirstOrDefault(e => e.MaDP == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dia Phuong with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {

                   
                 

                        entity.MaDP = Convert.ToInt32(diaphuong.MaDP);
                        entity.Tinh = diaphuong.Tinh;
                        entity.Huyen =diaphuong.Huyen;
                        entity.Xa = diaphuong.Xa;
                        entity.Ap = diaphuong.Ap;
                      
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

        // DELETE: api/DiaPhuong/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.DIAPHUONGs.FirstOrDefault(e => e.MaDP == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dia Phuong  with id=" + id.ToString() + "not found to delete");
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
                    db.DIAPHUONGs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
