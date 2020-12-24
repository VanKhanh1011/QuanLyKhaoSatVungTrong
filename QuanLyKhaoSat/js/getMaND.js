
function getMaND(callback) {
  let xhr = new XMLHttpRequest();
  xhr.open("GET", "http://localhost:52348/api/NongDan");
  xhr.send();
  
  let data14;

  xhr.addEventListener("readystatechange", function () {
    if (this.readyState === 4) {
      data14 = JSON.parse(xhr.responseText);

      var n = data14.length;
      let data4 = [];
      for (var i = 0; i < n; i++) {
        data4[i] = data14[n - 1 - i];
      }
      let temp4 = `<select class="getMaND" id="getMaND">`;
      for (var i = 0; i < data4.length; i++) {
        let a4 = data4[i];

        temp4 += `<option value="${a4.MaND}">${a4.HoTen}</option>`;
      }
      temp4 += `</select>`;

      callback(temp4)
    }
  })
}