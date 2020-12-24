$(document).ready(function() {
    $('.luuBHthem').click(function(e) {
        var tenBH = $('.tenBH').val()
        var ghichuBH = $('.ghichuBH').val()
        var ttBH = $('.ttBH').val()
        var maCTBH = $('.themmaCTBH').val()
        console.log(tenBH + ghichuBH + ttBH + maCTBH)
        if (tenBH == "" || ghichuBH == "" || ttBH == ""|| maCTBH == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaBH\": ,
                        \n        \"TenBH\": \"${tenBH}\",
                        \n        \"GhiChu\": \"${ghichuBH}\",
                        \n        \"TT\": \"${ttBH==0 ?"false":"true"}\",
                        \n        \"MaCT\":\"${maCTBH}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/BenhHai");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/BenhHai.html"
        }
    })
});