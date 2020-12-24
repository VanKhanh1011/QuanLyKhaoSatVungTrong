$(document).ready(function() {
    $('.luuLDthem').click(function(e) {
        var tenLD = $('.tenLD').val()
        var doamLD = $('.doamLD').val()
        var tinhchatLD = $('.tinhchatLD').val()
       
        //console.log(tinhDP + huyenDP + xaDP + apDP )
        if (tenLD == "" || doamLD == "" ||tinhchatLD == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaLD\": ,
                        \n        \"TenLD\": \"${tenLD}\",
                        \n        \"DoAm\": \"${doamLD}\",
                        \n        \"DacTrung\": \"${tinhchatLD}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/LoaiDat");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/index.html"
        }
    })
});