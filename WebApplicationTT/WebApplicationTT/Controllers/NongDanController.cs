using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class NongDanController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/NongDan
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.NONGDANs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaND = item.MaND,
                    HoTen = item.HoTen,
                    SDT = item.SDT,
                    Email = item.Email,
                    DiaChi = item.DiaChi,
                    MongMuon =item.MongMuon,
                    MatKhau =item.MatKhau,
                    Vuon  = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaND == QUYENSOHUU.MaND select QUYENSOHUU.VUON.TenVuon).ToList(),
                   
                });
            }
            return listSP;

        }

        // GET: api/NongDan/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.NONGDANs.FirstOrDefault(e => e.MaND == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nong Dan with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var ND = new Object();
                        ND = new
                        {
                            MaND = entity.MaND,
                            HoTen = entity.HoTen,
                            SDT = entity.SDT,
                            Email = entity.Email,
                            DiaChi = entity.DiaChi,
                            MongMuon = entity.MongMuon,
                            MatKhau = entity.MatKhau,
                            Vuon = (from QUYENSOHUU in db.QUYENSOHUUs where entity.MaND == QUYENSOHUU.MaND select QUYENSOHUU.VUON.TenVuon).ToList(),

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, ND);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/NongDan
        public HttpResponseMessage Post([FromBody]NONGDAN nongdan)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.NONGDANs.Add(nongdan);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, nongdan);
                    message.Headers.Location = new Uri(Request.RequestUri + nongdan.MaND.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/NongDan/5
        public HttpResponseMessage Put(int id, [FromBody]NONGDAN nongdan)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.NONGDANs.FirstOrDefault(e => e.MaND == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nong Dan with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {

                        entity.MaND = Convert.ToInt32(nongdan.MaND);
                        entity.HoTen = nongdan.HoTen;
                        entity.SDT = nongdan.SDT;
                        entity.Email = nongdan.Email;
                        entity.DiaChi = nongdan.DiaChi;
                        entity.MongMuon = nongdan.MongMuon;
                        entity.MatKhau = nongdan.MatKhau;
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

        // DELETE: api/NongDan/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.NONGDANs.FirstOrDefault(e => e.MaND == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nong Dan  with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                    var query2 = (from prods in db.QUYENSOHUUs where prods.MaDot == id select prods).ToList();
                    if (query2 != null)
                    {
                        foreach (var item in query2)
                        {
                            db.QUYENSOHUUs.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    db.NONGDANs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
