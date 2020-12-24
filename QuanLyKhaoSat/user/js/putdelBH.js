// $(document).ready(function() {
//     var query = window.location.search.substring(1);
//     var vars = query.split("=");
//     var id = vars[1];
//     let Id_Product = ""
//     let xhr = new XMLHttpRequest();
//     xhr.addEventListener("readystatechange", function() {
//         if (this.readyState === 4) {
//             let item = JSON.parse(xhr.response)
//             Id_Product = item.MaBH
//             let str = `
//             <form action="" class="ttsuabh">
//             <h2>Thông Tin Bệnh Hại</h2>
//             <label for="">Tên Bệnh Hại: </label>  <input type="text" placeholder="" class="tenbhsua" style="outline: none;" value="${item.TenBH}">
//             <br>
//             <label for="">Ghi Chú : </label>  <input type="text" placeholder="" class="ghichubhsua"tyle="outline: none;" value="${item.GhiChu}">
//             <br>
//             <label for="">Trạng Thái : </label> 
//             <select class="ttbhsua" id="ttbhsua" style="margin-right: 30px;margin-bottom: 20px; ">
//               <option value="0">0</option>
//               <option value="1">1</option>
//           </select>
//             <br>
//             <label for="suamaCTBH">Mã Cây Trồng:</label> 
//             <select class="suamaCTBH" id="suamaCTBH" >
//               <option value="value="${item.MaCT}""></option>
              
//           </select>
//             <button class="btn btnLuu luuSuaBH">Lưu</button>
//             <button class="btn"><a href="index.html" class="closebtn" style="text-decoration:none">Hủy</a></button>
//           </form>
//             `
//             document.querySelector(".ttsuabh").innerHTML = str
//         }
//     });
//     xhr.open("GET", "http://localhost:52348/api/BenhHai/" + id);

//     xhr.send();
//     $('.ttsuabh').delegate('#luuSuaBH', 'click', event => {
//         var tenbhsua = $('.tenbhsua').val()
//     var ghichubhsua = $('.ghichubhsua').val()
//     var ttbhsua = $('.ttbhsua').val() 
//     var suamaCTBH = $('.suamaCTBH').val()
//     if (tenbhsua == "" || ghichubhsua == "" || ttbhsua == "" ||suamaCTBH=="")
//             alert("Bạn chưa nhập đủ chỉ tiết ")
//         else {
//             let updatedata = `
//             {
//                 \n        \"MaBH\":${Id_Product}\":,
//                 \n        \"tenBH\": \"${tenbhsua}\",
//                 \n        \"GhiChu\": \"${ghichubhsua}\",
//                 \n        \"TT\": \"${ttbhsua==0 ?false:true}\",
//                 \n        \"MaCT\":\"${suamaCTBH}\",
//                 \n    }
//                     `


//             xhr.open("PUT", "https://localhost:52348/api/BenhHai/" + id);
//             xhr.setRequestHeader("Content-Type", "application/json");
//             xhr.send(updatedata);
//             window.location = "/ChitietSanpham.html?id=" + Id_Product
//         }
//     })

// })

