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
                   
                <tbody id="tbody-getsauhai">
                  <tr id="get-sauhai">
                    <!-- <td scope="row"></td> -->
                    <td></td>
                    <td>${a.MaSH}</td>
                    <td>${a.TenSH}</td>
                    <td>${a.GhiChu}</td>
                    <td>${a.TT}</td>
                    <td>${a.MaCT}</td>
                    
                  </tr>
                  
                </tbody>
              
                   
                        `
                   
                

            }
            document.getElementById('tbody-getsauhai').innerHTML = temp


        }
    });

    xhr.open("GET", "http://localhost:52348/api/SauHai");
    xhr.send();
    $('#tbody-getsauhai').delegate('.deleteSH', 'click', event => {
        let id = event.target.getAttribute("data-id");
        xhr.open("DELETE", "http://localhost:52348/api/SauHai/"+ id);
        xhr.send();
        location.reload();
    })
    $('#tbody-getbenhhai').delegate('.deleteBH', 'click', event => {
        let id = event.target.getAttribute("data-id");
        xhr.open("DELETE", "http://localhost:52348/api/BenhHai/"+ id);
        xhr.send();
        location.reload();
    })
    // $('.luuSHthem').click(function(e) {
    //     var tenSH = $('.tenSH').val()
    //     var ghichuSH = $('.ghichuSH').val()
    //     var ttSH = $('.ttSH').val()
    //     var themmaCTSH = $('.themmaCTSH').val()
    //     console.log(tenSH +ghichuSH + ttSH + themmaCTSH)
    //     if ( tenSH == "" || ghichuSH == "" ||ttSH == ""||  themmaCTSH == "")
    //         alert("Bạn chưa nhập đầy đủ thông tin ")
    //     else {
    //         let xhr = new XMLHttpRequest();
    //         let data = `
    //                 {
    //                     \n        \"MaSH\": ,
    //                     \n        \"TenSH\": \"${tenSH}\",
    //                     \n        \"GhiChu\": \"${ghichubhsua}\",
    //                     \n        \"TT\": \"${ghichuSH==0 ?"false":"true"}\",
    //                     \n        \"MaCT\":\"${ themmaCTSH}\",
    //                     \n
    //                 }
    //                 `
    //         xhr.open("PUT", "http://localhost:52348/api/SauHai/" + id);
    //         xhr.setRequestHeader("Content-Type", "application/json");
    //         xhr.send(updatedata);
    //         window.location = "/SuaSauHai.html?id=" + id
    //     }
    // })
});