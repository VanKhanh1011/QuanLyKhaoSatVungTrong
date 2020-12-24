$(document).ready(function() {
    $('.luuDKSTthem').click(function(e) {
        var muaDKST = $('.muaDKST').val()
        var nangDKST = $('.nangDKST').val()
        var luDKST = $('.luDKST').val()
        var tcDKST = $('.tcDKST').val()
        var smDKST = $('.smDKST').val()
        var gioDKST = $('.gioDKST').val()
        var dophDKST = $('.dophDKST').val()
       // console.log(tinhDP + huyenDP + xaDP + apDP )
        if (muaDKST == "" || nangDKST == "" ||luDKST == ""|| tcDKST==""||smDKST==""||gioDKST==""||dophDKST=="" )
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaDKST\": ,
                        \n        \"Mua\": \"${muaDKST}\",
                        \n        \"NhietDoMuaNang\": \"${nangDKST}\",
                        \n        \"SuongMuoi\": \"${smDKST}\",
                        \n        \"Gio\": \"${gioDKST}\",
                        \n        \"Lu\":\"${luDKST}\",
                        \n        \"TrieuCuong\":\"${tcDKST}\",
                        \n        \"DoPH\":\"${dophDKST}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/DieuKienSinhThai");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/indexuser.html"
        }
    })
});