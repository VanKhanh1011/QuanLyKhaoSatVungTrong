$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemDat" class="both_child tabcontent">
            <div class=" both__content" id="ThemDatChild">
              <form action="">
                <h2>Thông Tin Loại Đất</h2>
                <label for="tenLD">Tên Loại Đất : </label>  <input type="text" placeholder="" class="tenLD" style="outline: none;"
                value="${item.TenLD}">
                <br>
                <label for="doamLD">Độ Ẩm  : </label>  <input type="text" placeholder="" class="doamLD" style="outline: none;"
                value="${item.DoAm}">
                <br>
                <label for="tinhchatLD">Tính Chất Đặc Trưng: </label>  <input type="text" placeholder="" class="tinhchatLD" style="outline: none;"
                value="${item.DacTrung}">
                <br>
                <button class="btn btnLuu luuLDthem">Lưu</button>
                <button class="btn"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemDat").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/LoaiDat/" + id);
    xhr.send();
    $('#ThemDat').delegate('.luuLDthem', 'click', event => {
      var tenLD = $('.tenLD').val()
      var doamLD = $('.doamLD').val()
      var tinhchatLD = $('.tinhchatLD').val()
     
      //console.log(tinhDP + huyenDP + xaDP + apDP )
      if (tenLD == "" || doamLD == "" ||tinhchatLD == "")
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaLD\":\"${id}\" ,
                      \n        \"TenLD\": \"${tenLD}\",
                      \n        \"DoAm\": \"${doamLD}\",
                      \n        \"DacTrung\": \"${tinhchatLD}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/LoaiDat/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});