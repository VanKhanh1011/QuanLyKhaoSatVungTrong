$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemND" class="both_child tabcontent">
                <div class=" both__content" id="ThemNDChild">
                  <form action="">
                    <h2>Thông Tin Nông Dân</h2>
                    <label for="">Họ&Tên : </label>  <input type="text" class="hotenND" placeholder="" style="outline: none;"
                    value="${item.HoTen}">
                    <br>
                    <label for="">Số Điện Thoại : </label>  <input type="text" class="sdtND"  placeholder="" style="outline: none;"
                    value="${item.SDT}">
                    <br>
                    <label for="">Email : </label>  <input type="text" class="emailND"  placeholder="" style="outline: none;"
                    value="${item.Email}">
                    <br>
                    <label for="">Địa Chỉ : </label>  <input type="text" class="diachiND"  placeholder="" style="outline: none;"
                    value="${item.DiaChi}">
                    <br>
                    <label for="">Mong Muốn : </label>  <input type="text" class="mongmuonND"  placeholder="" style="outline: none;"
                    value="${item.MongMuon}">
                    <br>
                    <label for="">Mật Khẩu : </label>  <input type="password" class="matkhauND"  placeholder="" style="outline: none;"
                    value="${item.MatKhau}">
                    <br>
                    <button class="btn btnLuu luuNDthem">Lưu</button>
                    <button class="btn"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
                  </form>
                </div>
              </div>
            `
            document.querySelector("#ThemND").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/NongDan/" + id);
    xhr.send();
    $('#ThemND').delegate('.luuNDthem', 'click', event => {
      var hotenND = $('.hotenND').val()
      var sdtND = $('.sdtND').val()
      var emailND = $('.emailND').val()
      var diachiND = $('.diachiND').val()
      var mongmuonND = $('.mongmuonND').val()
      var matkhauND = $('.matkhauND').val()
      console.log(hotenND + sdtND + emailND + diachiND + mongmuonND + matkhauND)
      if (hotenND == "" || sdtND == "" || emailND == ""|| diachiND == ""|| mongmuonND==""|| matkhauND=="" )
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                      \n        \"MaND\":\"${id}\" ,
                      \n        \"HoTen\": \"${hotenND}\",
                      \n        \"SDT\": \"${sdtND}\",
                      \n        \"Email\": \"${emailND}\",
                      \n        \"DiaChi\":\"${diachiND}\",
                      \n        \"MongMuon\":\"${mongmuonND}\",
                      \n        \"MatKhau\":\"${matkhauND}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/NongDan/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});