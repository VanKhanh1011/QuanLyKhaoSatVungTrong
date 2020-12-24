$(document).ready(function() {
    $('.luuDPthem').click(function(e) {
        var tinhDP = $('.tinhDP').val()
        var huyenDP = $('.huyenDP').val()
        var xaDP = $('.xaDP').val()
        var apDP = $('.apDP').val()
        console.log(tinhDP + huyenDP + xaDP + apDP )
        if (tinhDP == "" || huyenDP == "" ||xaDP == ""|| apDP=="" )
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaDP\": ,
                        \n        \"Tinh\": \"${tinhDP}\",
                        \n        \"Huyen\": \"${huyenDP}\",
                        \n        \"Xa\": \"${xaDP}\",
                        \n        \"Ap\":\"${apDP}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/DiaPhuong");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/indexuser.html"
        }
    })
});