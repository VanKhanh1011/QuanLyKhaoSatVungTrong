$(document).ready(function() {
    function GetURLParameter(sParam) {
        var sPageURL = window.location.search.substring(1);
        var sURLVariables = sPageURL.split('&');
        for (var i = 0; i < sURLVariables.length; i++) {
            var sParameterName = sURLVariables[i].split('=');
            if (sParameterName[0] == sParam) {
                return sParameterName[1];
            }
        }
    }
  
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let data1 = JSON.parse(xhr.responseText)
            var n = data1.length
            let data = []
            for (var i = 0; i < n; i++) {
                data[i] = data1[n - 1 - i]
            }
            let temp = ""
            for (var i = 0; i < data.length; i++) {
                let a = data[i]
               
                    temp += `
                   
                    <tbody id="tbody-getkythuatcanhtac">
                  <tr>
                    <!-- <td scope="row"></td> -->
                    <td></td>
                    <td>${a.MaKT}</td>
                    <td>${a.KhoangCachHang}</td>
                    <td>${a.LenMo}</td>
                    <td>${a.HeThongTuoi}</td>
                    <td>${a.KiemSoatCo}</td>
                    <td>
                    <button class="btn btn-success deleteKTCT" data-id=${a.MaKT} >Xóa</button>
                    <button class="btn btn-success" 
                    ><a href="SuaKyThuatCanhTac.html?id=${a.MaKT}" style="color: black;text-decoration: none;">Sửa</a></button>
                    </td>
                  </tr>
                 
                </tbody>
                   
                        `
                   
                

            }
            document.getElementById('tbody-getkythuatcanhtac').innerHTML = temp


        }
    });

    xhr.open("GET", "http://localhost:52348/api/KyThuatCanhTac");
    xhr.send();
    $('#tbody-getkythuatcanhtac').delegate('.deleteKTCT', 'click', event => {
        let id = event.target.getAttribute("data-id");
        xhr.open("DELETE", "http://localhost:52348/api/KyThuatCanhTac/"+ id);
        xhr.send();
        location.reload();
    })
});