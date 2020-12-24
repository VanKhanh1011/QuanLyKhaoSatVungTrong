$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemNV" class="both_child tabcontent">
                <div class=" both__content" id="ThemNVChild">
                  <form action="">
                    <h2>Thông Tin Nhân Viên</h2>
                    <label for="nameNV">Họ&Tên: </label>  <input type="text" class="nameNV" placeholder="" style="outline: none;"
                    value="${item.Ten}">
                    <br>
                    <label for="emailNV">Email : </label>  <input type="text" class="emailNV" placeholder="" style="outline: none;"
                    value="${item.Email}">
                    <br>
                    <label for="sdtNV">Số Điện Thoại : </label>  <input type="text" class="sdtNV" placeholder="" style="outline: none;"
                    value="${item.SDT}">
                    <br>
                    <label for="ghichuNV">Ghi Chú : </label>  <input type="text" class="ghichuNV" placeholder="" style="outline: none;"
                    value="${item.GhiChu}">
                    <br>
                    <label for="ttNV">Trạng Thái : </label> 
                    <select class="ttNV" id="ttNV">
                      <option value="">--Chọn--</option>
                      <option value="0">0</option>
                      <option value="1">1</option>
                  </select>
                    <br>
                    <label for="mkNV">Mật Khẩu : </label>  <input type="password" class="mkNV" placeholder="" style="outline: none;"
                    value="${item.MatKhau}">
                    <br>
                    <button class="btn btnLuu luuNVthem">Lưu</button>
                    <button class="btn">Hủy</button>
                  </form>
                </div>
              </div>
            `
            document.querySelector("#ThemNV").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/NhanVien/" + id);
    xhr.send();
    $('#ThemNV').delegate('.luuNVthem', 'click', event => {
      var sdt = $('.sdtNV').val()
        var email = $('.emailNV').val()
        var matkhau = $('.mkNV').val()
        var ghichu = $('.ghichuNV').val()
        var ten = $('.nameNV').val()
        var tt = $('.ttNV').val()
        console.log(sdt + email + matkhau + ghichu + ten + tt )
        if (sdt == "" || email == "" || matkhau == "" || ghichu == "" || ten == "" ||tt=="")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                      \n        \"MaNV\": \"${id}\" ,
                        \n        \"Ten\": \"${ten}\",
                        \n        \"SDT\": \"${sdt}\",
                        \n        \"GhiChu\": \"${ghichu}\",
                        \n        \"TT\": \"${tt==1 ?"true":"false"}\",
                        \n        \"MatKhau\":\"${matkhau}\",
                        \n         \"Email\":\"${email}\",
                        \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/NhanVien/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});