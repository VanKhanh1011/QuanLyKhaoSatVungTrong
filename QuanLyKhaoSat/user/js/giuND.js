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
    var iduser = GetURLParameter("iduser");
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function() {
        if (this.readyState === 4) {
            let data = JSON.parse(xhr.responseText)
            let temp = ""
            if(iduser==undefined){
                temp += `
                <a href="./DangNhapUser.html" style="color: black;"><i class="fa fa-user"></i> ĐĂNG NHẬP</a>
                    `
            }else{
                for (var i = 0; i < data.length; i++) {
                    let a = data[i]
                   if(a.MaND==iduser){
                   
                        temp += `
                        <a href="./DangNhapUser.html" style="color: black;"><i class="fa fa-user"></i>Hi ${a.HoTen} </a>
                        <a href="./indexuser.html"></i>ĐĂNG XUẤT</a>
                            `
                    }
    
                }
            }
           
            document.getElementById('dn-dxND').innerHTML = temp
        }
    });
    
    xhr.open("GET", "http://localhost:52348/api/NongDan");
    xhr.send();
});