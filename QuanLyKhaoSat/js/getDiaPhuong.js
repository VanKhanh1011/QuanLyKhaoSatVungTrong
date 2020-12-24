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
                   
                    <tbody id="tbody-getdiaphuong">
                  <tr>
                    <!-- <td scope="row"></td> -->
                    <td></td>
                    <td>${a.MaDP}</td>
                    <td>${a.Tinh}</td>
                    <td>${a.Huyen}</td>
                    <td>${a.Xa}</td>
                    <td>${a.Ap}</td>
                    <td>
                    <button class="btn btn-success deleteDP" data-id=${a.MaDP}>Xóa</button>
                    <button class="btn btn-success" 
                    ><a href="SuaDiaPhuong.html?id=${a.MaDP}" style="color: black;text-decoration: none;">Sửa</a></button>
                    </td>
                  </tr>
                  
                </tbody>
                   
                        `
                   
                

            }
            document.getElementById('tbody-getdiaphuong').innerHTML = temp


        }
    });

    xhr.open("GET", "http://localhost:52348/api/DiaPhuong");
    xhr.send();
    $('#tbody-getdiaphuong').delegate('.deleteDP', 'click', event => {
        let id = event.target.getAttribute("data-id");
        xhr.open("DELETE", "http://localhost:52348/api/DiaPhuong/"+ id);
        xhr.send();
        location.reload();
    })
});