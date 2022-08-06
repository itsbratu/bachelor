/// <reference path="typings/globals/jquery/index.d.ts" />

function validate(){
    errMsg = ""

    let name = $("#name").val();
    let data = $("#data").val();
    let age = $("#varsta").val();
    let email = $("#email").val();

    var regexName = /^[a-zA-Z]+$/;
    var regexEmail = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

    if (!name.match(regexName)){
        errMsg +="Nume invalid\n"
        $("#name").css("borderColor", "red");
    }
    else{
        $("#name").css("borderColor", "green");
    }


    if(isNaN(age) || age > 99 || age < 1){
        errMsg +="Varsta invalida\n"
        $("#varsta").css("borderColor", "red");
    }
    else{
        $("#varsta").css("borderColor", "green");
    }


    if(data.length == 0){
        errMsg +="Data invalida\n"
        $("#data").css("borderColor", "red");
    }
    else{
        $("#data").css("borderColor", "green");
    }


    if(!email.match(regexEmail)){
        errMsg +="Email invalid\n"
        $("#email").css("borderColor", "red");
    }
    else{
        $("#email").css("borderColor", "green");
    }


    if (errMsg != "") {
        alert(errMsg);
    }
}