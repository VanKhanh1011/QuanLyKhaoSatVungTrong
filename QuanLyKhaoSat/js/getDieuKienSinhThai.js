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
                   
                    <tbody id="tbody-getdieukiensinhthai">
                  <tr>
                    <!-- <td scope="row"></td> -->
                    <td></td>
                    <td>${a.MaDKST}</td>
                    <td>${a.Mua}</td>
                    <td>${a.NhietDoMuaNang}</td>
                    <td>${a.Gio}</td>
                    <td>${a.Lu}</td>
                    <td>${a.TrieuCuong}</td>
                    <td>${a.SuongMuoi}</td>
                    <td>${a.DoPH}</td>
                    <td>
                    <button class="btn btn-success deleteDKST" data-id="${a.MaDKST}">Xóa</button>
                    <button class="btn btn-success" 
                    ><a href="SuaDieuKienSinhThai.html?id=${a.MaDKST}" style="color: black;text-decoration: none;">Sửa</a></button>
                    </td>
                  </tr>
                </tbody>
                   
                        `
                   
                

            }
            document.getElementById('tbody-getdieukiensinhthai').innerHTML = temp


        }
    });

    xhr.open("GET", "http://localhost:52348/api/DieuKienSinhThai");
    xhr.send();
    $('#tbody-getdieukiensinhthai').delegate('.deleteDKST', 'click', event => {
        let id = event.target.getAttribute("data-id");
        xhr.open("DELETE", "http://localhost:52348/api/DieuKienSinhThai/"+ id);
        xhr.send();
        location.reload();
    })
});