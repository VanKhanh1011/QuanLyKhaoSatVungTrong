$(document).ready(function() {
    $('.luuSHthem').click(function(e) {
        var tenSH = $('.tenSH').val()
        var ghichuSH = $('.ghichuSH').val()
        var ttSH = $('.ttSH').val()
        var maCTSH = $('.themmaCTSH').val()
        console.log(tenSH + ghichuSH + ttSH + maCTSH)
        if (tenSH == "" || ghichuSH == "" || ttSH == ""|| maCTSH == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaSH\": ,
                        \n        \"TenSH\": \"${tenSH}\",
                        \n        \"GhiChu\": \"${ghichuSH}\",
                        \n        \"TT\": \"${ttSH==0 ?"false":"true"}\",
                        \n        \"MaCT\":\"${maCTSH}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/SauHai");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })
});