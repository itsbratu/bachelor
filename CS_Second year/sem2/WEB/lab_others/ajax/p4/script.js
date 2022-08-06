function handleMove(str) {
    var xhttp;
    xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            if (this.responseText == "fx") {

                document.getElementById("table").classList.add("cover");
                document.getElementById("fin").innerHTML = "X WON";

            }

            else if (this.responseText == "f0") {

                document.getElementById("table").classList.add("cover");
                document.getElementById("fin").innerHTML = "0 WON";

            }

            else if (this.responseText == "fr") {

                document.getElementById("table").classList.add("cover");
                document.getElementById("fin").innerHTML = "REMIZA!";

            }
            else {
                var response = parseInt(this.responseText);
                response = response + 1;
                response = response.toString();
                document.getElementById(response).innerHTML = "0";
                response = parseInt(response);
                arr[response - 1] = "0";
            }
        }
    };
    xhttp.open("GET", "server.php?arr=" + str, true);
    xhttp.send(null);
}