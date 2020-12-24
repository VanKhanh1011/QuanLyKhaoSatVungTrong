$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemKTCT" class="both_child tabcontent">
                <div class=" both__content" id="ThemKTCTChild">
                  <form action="">
                    <h2>Kỹ Thuật Canh Tác</h2>
                    <label for="kcHang">Khoảng Cách Hàng : </label>  <input type="text" class="kcHang" placeholder="" style="outline: none;"
                    value="${item.KhoangCachHang}">
                    <br>
                    <label for="lenmo">Lên Mô : </label>  <input type="text" placeholder="" class="lenmo" style="outline: none;"
                    value="${item.LenMo}">
                    <br>
                    <button class="btn btnLuu luuKTCTthem">Lưu</button>
                    <button class="btn"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
                  </form>
                </div>
              </div>
            `
            document.querySelector("#ThemKTCT").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/KyThuatCanhTac/" + id);
    xhr.send();
    $('#ThemKTCT').delegate('.luuKTCTthem', 'click', event => {
      var kcHang = $('.kcHang').val()
      var lenmo = $('.lenmo').val()
     // console.log(tinhDP + huyenDP + xaDP + apDP )
      if (kcHang == "" || lenmo == "")
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaDKST\":\"${id}\" ,
                      \n        \"kcHang\": \"${kcHang}\",
                      \n        \"lenmo\": \"${lenmo}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/KyThuatCanhTac/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});