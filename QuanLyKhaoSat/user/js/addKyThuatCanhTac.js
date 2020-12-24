$(document).ready(function() {
    $('.luuKTCTthem').click(function(e) {
        var kcHang = $('.kcHang').val()
        var lenmo = $('.lenmo').val()
       // console.log(tinhDP + huyenDP + xaDP + apDP )
        if (kcHang == "" || lenmo == "")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaDKST\": ,
                        \n        \"kcHang\": \"${kcHang}\",
                        \n        \"lenmo\": \"${lenmo}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/KyThuatCanhTac");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/indexuser.html"
        }
    })
});