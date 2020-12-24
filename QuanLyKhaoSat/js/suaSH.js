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
                  <form action="" class="formSuaSh">
                    <h2>Thông Tin Sâu Hại</h2>
                    <label for="">Tên Sâu Hại: </label>  <input type="text" class="tenSH" placeholder="" style="outline: none;" value=${item.TenSH}>
                    <br>
                    <label for="">Ghi Chú : </label>  <input type="text" class="ghichuSH" placeholder="" style="outline: none;" value=${item.GhiChu}>
                    <br>
                    <label for="ttSH">Trạng Thái : </label>  
                    <select class="ttSH" id="ttSH" >
                      <option value="0">0</option>
                      <option value="1">1</option>
                  </select>
                    <br>
                    <label for="themmaCTSH">Chọn Mã Cây Trồng:</label> 
                    <select class="themmaCTSH" id="themmaCTSH" >
                      <option value=""></option>
                    
                  </select>
                    <button class="btn btnLuu luuSHthem ">Lưu</button>
                    <button class="btn"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
                  </form>
                </div>
              </div>
            `
            document.querySelector("#ThemSH").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/SauHai/" + id);
    xhr.send();
    $('#ThemSH').delegate('.luuSHthem', 'click', event => {
        var tenSH = $('.tenSH').val()
        var ghichuSH = $('.ghichuSH').val()
        var ttSH = $('.ttSH').val()
        var themmaCTSH = $('.themmaCTSH').val()
        console.log(tenSH +ghichuSH + ttSH + themmaCTSH)
        if ( tenSH == "" || ghichuSH == "" ||ttSH == ""||  themmaCTSH == ""|| id=="")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                        \n        \"MaSH\":\"${id}\",
                        \n        \"TenSH\": \"${tenSH}\",
                        \n        \"GhiChu\": \"${ghichuSH}\",
                        \n        \"TT\": \"${ttSH==0 ?"false":"true"}\",
                        \n        \"MaCT\":\"${ themmaCTSH}\",
                        \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/SauHai/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});