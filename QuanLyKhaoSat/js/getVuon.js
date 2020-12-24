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
                   
                <tbody id="tbody-getvuon">
                  <tr id="get-vuon">
                    <!-- <td scope="row"></td> -->
                    <td></td>
                    <td>${a.MaVuon}</td>
                    <td>${a.TenVuon}</td>
                    <td>${a.MaKT}</td>
                    <td>${a.MaDKST}</td>
                    <td>${a.MaLD}</td>
                    <td>${a.MaHT}</td>
                    <td>${a.MaDP}</td>
                    <td>${a.MaCT}</td>
                    <td>${a.DienTich}</td>
                    <td>
                    <button class="btn btn-success deleteVuon" data-id=${a.MaVuon}>Xóa</button>
                    <button class="btn btn-success" 
                    ><a href="SuaVuon.html?id=${a.MaVuon}" style="color: black;text-decoration: none;">Sửa</a></button>
                    </td>
                  </tr>
                  
                </tbody>
              
                   
                        `
                   
                

            }
            document.getElementById('tbody-getvuon').innerHTML = temp


        }
    });

    xhr.open("GET", "http://localhost:52348/api/Vuon");
    xhr.send();
    $('#tbody-getvuon').delegate('.deleteVuon', 'click', event => {
        let id = event.target.getAttribute("data-id");
        xhr.open("DELETE", "http://localhost:52348/api/Vuon/"+ id);
        xhr.send();
        location.reload();
    })
});