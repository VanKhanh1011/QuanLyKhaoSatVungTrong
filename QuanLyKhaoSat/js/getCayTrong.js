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
                   
                    <tbody id="tbody-getcaytrong">
                    <tr>
                      <!-- <td scope="row"></td> -->
                      <td></td>
                      <td>${a.MaCT}</td>
                      <td>${a.Loai}</td>
                      <td>${a.Giong}</td>
                      <td>${a.Tuoi}</td>
                      <td>${a.MoTa}</td>
                      <td>${a.TT}</td>
                      <td>
                      <button class="btn btn-success deleteCT" data-id="${a.MaCT}">Xóa</button>
                      <button class="btn btn-success" 
                      ><a href="SuaDanhMucCayTrong.html?id=${a.MaCT}" style="color: black;text-decoration: none;">Sửa</a></button>
                      </td>
                    </tr>
                    
                  </tbody>
              
                   
                        `
                   
                

            }
            document.getElementById('tbody-getcaytrong').innerHTML = temp


        }
    });

    xhr.open("GET", "http://localhost:52348/api/CayTrong");
    xhr.send();
    $('#tbody-getcaytrong').delegate('.deleteCT', 'click', event => {
        let id = event.target.getAttribute("data-id");
        xhr.open("DELETE", "http://localhost:52348/api/CayTrong/"+ id);
        xhr.send();
        location.reload();
    })
});