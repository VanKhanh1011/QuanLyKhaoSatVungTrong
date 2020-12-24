let maDSK

//$(document).ready(function () {
  $(".both_child").delegate("#getMaDKS", "change", () => {
    //event.preventDefault();
    var madot = $("#getMaDKS").val();

    for (var i = 0; i < maDSK.length; i++) {
      if (madot == maDSK[i].MaDot) {
        let temp2 = `
       <label for="ngayKS">Ngày Khảo sát</label> <input type="text" class="ngayKS" id="ngayKS" value=${maDSK[i].Ngay}>
                            <br>
      <label for="NVTH">Nhân Viên Thực Hiện:</label> <input type="text" class="NVTH" id="NVTH" value=${maDSK[i].TenNV}>
                            <br>
                            `;
        document.getElementById("getttDKS").innerHTML = temp2;
        break;
      }
    }
  });
//});


function getMaDKS(callback) { 
  let xhr = new XMLHttpRequest();
  xhr.open("GET", "http://localhost:52348/api/DotKhaoSat");
  xhr.send();

  xhr.addEventListener("readystatechange", function () {
    if (this.readyState === 4) {
      maDSK = JSON.parse(xhr.responseText);

      var n = maDSK.length;
      let data = [];
      for (var i = 0; i < n; i++) {
        data[i] = maDSK[n - 1 - i];
      }
      let temp = `<select name="" id="getMaDKS" class="getMaDKS">
      <option value="0">Chọn</option>
      `;
      for (var i = 0; i < data.length; i++) {
        let a = data[i];

        temp += `<option value="${a.MaDot}">${a.TenDot}</option>`;
      }
      temp += `</select>`;

      callback(temp)
    }
  })
}