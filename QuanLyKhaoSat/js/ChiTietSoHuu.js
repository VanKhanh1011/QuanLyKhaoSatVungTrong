$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div class="both_child tabcontent" id="xemQSH">  
            <div class=" both__content" id="SuaSHChild"style="width: 800px;height: 3300px;">
            <h1>Phiếu Nhập Liệu</h1>
            <form action="">
                <div id="getttDKS">
                    <label for="ngayKSct">Ngày Khảo sát</label> <input type="text" class="ngayKSct" id="ngayKSct" value="${item.Ngay}">
                    <br>
                    <label for="NVTHct">Nhân Viên Thực Hiện:</label> <input type="text" class="NVTHct" id="NVTHct" value="${item.NhanVien}">
                    <br>
                </div>
                
                    <label for="getMaNDct">Tên Nông Dân </label>
                   <input type="text" class="getMaNDct" value="${item.TenND}">
                <label for="chonVuon">Tên Vườn</label> <input type="text" value="${item.TenVuon}">
                <br>
                <div id="getttVuon">
                <label for="">Diện Tích Vườn </label> <input type="text" value="${item.DienTich}">
                <br>
                <label for="">Tỉnh</label> <input type="text" value="${item.Tinh}">
                <br>
                <label for="">Huyện</label> <input type="text" value="${item.Huyen}">
                <br>
                <label for="">Xã</label> <input type="text" value="${item.Xa}">
                <br>
                <label for="">Ấp</label> <input type="text" value="${item.Ap}">
                <br>
                <label for="">Số Lượng Cây:</label> <input type="text" value="${item.SoLuongCay}">
                <br>
                <label for="">Năng Suất:</label> <input type="text"value="${item.NangSuat}">
                <br>
                <label for="">Tỉ Lệ</label> <input type="text" value="${item.TiLe}">
                <br>
                <label for="">Loại Đất</label> <input type="text" value="${item.LoaiDat}">
                <br>
                <label for="">Độ Ẩm</label> <input type="text" value="${item.DoAm}">
                <br>
                <label for="">Đặc Trưng</label> <input type="text" value="${item.DacTrung}">
                <br>
                <label for="">Mưa</label> <input type="text" value="${item.Mua}">
                <br>
                <label for="">Nhiệ Độ Mùa Nắng</label> <input type="text" value="${item.NhietDoMuaNang}">
                <br>
                <label for="">Gió</label> <input type="text" value="${item.Gio}">
                <br>
                <label for="">Sương Muối</label> <input type="text" value="${item.SuongMuoi}">
                <br>
                <label for="">Lũ</label> <input type="text" value="${item.Lu}">
                <br>
                <label for="">Triều Cường</label> <input type="text" value="${item.TrieuCuong}">
                <br>
                <label for="">Độ PH:</label> <input type="text" value="${item.DoPH}">
                <br>
                <label for="">Cây Trồng:</label> <input type="text" value="${item.CayTrong}">
                <br>
                <label for="">Sâu Hại:</label> <input type="text" value="${item.SauHai}">
                <br>
                <label for="">Bệnh Hại:</label> <input type="text" value="${item.BenhHai}">
                <br>
                <label for="">Khoảng Cách Hàng:</label> <input type="text" value="${item.KhoangCachHang}">
                <br>
                <label for="">Lên Mô:</label> <input type="text" value="${item.LenMo}">
                <br>
                <label for="">Phương Thức Tưới:</label> <input type="text" value="${item.PhuongThucTuoi}">
                <br>
                <label for="">Nguồn Nước:</label> <input type="text" value="${item.NguonNuoc}">
                <br>
                <label for="">Kiểm Soát Cỏ:</label> <input type="text" value="${item.KiemSoatCo}">
                <br>
            </div>
                <!-- ============================================ -->
                <!-- <button class="luuPNL">Lưu</button> -->
                <button style="margin-left: 300px;"> <a href="./QuyenSoHuu.html" >Thoát</a> </button>
            </form>
        </div>
        </div>
            `
            document.querySelector("#xemQSH").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/QuyenSoHuu/" + id);
    xhr.send();
});