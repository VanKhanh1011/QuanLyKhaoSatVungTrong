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
                   
                    <tbody id="tbody-getbenhhai">
                    <tr>
                      <!-- <td scope="row"></td> -->
                      <td></td>
                      <td>${a.MaBH}</td>
                            <td>${a.TenBH}</td>
                            <td>${a.GhiChu}</td>
                            <td>${a.TT}</td>
                            <td>${a.MaCT}</td>
                      <td>
                 
                      </td>
                    </tr>
                   
                  </tbody>
              
                   
                        `
                   
                

            }
            document.getElementById('tbody-getbenhhai').innerHTML = temp


        }
    });

    xhr.open("GET", "http://localhost:52348/api/BenhHai");
    xhr.send();
    $('#tbody-getbenhhai').delegate('.deleteBH', 'click', event => {
        let id = event.target.getAttribute("data-id");
        xhr.open("DELETE", "http://localhost:52348/api/BenhHai/"+ id);
        xhr.send();
        location.reload();
    })
    $('.suaBH').click(function(e) {
        var tenbhsua = $('.tenbhsua').val()
        var ghichubhsua = $('.ghichubhsua').val()
        var ttbhsua = $('.ttbhsua').val()
        var suamaCTBH = $('.suamaCTBH').val()
        console.log(tenbhsua +ghichubhsua + ttbhsua + suamaCTBH)
        if (tenbhsua == "" || ghichubhsua == "" || ttbhsua == ""||  suamaCTBH == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaBH\": ,
                        \n        \"TenBH\": \"${tenbhsua}\",
                        \n        \"GhiChu\": \"${ghichubhsua}\",
                        \n        \"TT\": \"${ttbhsua==0 ?"false":"true"}\",
                        \n        \"MaCT\":\"${ suamaCTBH}\",
                        \n
                    }
                    `
            xhr.open("PUT", "http://localhost:52348/api/BenhHai/" + id);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(updatedata);
            window.location = "/SuaBenhHai.html?id=" + id
        }
    })

});