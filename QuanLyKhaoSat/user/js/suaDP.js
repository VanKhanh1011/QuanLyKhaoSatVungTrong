$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemDP" class="both_child tabcontent">
            <div class=" both__content" id="ThemDPChild">
              <form action="">
                <h2>Thông Tin Địa Phương</h2>
                <label for="tinhDP">Tỉnh : </label>  <input type="text" class="tinhDP" placeholder="" style="outline: none;"
                value="${item.Tinh}">
                <br>
                <label for="huyenDP">Huyện : </label>  <input type="text" class="huyenDP" placeholder="" style="outline: none;"
                value="${item.Huyen}">
                <br>
                <label for="xaDP">Xã : </label>  <input type="text" class="xaDP" placeholder="" style="outline: none;"
                value="${item.Xa}">
                <br>
                <label for="apDP">Ấp : </label>  <input type="text" class="apDP" placeholder="" style="outline: none;"
                value="${item.Ap}">
                <br>
                <button class="btn btnLuu luuDPthem">Lưu</button>
                <button class="btn">Hủy</button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemDP").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/DiaPhuong/" + id);
    xhr.send();
    $('#ThemDP').delegate('.luuDPthem', 'click', event => {
      var tinhDP = $('.tinhDP').val()
      var huyenDP = $('.huyenDP').val()
      var xaDP = $('.xaDP').val()
      var apDP = $('.apDP').val()
      console.log(tinhDP + huyenDP + xaDP + apDP )
      if (tinhDP == "" || huyenDP == "" ||xaDP == ""|| apDP=="" )
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaDP\":\"${id}\" ,
                      \n        \"Tinh\": \"${tinhDP}\",
                      \n        \"Huyen\": \"${huyenDP}\",
                      \n        \"Xa\": \"${xaDP}\",
                      \n        \"Ap\":\"${apDP}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/DiaPhuong/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});