$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemHTT" class="both_child tabcontent">
            <div class=" both__content" id="ThemHTTChild">
              <form action="">
                <h2>Hệ Thống Tưới</h2>
                <label for="tenHTT">Phương Thức Tưới : </label>  <input type="text" placeholder="" class="tenHTT" style="outline: none;"
                value="${item.PhuongThuc}">
                <br>
                <label for="nguonnuocHTT">Nguồn Nước Sử Dụng : </label>  <input type="text" placeholder="" class="nguonnuocHTT" style="outline: none;"
                value="${item.NguonNuoc}">
                <br>
                <label for="themmaKTHTT">Chọn Mã Kỹ Thuật:</label>
                <select class="themmaKTHTT" id="themmaKTHTT">
                  <option value=""></option>
              </select>
                <button class="btn btnLuu luuHTTthem">Lưu</button>
                <button class="btn"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemHTT").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/HeThongTuoi/" + id);
    xhr.send();
    $('#ThemHTT').delegate('.luuHTTthem', 'click', event => {
      var tenHTT = $('.tenHTT').val()
      var nguonnuocHTT = $('.nguonnuocHTT').val()
      var themmaKTHTT = $('.themmaKTHTT').val()
     // console.log(tinhDP + huyenDP + xaDP + apDP )
      if (tenHTT == "" || nguonnuocHTT == "" ||themmaKTHTT == "")
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaHTT\": \"${id}\" ,
                      \n        \"PhuongThuc\": \"${tenHTT}\",
                      \n        \"NguonNuoc\": \"${nguonnuocHTT}\",
                      \n        \"MaKT\": \"${themmaKTHTT}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/HeThongTuoi/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});