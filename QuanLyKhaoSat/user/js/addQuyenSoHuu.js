$(document).ready(function() {
    $('.luuQSHthem').click(function(e) {
        var MaVuon = $('.themmaVQSH').val()
        var MaND = $('.themmaNDQSH').val()
        var MaDot = $('.themmaDotQSH').val()
        console.log(MaVuon + MaND + MaDot)
        if (MaVuon == "" || MaND == "" || MaDot == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
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


