$(document).ready(function() {
    $('.luuKSCthem').click(function(e) {
        var tenKSC = $('.tenKSC').val()
        var ghichuKSC = $('.ghichuKSC').val()
        var themmaKTKSC = $('.themmaKTKSC').val()
       // console.log(tinhDP + huyenDP + xaDP + apDP )
        if (tenKSC == "" || ghichuKSC == "" ||themmaKTKSC == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaKSC\": ,
                        \n        \"PhuongPhap\": \"${tenKSC}\",
                        \n        \"GhiChu\": \"${ghichuKSC}\",
                        \n        \"MaKT\": \"${themmaKTKSC}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/KiemSoatCo");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/indexuser.html"
        }
    })
});