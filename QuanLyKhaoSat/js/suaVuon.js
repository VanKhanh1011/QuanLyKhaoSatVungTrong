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
                <h2>Thông Tin Vườn</h2>
                <label for="">Tên Vườn: </label>  <input type="text" class="TenVuonThem" placeholder="" style="outline: none;" value=${item.TenVuon}>
                <br>
                <label for="">Diện Tích : </label>  <input type="text" class="DienTichThem" placeholder="" style="outline: none;" value=${item.DienTich}>
                <br>
                <label for="themmaCTV">Chọn Mã Cây Trồng :</label> 
                <select class="themmaCTV" id="themmaCTV" >
                  <option value=""></option>
                
              </select>
                <br>
                <label for="themmaKTV">Chọn Mã Kỹ Thuật:</label> 
                <select class="themmaKTV" id="themmaKTV" >
                  <option value=""></option>
                
              </select>
              <br>
              <label for="themmaDPV">Chọn Mã Địa Phương:</label> 
              <select class="themmaDPV" id="themmaDPV" >
                <option value=""></option>
              
            </select>
            <br>
            <label for="themmaLDV">Chọn Mã Loại Đất:</label> 
            <select class="themmaLDV" id="themmaLDV" >
              <option value=""></option>
            
          </select>
          <label for="themmaDKSTV">Chọn Mã Sinh Thái:</label> 
          <select class="themmaDKSTV" id="themmaDKSTV" >
            <option value=""></option>
          
        </select>
        <br>
        <label for="themmaCTSH">Chọn Mã Hiện Trạng:</label> 
        <select class="themmaHTV" id="themmaHTV" >
          <option value=""></option>
        
      </select>
                <button class="btn btnLuu luuVuonthem">Lưu</button>
                <button class="btn"><a href="index.html" style="color: black;text-decoration: none;"> Hủy</a></button>
              </form>
            </div>
          </div>
            `
            document.querySelector("#ThemSH").innerHTML = str
        }
    });
    xhr.open("GET", "http://localhost:52348/api/Vuon/" + id);
    xhr.send();
    $('#ThemSH').delegate('.luuVuonthem', 'click', event => {
        var TenVuon = $('.TenVuonThem').val()
        var MaKT = $('.ThemmaKTV').val()
        var MADKST = $('.ThemmADKSTV').val()
        var MaCT = $('.ThemmaCTV').val()
        var MaLD = $('.ThemmaLDV').val()
        var MaHT = $('.ThemmaHTV').val()
        var MaDP = $('.ThemmaDPV').val()
        var DienTich= $('.DienTichThem').val()
        console.log(TenVuon + MaKT + ttSH + maCTSH)
        if (tenSH == "" || ghichuSH == "" || MADKST == ""|| MaCT == ""||DienTich==""||MaLD==""||MaHT==""||MaDP==""||DienTich=="")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let data = `
                    { 
                    
                        \n        \"MaVuon\":\"${id}\" ,
                        \n        \" TenVuon\": \"${TenVuon}\",
                        \n        \"MaKT\": \"${MaKT}\",
                        \n        \"MADKST\": \"${MADKST}\",
                        \n        \"MaCT\":\"${MaCT}\",
                        \n        \"MaLD\":\"${MaLD}\",
                        \n        \"MaHT\":\"${MaHT}\",
                        \n        \"MaDP\":\"${MaDP}\",
                        \n        \"DienTich\":\"${DienTich}\",
                        \n
                    }
                    `
                    xhr.open("PUT", "http://localhost:52348/api/Vuon/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })

  
});