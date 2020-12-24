$(document).ready(function() {
    $('.luuCTthem').click(function(e) {
        var loaiCT = $('.loaiCT').val()
        var giongCT = $('.giongCT').val()
        var tuoiCT = $('.tuoiCT').val()
        var motaCT = $('.motaCT').val()
        var ttCT = $('.ttCT').val()
        console.log(loaiCT + giongCT + tuoiCT + motaCT + ttCT)
        if (loaiCT == "" || giongCT == "" || tuoiCT == ""|| motaCT == ""|| ttCT=="" )
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaCT\": ,
                        \n        \"Loai\": \"${loaiCT}\",
                        \n        \"Giong\": \"${giongCT}\",
                        \n        \"Tuoi\": \"${tuoiCT}\",
                        \n        \"MoTa\":\"${motaCT}\",
                        \n        \"TT\":\"${ttCT==0 ?"false":"true"}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/CayTrong");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/indexuser.html"
        }
    })
});