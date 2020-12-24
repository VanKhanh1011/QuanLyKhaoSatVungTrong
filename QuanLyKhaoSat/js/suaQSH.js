$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemSH" class="both_child tabcontent">
            <div class=" both__content" id="SuaSHChild">
              <form action="">
                <h2>Thông Tin Quyền Sở Hữu</h2>
                <label for="themmaVQSH">Chọn Mã Vườn :</label> 
                <select class="themmaVQSH" id="themmaVQSH" >
                  <option value=""></option>
                
              </select>
                <br>
                <label for="themmaNDQSH">Chọn Mã Nông Dân:</label> 
                <select class="themmaNDQSH" id="themmaNDQSH" >
                  <option value=""></option>
                
              </select>
              <br>
              <label for="themmaDotQSH">Chọn Mã Đợt:</label> 
              <select class="themmaDotQSH" id="themmaDotQSH" >
                <option value=""></option>
              
            </select>
            <br>
                <button class="btn btnLuu luuQSHthem">Lưu</button>
                <button class="btn"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemSH").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/QuyenSoHuu/" + id);
    xhr.send();
    $('#ThemSH').delegate('.luuQSHthem', 'click', event => {
        var MaVuon = $('.themmaVQSH').val()
        var MaND = $('.themmaNDQSH').val()
        var MaDot = $('.themmaDotQSH').val()
        console.log(MaVuon + MaND + MaDot)
        if (MaVuon == "" || MaND == "" || MaDot == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                      
                        \n        \"MaSoHuu\": \"${id}\" ,
                        \n        \"MaVuon\": \"${MaVuon}\",
                        \n        \"MaND\": \"${MaND}\",
                        \n        \"MaDot\": \"${MaDot}\",
                        \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/QuyenSoHuu/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});