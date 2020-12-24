using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTT.Models;

namespace WebApplicationTT.Controllers
{
    public class DotKhaoSatController : ApiController
    {
        KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities();
        // GET: api/DotKhaoSat
        public IEnumerable<dynamic> Get()
        {
            IList<Object> listSP = new List<Object>();
            var query = (from prods in db.DOTKHAOSATs select prods).ToList();
            //var benhhais = (from benhhai in db.BENHHAIs select benhhai).ToList();
            //var sauhais = (from sauhai in db.SAUHAIs select sauhai).ToList();
            //var kiemsoatcos = (from kiemsoatco in db.KIEMSOATCOes select kiemsoatco).ToList();
            //var hethongtuois = (from hethongtuoi in db.HETHONGTUOIs select hethongtuoi).ToList();
            foreach (var item in query)
           {
                //List<int> maCT = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.CAYTRONG.MaCT).ToList();
                //List<int> maBH = new List<int>();
                //List<string> tenBH = new List<string>();
                //List<string> ghichuBH = new List<string>();
                //foreach (var bh in benhhais)
                //{
                //    if (maCT[0] == bh.MaCT)
                //    {
                //        maBH.Add(bh.MaBH);
                //        tenBH.Add(bh.TenBH);
                //        ghichuBH.Add(bh.GhiChu);
                //    }
                //}
                //List<int> maSH = new List<int>();
                //List<string> tenSH = new List<string>();
                //List<string> ghichuSH = new List<string>();
                //foreach (var sh in sauhais)
                //{
                //    if (maCT[0] == sh.MaCT)
                //    {
                //        maSH.Add(sh.MaSH);
                //        tenSH.Add(sh.TenSH);
                //        ghichuSH.Add(sh.GhiChu);
                //    }
                //}
                //List<int> maKT = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.KYTHUATCANHTAC.MaKT).ToList();
                //List<int> maKSC = new List<int>();
                //List<string> phuongphapKSC = new List<string>();
                //List<string> ghichuKSC = new List<string>();
                //foreach (var ksc in kiemsoatcos)
                //{
                //    if (maKT[0] == ksc.MaKT)
                //    {
                //        maKSC.Add(ksc.MaKSC);
                //        phuongphapKSC.Add(ksc.PhuongPhap);
                //        ghichuKSC.Add(ksc.GhiChu);
                //    }
                //}
                //List<int> maHTT = new List<int>();
                //List<string> phuongthucTuoi = new List<string>();
                //List<string> nguonNuoc = new List<string>();
                //foreach (var htt in hethongtuois)
                //{
                //    if (maKT[0] == htt.MaKT)
                //    {
                //        maHTT.Add(htt.MaHTT);
                //        phuongthucTuoi.Add(htt.PhuongThuc);
                //        nguonNuoc.Add(htt.NguonNuoc);
                //    }
                //}
                listSP.Add(new
                {
                    MaDot = item.MaDot,
                    TenDot = item.TenDot,
                    Ngay=item.Ngay,
                    MaNV = (from NHANVIEN in db.NHANVIENs where item.MaNV == NHANVIEN.MaNV select NHANVIEN.MaNV).ToList(),
                    TenNV= (from NHANVIEN in db.NHANVIENs where item.MaNV == NHANVIEN.MaNV select NHANVIEN.Ten).ToList(),
                    MaND= (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.NONGDAN.MaND).ToList(),
                    TenND= (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.NONGDAN.HoTen).ToList(),
                    MongMuon = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.NONGDAN.MongMuon).ToList(),
                    MaDiaPhuong = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIAPHUONG.MaDP).ToList(),
                    Tinh = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIAPHUONG.Tinh).ToList(),
                    Huyen = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIAPHUONG.Huyen).ToList(),
                    Xa = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIAPHUONG.Xa).ToList(),
                    Ap = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIAPHUONG.Ap).ToList(),
                    MaCayTrong = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.CAYTRONG.MaCT).ToList(),
                    Loai = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.CAYTRONG.Loai).ToList(),
                    Giong = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.CAYTRONG.Giong).ToList(),
                    Tuoi = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.CAYTRONG.Tuoi).ToList(),
                    MoTaCayTrong = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.CAYTRONG.MoTa).ToList(),
                    //MaBH = maBH,
                    //TenBH = tenBH,
                    //GhiChuBH = ghichuBH,
                    //MaSH = maSH,
                    //TenSH = tenSH,
                    //GhiChuSH = ghichuSH,
                    MaHT = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.HIENTRANG.MaHT).ToList(),
                        SoLuongCay = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.HIENTRANG.SoLuongCay).ToList(),
                    NangSuat = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.HIENTRANG.NangSuat).ToList(),
                    TiLe = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.HIENTRANG.TiLe).ToList(),
                    GhiChuHT = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.HIENTRANG.GhiChu).ToList(),
                    TenVuon = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.TenVuon).ToList(),
                    DienTich = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DienTich).ToList(),
                    MaLD = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.LOAIDAT.MaLD).ToList(),
                    TenLD = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.LOAIDAT.TenLD).ToList(),
                    DoAm = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.LOAIDAT.DoAm).ToList(),
                    DacTrung = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.LOAIDAT.DacTrung).ToList(),
                    MaDKST = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIEUKIENSINHTHAI.MaDKST).ToList(),
                    Mua = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIEUKIENSINHTHAI.Mua).ToList(),
                    NhietDoMuaNang = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIEUKIENSINHTHAI.NhietDoMuaNang).ToList(),
                    SuongMuoi = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIEUKIENSINHTHAI.SuongMuoi).ToList(),
                    Gio = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIEUKIENSINHTHAI.Gio).ToList(),
                    Lu = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIEUKIENSINHTHAI.Lu).ToList(),
                    TrieuCuong = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIEUKIENSINHTHAI.TrieuCuong).ToList(),
                    DoPH = (from QUYENSOHUU in db.QUYENSOHUUs where item.MaDot == QUYENSOHUU.MaDot select QUYENSOHUU.VUON.DIEUKIENSINHTHAI.DoPH).ToList(),
                    //MaKSC = maKSC,
                    //PhuongPhapKSC = phuongphapKSC,
                    //GhiChuKSC = ghichuKSC,
                    //MaHTT = maHTT,
                    //PhuongThuc = phuongthucTuoi,
                    //NguonNuoc = nguonNuoc,

                });
            }
            return listSP;

        }

        // GET: api/DotKhaoSat/5
        public HttpResponseMessage Get(int id)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.DOTKHAOSATs.FirstOrDefault(e => e.MaDot == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dot Khao Sat with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        var DKS = new Object();
                        DKS = new
                        {
                            MaDot = Convert.ToInt32(entity.MaDot),
                            TenDot = entity.TenDot,
                            Ngay=entity.Ngay,
                            MaNV = (from NHANVIEN in db.NHANVIENs where entity.MaNV == NHANVIEN.MaNV select NHANVIEN.MaNV).ToList(),
                            

                        };
                        return Request.CreateResponse(HttpStatusCode.OK, DKS);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        // POST: api/DotKhaoSat
        public HttpResponseMessage Post([FromBody]DOTKHAOSAT dotkhaosat)
        {
            try
            {
                using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
                {
                    db.DOTKHAOSATs.Add(dotkhaosat);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, dotkhaosat);
                    message.Headers.Location = new Uri(Request.RequestUri + dotkhaosat.MaDot.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/DotKhaoSat/5
        public HttpResponseMessage Put(int id, [FromBody]DOTKHAOSAT dotkhaosat)
        {
            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                try
                {
                    var entity = db.DOTKHAOSATs.FirstOrDefault(e => e.MaDot == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dot Khao Sat with id=" + id.ToString() + "not found to update");
                    }
                    else
                    {

                        entity.MaDot = Convert.ToInt32(dotkhaosat.MaDot);
                        entity.TenDot = dotkhaosat.TenDot;
                        entity.MaNV = Convert.ToInt32(dotkhaosat.MaNV);
                        entity.Ngay = dotkhaosat.Ngay;
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

        // DELETE: api/DotKhaoSat/5
        public HttpResponseMessage Delete(int id)
        {

            using (KS_VUNGTRONGEntities db = new KS_VUNGTRONGEntities())
            {
                var entity = db.DOTKHAOSATs.FirstOrDefault(e => e.MaDot == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dot Khao Sat  with id=" + id.ToString() + "not found to delete");
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
                    db.DOTKHAOSATs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
