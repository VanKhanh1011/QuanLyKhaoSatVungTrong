using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class VuonController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/Vuon
        public IEnumerable<dynamic> Get()
        {

            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.VUONs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaVuon = item.MaVuon,
                    TenVuon = item.TenVuon,
                    MaKT = item.MaKT,
                    MaDKST = item.MaDKST,
                    MaCT = (from CAYTRONG in db.CAYTRONGs where item.MaCT == CAYTRONG.MaCT select CAYTRONG.MaCT).ToList(),
                    MaLD = (from LOAIDAT in db.LOAIDATs where item.MaLD == LOAIDAT.MaLD select LOAIDAT.MaLD).ToList(),
                    MaHT = (from HIENTRANG in db.HIENTRANGs where item.MaHT == HIENTRANG.MaHT select HIENTRANG.MaHT).ToList(),
                    MaDP = (from DIAPHUONG in db.DIAPHUONGs where item.MaDP == DIAPHUONG.MaDP select DIAPHUONG.MaDP).ToList(),
                    Tinh = (from DIAPHUONG in db.DIAPHUONGs where item.MaDP == DIAPHUONG.MaDP select DIAPHUONG.Tinh).ToList(),
                    Huyen = (from DIAPHUONG in db.DIAPHUONGs where item.MaDP == DIAPHUONG.MaDP select DIAPHUONG.Huyen).ToList(),
                    Xa = (from DIAPHUONG in db.DIAPHUONGs where item.MaDP == DIAPHUONG.MaDP select DIAPHUONG.Xa).ToList(),
                    Ap = (from DIAPHUONG in db.DIAPHUONGs where item.MaDP == DIAPHUONG.MaDP select DIAPHUONG.Ap).ToList().ToList(),
                    TenLD= (from LOAIDAT in db.LOAIDATs where item.MaLD == LOAIDAT.MaLD select LOAIDAT.TenLD).ToList(),
                    DoAm= (from LOAIDAT in db.LOAIDATs where item.MaLD == LOAIDAT.MaLD select LOAIDAT.DoAm).ToList(),
                    DacTrung= (from LOAIDAT in db.LOAIDATs where item.MaLD == LOAIDAT.MaLD select LOAIDAT.DacTrung).ToList(),
                    SoLuongCay= (from HIENTRANG in db.HIENTRANGs where item.MaHT == HIENTRANG.MaHT select HIENTRANG.SoLuongCay).ToList(),
                    NangSuat= (from HIENTRANG in db.HIENTRANGs where item.MaHT == HIENTRANG.MaHT select HIENTRANG.NangSuat).ToList(),
                    TiLe= (from HIENTRANG in db.HIENTRANGs where item.MaHT == HIENTRANG.MaHT select HIENTRANG.TiLe).ToList(),
                    Mua= (from DIEUKIENSINHTHAI in db.DIEUKIENSINHTHAIs where item.MaDKST == DIEUKIENSINHTHAI.MaDKST select DIEUKIENSINHTHAI.Mua).ToList(),
                    NhietDoMuaNang = (from DIEUKIENSINHTHAI in db.DIEUKIENSINHTHAIs where item.MaDKST == DIEUKIENSINHTHAI.MaDKST select DIEUKIENSINHTHAI.NhietDoMuaNang).ToList(),
                    Gio = (from DIEUKIENSINHTHAI in db.DIEUKIENSINHTHAIs where item.MaDKST == DIEUKIENSINHTHAI.MaDKST select DIEUKIENSINHTHAI.Gio).ToList(),
                    Lu = (from DIEUKIENSINHTHAI in db.DIEUKIENSINHTHAIs where item.MaDKST == DIEUKIENSINHTHAI.MaDKST select DIEUKIENSINHTHAI.Lu).ToList(),
                    TrieuCuong = (from DIEUKIENSINHTHAI in db.DIEUKIENSINHTHAIs where item.MaDKST == DIEUKIENSINHTHAI.MaDKST select DIEUKIENSINHTHAI.TrieuCuong).ToList(),
                    DoPH = (from DIEUKIENSINHTHAI in db.DIEUKIENSINHTHAIs where item.MaDKST == DIEUKIENSINHTHAI.MaDKST select DIEUKIENSINHTHAI.DoPH).ToList(),
                    SuongMuoi = (from DIEUKIENSINHTHAI in db.DIEUKIENSINHTHAIs where item.MaDKST == DIEUKIENSINHTHAI.MaDKST select DIEUKIENSINHTHAI.SuongMuoi).ToList(),
                   CayTrong= (from CAYTRONG in db.CAYTRONGs where item.MaCT == CAYTRONG.MaCT select CAYTRONG.Loai).ToList(),
                    SauHai = (from SAUHAI in db.SAUHAIs where item.MaCT == SAUHAI.MaCT select SAUHAI.TenSH).ToList(),
                    BenhHai = (from BENHHAI in db.BENHHAIs where item.MaCT == BENHHAI.MaCT select BENHHAI.TenBH).ToList(),
                    KhoangCachHang = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where item.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.KhoangCachHang).ToList(),
                    LenMo = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where item.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.LenMo).ToList(),
                    PhuongThucTuoi = (from HETHONGTUOI in db.HETHONGTUOIs where item.MaKT == HETHONGTUOI.MaKT select HETHONGTUOI.PhuongThuc).ToList(),
                    NguonNuoc = (from HETHONGTUOI in db.HETHONGTUOIs where item.MaKT == HETHONGTUOI.MaKT select HETHONGTUOI.NguonNuoc).ToList(),
                    KiemSoatCo = (from KIEMSOATCO in db.KIEMSOATCOes where item.MaKT == KIEMSOATCO.MaKT select KIEMSOATCO.PhuongPhap).ToList(),
                    DienTich = item.DienTich,
                   

                });
            }
            return listSP;
        }

        // GET: api/Vuon/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.VUONs.FirstOrDefault(e => e.MaVuon == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Vuon with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var Vuon = new Object();
                        Vuon = new
                        {
                            MaVuon = entity.MaVuon,
                            TenVuon = entity.TenVuon,
                            MaKT = entity.MaKT,
                            MaDKST = entity.MaDKST,
                            MaCT = (from CAYTRONG in db.CAYTRONGs where entity.MaCT == CAYTRONG.MaCT select CAYTRONG.MaCT).ToList(),
                            MaLD = (from LOAIDAT in db.LOAIDATs where entity.MaLD == LOAIDAT.MaLD select LOAIDAT.MaLD).ToList(),
                            MaHT = (from HIENTRANG in db.HIENTRANGs where entity.MaHT == HIENTRANG.MaHT select HIENTRANG.MaHT).ToList(),
                            MaDP = (from DIAPHUONG in db.DIAPHUONGs where entity.MaDP == DIAPHUONG.MaDP select DIAPHUONG.MaDP).ToList(),
                            DienTich = entity.DienTich,

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, Vuon);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/Vuon
        public HttpResponseMessage Post([FromBody]VUON vuon)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.VUONs.Add(vuon);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, vuon);
                    message.Headers.Location = new Uri(Request.RequestUri + vuon.MaVuon.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Vuon/5
        public HttpResponseMessage Put(int id, [FromBody]VUON vuon)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.VUONs.FirstOrDefault(e => e.MaVuon == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Vuon with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {

                        entity.MaVuon = Convert.ToInt32(vuon.MaVuon);
                        entity.TenVuon = vuon.TenVuon;
                        entity.MaKT = vuon.MaKT;
                        entity.MaDKST = vuon.MaDKST;
                        entity.MaCT =vuon.MaCT;
                        entity.MaLD =vuon.MaLD;
                        entity.MaHT = vuon.MaHT;
                        entity.MaDP = vuon.MaDP;
                        entity.DienTich = vuon.DienTich;
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

        // DELETE: api/Vuon/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.VUONs.FirstOrDefault(e => e.MaVuon == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Vuon with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                    var query = (from prods in db.QUYENSOHUUs where prods.MaSoHuu == id select prods).ToList();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            db.QUYENSOHUUs.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    db.VUONs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
