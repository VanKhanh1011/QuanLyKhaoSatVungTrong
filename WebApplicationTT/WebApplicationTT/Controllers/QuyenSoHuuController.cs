using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class QuyenSoHuuController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/QuyenSoHuu
        public IEnumerable<dynamic> Get()
        {

            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.QUYENSOHUUs select prods).ToList();
            foreach (var item in query)
            {
                listSP.Add(new
                {
                    MaSoHuu = item.MaSoHuu,
                    MaVuon = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.MaVuon).ToList(),
                    MaND = (from NONGDAN in db.NONGDANs where item.MaND == NONGDAN.MaND select NONGDAN.MaND).ToList(),
                    TenND = (from NONGDAN in db.NONGDANs where item.MaND == NONGDAN.MaND select NONGDAN.HoTen).ToList(),
                    MaDot = (from DOTKHAOSAT in db.DOTKHAOSATs where item.MaDot == DOTKHAOSAT.MaDot select DOTKHAOSAT.MaDot).ToList(),
                    NhanVien= (from DOTKHAOSAT in db.DOTKHAOSATs where item.MaDot == DOTKHAOSAT.MaDot select DOTKHAOSAT.NHANVIEN.Ten).ToList(),
                    TenVuon = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.TenVuon).ToList(),
                    CayTrong = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.CAYTRONG.Loai).ToList(),
                    Ngay = (from DOTKHAOSAT in db.DOTKHAOSATs where item.MaDot == DOTKHAOSAT.MaDot select DOTKHAOSAT.Ngay).ToList(),
                    DienTich = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DienTich).ToList(),
                    Tinh= (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIAPHUONG.Tinh).ToList(),
                    Huyen = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIAPHUONG.Huyen).ToList(),
                    Xa = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIAPHUONG.Xa).ToList(),
                    Ap = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIAPHUONG.Ap).ToList(),
                    LoaiDat = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.LOAIDAT.TenLD).ToList(),
                    DoAm = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.LOAIDAT.DoAm).ToList(),
                    DacTrung = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.LOAIDAT.DacTrung).ToList(),
                    SoLuongCay = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.HIENTRANG.SoLuongCay).ToList(),
                    NangSuat = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.HIENTRANG.NangSuat).ToList(),
                    TiLe = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.HIENTRANG.TiLe).ToList(),
                    Mua = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.Mua).ToList(),
                    NhietDoMuaNang = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.NhietDoMuaNang).ToList(),
                    Gio = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.Gio).ToList(),
                    Lu = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.Lu).ToList(),
                    TrieuCuong = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.TrieuCuong).ToList(),
                    DoPH = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.DoPH).ToList(),
                    SuongMuoi = (from VUON in db.VUONs where item.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.SuongMuoi).ToList(),
                    SauHai = (from SAUHAI in db.SAUHAIs where item.VUON.MaCT == SAUHAI.MaCT select SAUHAI.TenSH).ToList(),
                    BenhHai = (from BENHHAI in db.BENHHAIs where item.VUON.MaCT == BENHHAI.MaCT select BENHHAI.TenBH).ToList(),
                    KhoangCachHang = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where item.VUON.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.KhoangCachHang).ToList(),
                    LenMo = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where item.VUON.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.LenMo).ToList(),
                    PhuongThucTuoi = (from HETHONGTUOI in db.HETHONGTUOIs where item.VUON.MaKT == HETHONGTUOI.MaKT select HETHONGTUOI.PhuongThuc).ToList(),
                    NguonNuoc = (from HETHONGTUOI in db.HETHONGTUOIs where item.VUON.MaKT == HETHONGTUOI.MaKT select HETHONGTUOI.NguonNuoc).ToList(),
                    KiemSoatCo = (from KIEMSOATCO in db.KIEMSOATCOes where item.VUON.MaKT == KIEMSOATCO.MaKT select KIEMSOATCO.PhuongPhap).ToList(),
                });
            }
            return listSP;
        }

        // GET: api/QuyenSoHuu/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.QUYENSOHUUs.FirstOrDefault(e => e.MaSoHuu == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "So Huu with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var QSH = new Object();
                        QSH = new
                        {

                            MaSoHuu = entity.MaSoHuu,
                            MaVuon = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.MaVuon).ToList(),
                            MaND = (from NONGDAN in db.NONGDANs where entity.MaND == NONGDAN.MaND select NONGDAN.MaND).ToList(),
                            MaDot = (from DOTKHAOSAT in db.DOTKHAOSATs where entity.MaDot == DOTKHAOSAT.MaDot select DOTKHAOSAT.MaDot).ToList(),
                            TenND = (from NONGDAN in db.NONGDANs where entity.MaND == NONGDAN.MaND select NONGDAN.HoTen).ToList(),
                            NhanVien = (from DOTKHAOSAT in db.DOTKHAOSATs where entity.MaDot == DOTKHAOSAT.MaDot select DOTKHAOSAT.NHANVIEN.Ten).ToList(),
                            TenVuon = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.TenVuon).ToList(),
                            CayTrong = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.CAYTRONG.Loai).ToList(),
                            Ngay = (from DOTKHAOSAT in db.DOTKHAOSATs where entity.MaDot == DOTKHAOSAT.MaDot select DOTKHAOSAT.Ngay).ToList(),
                            DienTich = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DienTich).ToList(),
                            Tinh = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIAPHUONG.Tinh).ToList(),
                            Huyen = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIAPHUONG.Huyen).ToList(),
                            Xa = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIAPHUONG.Xa).ToList(),
                            Ap = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIAPHUONG.Ap).ToList(),
                            LoaiDat = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.LOAIDAT.TenLD).ToList(),
                            DoAm = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.LOAIDAT.DoAm).ToList(),
                            DacTrung = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.LOAIDAT.DacTrung).ToList(),
                            SoLuongCay = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.HIENTRANG.SoLuongCay).ToList(),
                            NangSuat = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.HIENTRANG.NangSuat).ToList(),
                            TiLe = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.HIENTRANG.TiLe).ToList(),
                            Mua = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.Mua).ToList(),
                            NhietDoMuaNang = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.NhietDoMuaNang).ToList(),
                            Gio = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.Gio).ToList(),
                            Lu = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.Lu).ToList(),
                            TrieuCuong = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.TrieuCuong).ToList(),
                            DoPH = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.DoPH).ToList(),
                            SuongMuoi = (from VUON in db.VUONs where entity.MaVuon == VUON.MaVuon select VUON.DIEUKIENSINHTHAI.SuongMuoi).ToList(),
                            SauHai = (from SAUHAI in db.SAUHAIs where entity.VUON.MaCT == SAUHAI.MaCT select SAUHAI.TenSH).ToList(),
                            BenhHai = (from BENHHAI in db.BENHHAIs where entity.VUON.MaCT == BENHHAI.MaCT select BENHHAI.TenBH).ToList(),
                            KhoangCachHang = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where entity.VUON.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.KhoangCachHang).ToList(),
                            LenMo = (from KYTHUATCANHTAC in db.KYTHUATCANHTACs where entity.VUON.MaKT == KYTHUATCANHTAC.MaKT select KYTHUATCANHTAC.LenMo).ToList(),
                            PhuongThucTuoi = (from HETHONGTUOI in db.HETHONGTUOIs where entity.VUON.MaKT == HETHONGTUOI.MaKT select HETHONGTUOI.PhuongThuc).ToList(),
                            NguonNuoc = (from HETHONGTUOI in db.HETHONGTUOIs where entity.VUON.MaKT == HETHONGTUOI.MaKT select HETHONGTUOI.NguonNuoc).ToList(),
                            KiemSoatCo = (from KIEMSOATCO in db.KIEMSOATCOes where entity.VUON.MaKT == KIEMSOATCO.MaKT select KIEMSOATCO.PhuongPhap).ToList(),

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, QSH);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/QuyenSoHuu
        public HttpResponseMessage Post([FromBody]QUYENSOHUU quyensohuu)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.QUYENSOHUUs.Add(quyensohuu);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, quyensohuu);
                    message.Headers.Location = new Uri(Request.RequestUri + quyensohuu.MaSoHuu.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/QuyenSoHuu/5
        public HttpResponseMessage Put(int id, [FromBody]QUYENSOHUU quyensohuu)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.QUYENSOHUUs.FirstOrDefault(e => e.MaSoHuu == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Quyen So Huu with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.MaSoHuu = Convert.ToInt32(quyensohuu.MaSoHuu);
                        entity.MaVuon = quyensohuu.MaVuon;
                        entity.MaND = quyensohuu.MaND;
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

        // DELETE: api/QuyenSoHuu/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.QUYENSOHUUs.FirstOrDefault(e => e.MaSoHuu == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "So Huu with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                    
                    db.QUYENSOHUUs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
