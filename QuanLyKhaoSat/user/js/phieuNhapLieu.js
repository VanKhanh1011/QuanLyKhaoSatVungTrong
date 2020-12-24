$(document).ready(function () {
  let maDSKTemplate = "";
  let maVuonTemplate = "";
  let maNDTemplate = "";
  getMaDKS((template) => {
    maDSKTemplate = template;

    getMaND((template) => {
      maNDTemplate = template;

      getMaVuon((template) => {
        maVuonTemplate = template;

        renderHTML(maDSKTemplate, maNDTemplate, maVuonTemplate)
      });
    });
  });
});

function renderHTML(maDSKTemplate, maNDTemplate, maVuonTemplate) {
  var tam = `
              <div class=" both__content" id="SuaSHChild"style="width: 800px;height: 3300px;">
                  <h1>Phiếu Nhập Liệu</h1>
                  <form action="">
  
                      <label for="">Chọn Đợt Khảo Sát</label>
                      <br>
                      ${maDSKTemplate}
                      <br>
                      <div id="getttDKS">
                          <label for="ngayKS">Ngày Khảo sát</label> <input type="text" class="ngayKS" id="ngayKS">
                          <br>
                          <label for="NVTH">Nhân Viên Thực Hiện:</label> <input type="text" class="NVTH" id="NVTH">
                          <br>
                      </div>
                      
                      <!-- ================================= -->
                      <label for="getMaND">Chọn Nông Dân </label>
                      ${maNDTemplate}
                      <br>
                      <!-- ================================================= -->
                      <label for="chonVuon">Chọn Vườn</label>
                      ${maVuonTemplate}
                      <br>
                      <div id="getttVuon">
                      <label for="">Diện Tích Vườn </label> <input type="text">
                      <br>
                      <label for="">Tỉnh</label> <input type="text">
                      <br>
                      <label for="">Huyện</label> <input type="text">
                      <br>
                      <label for="">Xã</label> <input type="text">
                      <br>
                      <label for="">Ấp</label> <input type="text">
                      <br>
                      <label for="">Số Lượng Cây:</label> <input type="text">
                      <br>
                      <label for="">Năng Suất:</label> <input type="text">
                      <br>
                      <label for="">Tỉ Lệ</label> <input type="text">
                      <br>
                      <label for="">Loại Đất</label> <input type="text">
                      <br>
                      <label for="">Độ Ẩm</label> <input type="text">
                      <br>
                      <label for="">Đặc Trưng</label> <input type="text">
                      <br>
                      <label for="">Mưa</label> <input type="text">
                      <br>
                      <label for="">Nhiệ Độ Mùa Nắng</label> <input type="text">
                      <br>
                      <label for="">Gió</label> <input type="text">
                      <br>
                      <label for="">Sương Muối</label> <input type="text">
                      <br>
                      <label for="">Lũ</label> <input type="text">
                      <br>
                      <label for="">Triều Cường</label> <input type="text">
                      <br>
                      <label for="">Độ PH:</label> <input type="text">
                      <br>
                      <label for="">Cây Trồng:</label> <input type="text">
                      <br>
                      <label for="">Sâu Hại:</label> <input type="text">
                      <br>
                      <label for="">Bệnh Hại:</label> <input type="text">
                      <br>
                      <label for="">Khoảng Cách Hàng:</label> <input type="text">
                      <br>
                      <label for="">Lên Mô:</label> <input type="text">
                      <br>
                      <label for="">Phương Thức Tưới:</label> <input type="text">
                      <br>
                      <label for="">Nguồn Nước:</label> <input type="text">
                      <br>
                      <label for="">Kiểm Soát Cỏ:</label> <input type="text">
                      <br>
                      </div>
                      <!-- ============================================ -->
                      <button style="margin-left:200px;" class="luuPNL" id="luuPNL">Lưu</button>
                      <button><a href="./QuyenSoHuu.html">Hủy</a></button>
                  </form>
              </div>
              `;
  document.querySelector(".both_child").innerHTML = tam;
}
$('.both_child').delegate('.luuPNL', 'click', event => {
  var MaVuon = $('.chonVuon').val()
  var MaND = $('.getMaND').val()
  var MaDot = $('.getMaDKS').val()
  console.log(MaVuon + MaND + MaDot)
  if (MaVuon == "" || MaND == "" || MaDot == "")
      alert("Bạn chưa nhập đầy đủ thông tin ")
  else {
      alert(MaVuon)
      alert(MaND)
      alert(MaDot)
      let xhr = new XMLHttpRequest();
      let data = `
              {
                  \n        \"MaSoHuu\": ,
                  \n        \"MaVuon\": \"${MaVuon}\",
                  \n        \"MaND\": \"${MaND}\",
                  \n        \"MaDot\": \"${MaDot}\",
                  \n
              }
              `
      xhr.open("POST", "http://localhost:52348/api/QuyenSoHuu");
      xhr.setRequestHeader("Content-Type", "application/json");
      xhr.send(data);
      window.location = "/QuyenSoHuu.html"
}
});

