$(document).ready(function() {
    $('.luuHTTthem').click(function(e) {
        var tenHTT = $('.tenHTT').val()
        var nguonnuocHTT = $('.nguonnuocHTT').val()
        var themmaKTHTT = $('.themmaKTHTT').val()
       // console.log(tinhDP + huyenDP + xaDP + apDP )
        if (tenHTT == "" || nguonnuocHTT == "" ||themmaKTHTT == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaHTT\": ,
                        \n        \"PhuongThuc\": \"${tenHTT}\",
                        \n        \"NguonNuoc\": \"${nguonnuocHTT}\",
                        \n        \"MaKT\": \"${themmaKTHTT}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/HeThongTuoi");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })
});