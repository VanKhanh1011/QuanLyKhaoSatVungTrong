$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemDMCT" class="both_child tabcontent">
                <div class=" both__content" id="ThemDMCTChild">
                  <form action="">
                    <h2>Cây Trồng</h2>
                    <label for="loaiCT">Loại : </label>  <input type="text" class="loaiCT" placeholder="" style="outline: none;"
                    value="${item.Loai}">
                    <br>
                    <label for="giongCT">Giống : </label>  <input type="text" class="giongCT"  placeholder="" style="outline: none;"
                    value="${item.Giong}">
                    <br>
                    <label for="tuoiCT">Tuổi : </label>  <input type="text" class="tuoiCT"  placeholder="" style="outline: none;"
                    value="${item.Tuoi}">
                    <br>
                    <label for="motaCT">Mô Tả : </label>  <input type="text" class="motaCT"  placeholder="" style="outline: none;"
                    value="${item.MoTa}">
                    <br>
                    <label for="ttCT">Trạng Thái : </label>  
                    <select class="ttCT" id="ttCT" style="margin-right: 30px;margin-bottom: 20px; ">
                      <option value="0">0</option>
                      <option value="1">1</option>
                  </select>
                    <br>
                    <button class="btn btnLuu luuCTthem">Lưu</button>
                    <button class="btn">Hủy</button>
                  </form>
                </div>
              </div>
            `
            document.querySelector("#ThemDMCT").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/CayTrong/" + id);
    xhr.send();
    $('#ThemDMCT').delegate('.luuCTthem', 'click', event => {
      var loaiCT = $('.loaiCT').val()
      var giongCT = $('.giongCT').val()
      var tuoiCT = $('.tuoiCT').val()
      var motaCT = $('.motaCT').val()
      var ttCT = $('.ttCT').val()
      console.log(loaiCT + giongCT + tuoiCT + motaCT + ttCT)
      if (loaiCT == "" || giongCT == "" || tuoiCT == ""|| motaCT == ""|| ttCT=="" )
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaCT\": \"${id}\" ,
                      \n        \"Loai\": \"${loaiCT}\",
                      \n        \"Giong\": \"${giongCT}\",
                      \n        \"Tuoi\": \"${tuoiCT}\",
                      \n        \"MoTa\":\"${motaCT}\",
                      \n        \"TT\":\"${ttCT==0 ?"false":"true"}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/CayTrong/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});