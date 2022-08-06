function displayCities(city) {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("test").innerHTML = this.responseText;
        }
    };
    xmlhttp.open("GET", "cities.php?c=" + city, true);
    xmlhttp.send();
}

function displayCitiesJQuery(city) {
    $.get("cities.php?c=" + city, function(data, status){
        if (status == "success") {
            document.getElementById("test").innerHTML = data;
        }
      });
}