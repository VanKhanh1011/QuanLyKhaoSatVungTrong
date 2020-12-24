let maVuon;
$(".both_child").delegate("#chonVuon", "change", () => {
  //event.preventDefault();
  var mavuon1 = $("#chonVuon").val();

  for (var i = 0; i < maVuon.length; i++) {
    if (mavuon1 == maVuon[i].MaVuon) {
      let temp3 = `
        <label for="">Diện Tích Vườn </label> <input type="text" value="${maVuon[i].DienTich}">
        <br>
        <label for="">Tỉnh</label> <input type="text" value="${maVuon[i].Tinh}">
        <br>
        <label for="">Huyện</label> <input type="text" value="${maVuon[i].Huyen}">
        <br>
        <label for="">Xã</label> <input type="text" value="${maVuon[i].Xa}">
        <br>
        <label for="">Ấp</label> <input type="text" value="${maVuon[i].Ap}">
        <br>
        <label for="">Số Lượng Cây:</label> <input type="text" value="${maVuon[i].SoLuongCay}">
        <br>
        <label for="">Năng Suất:</label> <input type="text" value="${maVuon[i].NangSuat}">
        <br>
        <label for="">Tỉ Lệ</label> <input type="text" value="${maVuon[i].TiLe}">
        <br>
        <label for="">Loại Đất</label> <input type="text" value="${maVuon[i].TenLD}">
        <br>
        <label for="">Độ Ẩm</label> <input type="text" value="${maVuon[i].DoAm}">
        <br>
        <label for="">Đặc Trưng</label> <input type="text" value="${maVuon[i].DacTrung}">
        <br>
        <label for="">Mưa</label> <input type="text" value="${maVuon[i].Mua}">
        <br>
        <label for="">Nhiệ Độ Mùa Nắng</label> <input type="text" value="${maVuon[i].NhietDoMuaNang}">
        <br>
        <label for="">Gió</label> <input type="text" value="${maVuon[i].Gio}">
        <br>
        <label for="">Sương Muối</label> <input type="text" value="${maVuon[i].SuongMuoi}">
        <br>
        <label for="">Lũ</label> <input type="text" value="${maVuon[i].Lu}">
        <br>
        <label for="">Triều Cường</label> <input type="text" value="${maVuon[i].TrieuCuong}">
        <br>
        <label for="">Độ PH:</label> <input type="text" value="${maVuon[i].DoPH}">
        <br>
        <label for="">Cây Trồng:</label> <input type="text" value="${maVuon[i].CayTrong}">
        <br>
        <label for="">Sâu Hại:</label> <input type="text" value="${maVuon[i].SauHai}">
        <br>
        <label for="">Bệnh Hại:</label> <input type="text" value="${maVuon[i].BenhHai}">
        <br>
        <label for="">Khoảng Cách Hàng:</label> <input type="text" value="${maVuon[i].KhoangCachHang}">
        <br>
        <label for="">Lên Mô:</label> <input type="text" value="${maVuon[i].LenMo}">
        <br>
        <label for="">Phương Thức Tưới:</label> <input type="text" value="${maVuon[i].PhuongThucTuoi}">
        <br>
        <label for="">Nguồn Nước:</label> <input type="text" value="${maVuon[i].NguonNuoc}">
        <br>
        <label for="">Kiểm Soát Cỏ:</label> <input type="text" value="${maVuon[i].KiemSoatCo}">
        <br>
                            `;
      document.getElementById("getttVuon").innerHTML = temp3;
      break;
    }
  }
});

function getMaVuon(callback) {
  let xhr = new XMLHttpRequest();
  xhr.open("GET", "http://localhost:52348/api/Vuon");
  xhr.send();

  xhr.addEventListener("readystatechange", function () {
    if (this.readyState === 4) {
      maVuon = JSON.parse(xhr.responseText);

      var n = maVuon.length;
      let data3 = [];
      for (var i = 0; i < n; i++) {
        data3[i] = maVuon[n - 1 - i];
      }
      let temp3 = `<select name="" id="chonVuon" class="chonVuon">
    
      `;
      for (var i = 0; i < data3.length; i++) {
        let a3 = data3[i];

        temp3 += `
       
                        <option value="${a3.MaVuon}">${a3.TenVuon}</option>
                        `;
      }
      temp3 += `</select>`;

      callback(temp3);
    }
  });
}
