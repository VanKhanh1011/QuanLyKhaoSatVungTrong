$(document).ready(function() {
    var query = window.location.search.substring(1);
    var vars = query.split("=");
    var id =vars[1];  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let item = JSON.parse(xhr.response)
            let str = `
            <div id="ThemDKST" class="both_child tabcontent">
            <div class=" both__content" id="ThemDKSTChild">
              <form action="">
                <h2>Điều Kiện Sinh Thái</h2>
                <label for="muaDKST">Mùa Mưa : </label>  <input type="text" placeholder="" class="muaDKST" style="outline: none;" value="${item.Mua}">
                <br>
                <label for="nangDKST">Nhiệt Độ Mùa Nắng : </label>  <input type="text" placeholder="" class="nangDKST" style="outline: none;" value="${item.NhietDoMuaNang}">
                <br>
                <label for="luDKST">Lũ : </label>  <input type="text" placeholder="" class="luDKST" style="outline: none;" value="${item.Lu}">
                <br>
                <label for="tcDKST">Triêu Cường : </label>  <input type="text" placeholder="" class="tcDKST" style="outline: none;" value="${item.TrieuCuong}">
                <br>
                <label for="smDKST">Sương Muối : </label>  <input type="text" placeholder="" class="smDKST" style="outline: none;" value="${item.SuongMuoi}">
                <br>
                <label for="gioDKST">Gió : </label>  <input type="text" placeholder="" class="gioDKST" style="outline: none;" value="${item.Gio}">
                <br>
                <label for="dophDKST">Độ pH : </label>  <input type="text" placeholder="" class="dophDKST" style="outline: none;" value="${item.DoPH}">
                <br>
                <button class="btn btnLuu luuDKSTthem">Lưu</button>
                <button class="btn">Hủy</button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemDKST").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/DieuKienSinhThai/" + id);
    xhr.send();
    $('#ThemDKST').delegate('.luuDKSTthem', 'click', event => {
      var muaDKST = $('.muaDKST').val()
      var nangDKST = $('.nangDKST').val()
      var luDKST = $('.luDKST').val()
      var tcDKST = $('.tcDKST').val()
      var smDKST = $('.smDKST').val()
      var gioDKST = $('.gioDKST').val()
      var dophDKST = $('.dophDKST').val()
     // console.log(tinhDP + huyenDP + xaDP + apDP )
      if (muaDKST == "" || nangDKST == "" ||luDKST == ""|| tcDKST==""||smDKST==""||gioDKST==""||dophDKST=="" )
          alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                      \n        \"MaDKST\":\"${id}\" ,
                      \n        \"Mua\": \"${muaDKST}\",
                      \n        \"NhietDoMuaNang\": \"${nangDKST}\",
                      \n        \"SuongMuoi\": \"${smDKST}\",
                      \n        \"Gio\": \"${gioDKST}\",
                      \n        \"Lu\":\"${luDKST}\",
                      \n        \"TrieuCuong\":\"${tcDKST}\",
                      \n        \"DoPH\":\"${dophDKST}\",
                      \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/DieuKienSinhThai/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});