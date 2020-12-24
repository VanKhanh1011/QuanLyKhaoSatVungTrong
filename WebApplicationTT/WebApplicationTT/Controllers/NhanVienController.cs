using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class NhanVienController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/NhanVien
        public IEnumerable<dynamic> GetNhanVien()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.NHANVIENs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaNV = item.MaNV,
                    Ten = item.Ten,
                    SDT =item.SDT,
                    GhiChu=item.GhiChu,
                    TT=item.TT,
                    MatKhau=item.MatKhau,
                    Email=item.Email
                });
            }
            return listSP;

        }

        // GET: api/NhanVien/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.NHANVIENs.FirstOrDefault(e => e.MaNV == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NhanVien with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var NhanVien = new NHANVIEN
                        {
                            MaNV = Convert.ToInt32(entity.MaNV),
                            Ten = entity.Ten,
                            SDT = entity.SDT,
                            GhiChu = entity.GhiChu,
                            TT = entity.TT,
                            MatKhau =entity.MatKhau,
                            Email = entity.Email
             
                        };
                        return Request.CreateResponse(HttpStatusCode.OK, NhanVien);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        // POST: api/NhanVien
        public HttpResponseMessage Post([FromBody]NHANVIEN nhanvien)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.NHANVIENs.Add(nhanvien);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, nhanvien);
                    message.Headers.Location = new Uri(Request.RequestUri + nhanvien.MaNV.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/NhanVien/5
        public HttpResponseMessage Put(int id, [FromBody]NHANVIEN nhanvien)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.NHANVIENs.FirstOrDefault(e => e.MaNV == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nhan Vien with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {



                        entity.MaNV = Convert.ToInt32(nhanvien.MaNV);
                        entity.Ten = nhanvien.Ten;
                        entity.GhiChu = nhanvien.GhiChu;
                        entity.TT = nhanvien.TT;
                        entity.SDT = nhanvien.SDT;
                        entity.MatKhau = nhanvien.MatKhau;
                        entity.Email = nhanvien.Email;
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

        // DELETE: api/NhanVien/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.NHANVIENs.FirstOrDefault(e => e.MaNV == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nhan Vien  with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                    var query = (from prods in db.DOTKHAOSATs where prods.MaDot == id select prods).ToList();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            db.DOTKHAOSATs.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    db.NHANVIENs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
