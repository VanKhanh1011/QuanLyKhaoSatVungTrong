$(document).ready(function() {
    $('.luuHTthem').click(function(e) {
        var soluongCT = $('.soluongCT').val()
        var ttHT = $('.ttHT').val()
        var nangsuatHT = $('.nangsuatHT').val()
        var tileHT = $('.tileHT').val()
        var ghichuHT = $('.ghichuHT').val()
        console.log(soluongCT + ttHT + nangsuatHT + tileHT+ghichuHT )
        if (soluongCT == "" || ttHT == "" ||nangsuatHT == ""|| tileHT==""||ghichuHT=="" )
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaHT\": ,
                        \n        \"SoLuongCay\": \"${soluongCT}\",
                        \n        \"NangSuat\": \"${ttHT}\",
                        \n        \"TiLe\": \"${nangsuatHT}\",
                        \n        \"GhiChu\": \"${tileHT}\",
                        \n        \"TT\":\"${ghichuHT}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/HienTrang");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/indexuser.html"
        }
    })
});