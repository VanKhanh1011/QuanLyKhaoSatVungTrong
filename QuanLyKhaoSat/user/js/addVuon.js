$(document).ready(function() {
    $('.luuVuonthem').click(function(e) {
        var TenVuon = $('.TenVuonThem').val()
        var MaKT = $('.ThemmaKTV').val()
        var MADKST = $('.ThemmADKSTV').val()
        var MaCT = $('.ThemmaCTV').val()
        var MaLD = $('.ThemmaLDV').val()
        var MaHT = $('.ThemmaHTV').val()
        var MaDP = $('.ThemmaDPV').val()
        var DienTich= $('.DienTichThem').val()
        console.log(TenVuon + MaKT + ttSH + maCTSH)
        if (tenSH == "" || ghichuSH == "" || MADKST == ""|| MaCT == ""||DienTich==""||MaLD==""||MaHT==""||MaDP==""||DienTich=="")
            alert("Bạn chưa nhập đầy đủ thông tin ")
        else {
            let xhr = new XMLHttpRequest();
            let data = `
                    {
                        \n        \"MaVuon\": ,
                        \n        \" TenVuon\": \"${TenVuon}\",
                        \n        \"MaKT\": \"${MaKT}\",
                        \n        \"MADKST\": \"${MADKST}\",
                        \n        \"MaCT\":\"${MaCT}\",
                        \n        \"MaLD\":\"${MaLD}\",
                        \n        \"MaHT\":\"${MaHT}\",
                        \n        \"MaDP\":\"${MaDP}\",
                        \n        \"DienTich\":\"${DienTich}\",
                        \n
                    }
                    `
            xhr.open("POST", "http://localhost:52348/api/Vuon");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.send(data);
            window.location = "/indexuser.html"
        }
    })
});