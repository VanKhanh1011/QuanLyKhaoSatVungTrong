$(document).ready(function () {
  let xhr = new XMLHttpRequest();
  let iduser = "";
  xhr.addEventListener("readystatechange", function () {
    if (this.readyState === 4) {
      let data = JSON.parse(xhr.responseText);
      console.log(data)
      
      var str=""
      for (var i = 0; i < data.length; i++) {
          if(data.length-1==i){
          str+=`\n['${data[i].Tinh}', ${data[i].soluongVuon}]\n`
          }
          else{
          str+=`\n['${data[i].Tinh}', ${data[i].soluongVuon}],`
          }
      }
      var dataArray = [
        ['Task', 'Hours per Day']       
      ];
      var newDataArray = dataArray.concat(eval("[" + str + "]"));
        // Load google charts
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawChart);
        // Draw the chart and set the chart values
        function drawChart() {
          var data = google.visualization.arrayToDataTable(newDataArray);

          // Optional; add a title and set the width and height of the chart
          var options = { title: "My Average Day", width: 550, height: 400 };

          // Display the chart inside the <div> element with id="piechart"
          var chart = new google.visualization.PieChart(
            document.getElementById("piechartDP")
          );
          chart.draw(data, options);
      }
    }
  });
  xhr.open("GET", "http://localhost:52348/api/DiaPhuong");
  xhr.send();
});
