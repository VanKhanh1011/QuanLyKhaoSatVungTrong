$(document).ready(function() {
    $('.luuPNL').click(function() {
        
        var MaVuon = $('.chonVuon').val()
        var MaND = $('.getMaND').val()
        var MaDot = $('.getMaDKS').val()
        alert(MaVuon)
        alert(MaND)
        alert(MaDot)
        console.log(MaVuon + MaND + MaDot)
        if (MaVuon == "" || MaND == "" || MaDot == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            alert(MaVuon)
            alert(MaND)
            alert(MaDot)
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaSoHuu\": ,
                        \n        \"MaVuon\": \"${MaVuon}\",
                        \n        \"MaND\": \"${MaND}\",
                        \n        \"MaDot\": \"${MaDot}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/QuyenSoHuu");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/QuyenSoHuu.html"
        }
    })
});


