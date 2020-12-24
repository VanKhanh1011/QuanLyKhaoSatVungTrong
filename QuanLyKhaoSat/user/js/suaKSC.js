$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemKSC" class="both_child tabcontent">
            <div class=" both__content" id="ThemKSCChild">
              <form action="">
                <h2>Kiểm Soát Cỏ</h2>
                <label for="">Tên Phương Pháp : </label>  <input type="text" placeholder="" class="tenKSC" style="outline: none;"
                value=${item.PhuongPhap}>
                <br>
                <label for="">Ghi Chú : </label>  <input type="text" placeholder="" class="ghichuKSC" style="outline: none;"
                value=${item.GhiChu}>
                <br>
                <label for="themmaKTKSC">Chọn Mã Kỹ Thuật:</label>
                <select class="themmaKTKSC" id="themmaKTKSC">
                  <option value=""></option>
              </select>
                <button class="btn btnLuu luuKSCthem">Lưu</button>
                <button class="btn">Hủy</button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemKSC").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/SauHai/" + id);
    xhr.send();
    $('#ThemKSC').delegate('.luuKSCthem', 'click', event => {
      var tenKSC = $('.tenKSC').val()
        var ghichuKSC = $('.ghichuKSC').val()
        var themmaKTKSC = $('.themmaKTKSC').val()
       // console.log(tinhDP + huyenDP + xaDP + apDP )
        if (tenKSC == "" || ghichuKSC == "" ||themmaKTKSC == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaKSC\": \"${id}\" ,
                      \n        \"PhuongPhap\": \"${tenKSC}\",
                      \n        \"GhiChu\": \"${ghichuKSC}\",
                      \n        \"MaKT\": \"${themmaKTKSC}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/KiemSoatCo/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});