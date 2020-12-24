$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemHT" class="both_child tabcontent">
                <div class=" both__content" id="ThemHTChild">
                  <form action="">
                    <h2>Hiện Trạng</h2>
                    <label for="soluongCT">Số Lượng Cây Trồng : </label>  <input type="text" placeholder="" class="soluongCT" style="outline: none;"
                    value="${item.SoLuongCay}">
                    <br>
                    <label for="ttHT">Trạng Thái : </label> 
                    <select class="ttHT" id="ttHT" style="margin-right: 30px;margin-bottom: 20px; ">
                      <option value="">--Chọn--</option>
                      <option value="0">0</option>
                      <option value="1">1</option>
                  </select>
                    <br>
                    <label for="nangsuatHT">Năng Suất : </label>  <input type="text" placeholder="" class="nangsuatHT" style="outline: none;"
                    value="${item.NangSuat}">
                    <br>
                    <label for="tileHT">Tỉ Lệ : </label>  <input type="text" placeholder="" class="tileHT" style="outline: none;"
                    value="${item.TiLe}">
                    <br>
                    <label for="ghichuHT">Ghi Chú : </label>  <input type="text" placeholder="" class="ghichuHT" style="outline: none;"
                    value="${item.GhiChu}">
                    <br>
                    <button class="btn btnLuu luuHTthem">Lưu</button>
                    <button class="btn btn-success"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
                  </form>
                </div>
              </div>
            `
            document.querySelector("#ThemHT").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/HienTrang/" + id);
    xhr.send();
    $('#ThemHT').delegate('.luuHTthem', 'click', event => {
      var soluongCT = $('.soluongCT').val()
      var ttHT = $('.ttHT').val()
      var nangsuatHT = $('.nangsuatHT').val()
      var tileHT = $('.tileHT').val()
      var ghichuHT = $('.ghichuHT').val()
      console.log(soluongCT + ttHT + nangsuatHT + tileHT+ghichuHT )
      if (soluongCT == "" || ttHT == "" ||nangsuatHT == ""|| tileHT==""||ghichuHT=="" )
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaHT\": \"${id}\",
                      \n        \"SoLuongCay\": \"${soluongCT}\",
                      \n        \"NangSuat\": \"${ttHT}\",
                      \n        \"TiLe\": \"${nangsuatHT}\",
                      \n        \"GhiChu\": \"${tileHT}\",
                      \n        \"TT\":\"${ghichuHT}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/HienTrang/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});