$(document).ready(function() {
    $('.luuDKSthem').click(function(e) {
        var TenDot = $('.TenDot').val()
        var MaNVthemnl = $('.MaNVthemnl').val()
      
      console.log(TenDot,MaNVthemnl)
        if (TenDot == "" || MaNVthemnl=="" )
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaBH\": ,
                        \n        \"TenDot\": \"${TenDot}\",
                        \n        \"MaNV\": \"${MaNVthemnl}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/DotKhaoSat");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/indexuser.html"
        }
    })
});