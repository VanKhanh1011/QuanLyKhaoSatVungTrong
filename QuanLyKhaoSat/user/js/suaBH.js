$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemBH" class="both_child tabcontent">
            <div class=" both__content" id="SuaBHChild">
              <form action="">
                <h2>Thông Tin Bệnh Hại</h2>
                <label for="tenBH">Tên Bệnh Hại: </label>  <input type="text" class="tenBH" placeholder="" style="outline: none;" value=${item.TenBH}>
                <br>
                <label for="ghichuBH">Ghi Chú : </label>  <input type="text" class="ghichuBH" placeholder=""style="outline: none;" value=${item.GhiChu}>
                <br>
                <label for="ttBH">Trạng Thái : </label>  
                <select class="ttBH" id="ttBH" >
                  <option value="">--Chọn--</option>
                  <option value="0">0</option>
                  <option value="1">1</option>
              </select>
                <br>
                <label for="themmaCTBH">Chọn Mã Cây Trồng:</label> 
                <select class="themmaCTBH " id="themmaCTBH" >
                  <option value=""></option>
                  
              </select>
                <button class="btn btnLuu luuBHthem">Lưu</button>
                <button class="btn btn-success"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemBH").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/BenhHai/" + id);
    xhr.send();
    $('#ThemBH').delegate('.luuBHthem', 'click', event => {
        var tenBH = $('.tenBH').val()
        var ghichuBH = $('.ghichuBH').val()
        var ttBH = $('.ttBH').val()
        var maCTBH = $('.themmaCTBH').val()
        console.log(tenBH + ghichuBH + ttBH + maCTBH)
        if (tenBH == "" || ghichuBH == "" || ttBH == ""|| maCTBH == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                        \n        \"MaBH\": \"${id}\" ,
                        \n        \"TenBH\": \"${tenBH}\",
                        \n        \"GhiChu\": \"${ghichuBH}\",
                        \n        \"TT\": \"${ttBH==0 ?"false":"true"}\",
                        \n        \"MaCT\":\"${maCTBH}\",
                        \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/BenhHai/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});