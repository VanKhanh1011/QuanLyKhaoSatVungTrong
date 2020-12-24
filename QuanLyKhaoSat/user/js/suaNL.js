$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemCTKS" class="both_child tabcontent">
            <div class=" both__content" id="ThemCTKSChild">
              <form action="">
                <h2>Đợt Khảo Sát</h2>
                <label for="TenDot">Tên Đợt : </label>  <input type="text" class="TenDot" placeholder="" style="outline: none;"
                value=${item.TenDot}>
                <br>
                <label for="MaNVthemnl">Mã Nhân Viên : </label> 
                <select name="" id="MaNVthemnl" class="MaNVthemnl">
                  <option value=""></option>
               
                </select> 
                
                <br>
                <button class="btn btnLuu luuDKSthem">Lưu</button>
                <button class="btn"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemCTKS").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/DotKhaoSat/" + id);
    xhr.send();
    $('#ThemCTKS').delegate('.luuDKSthem', 'click', event => {
      var TenDot = $('.TenDot').val()
      var MaNVthemnl = $('.MaNVthemnl').val()
    
    console.log(TenDot,MaNVthemnl)
      if (TenDot == "" || MaNVthemnl=="" )
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaBH\": \"${id}\" ,
                      \n        \"TenDot\": \"${TenDot}\",
                      \n        \"MaNV\": \"${MaNVthemnl}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/DotKhaoSat/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});