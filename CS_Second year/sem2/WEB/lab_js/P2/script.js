function checkInfo() {
    var name = document.getElementById("name");
    var date_of_birth = document.getElementById("date_of_birth");
    var age = document.getElementById("age");
    var email = document.getElementById("e-mail");
    removeBorders(name, date_of_birth, age, email);

    var msg = validateInput(name, date_of_birth, age, email);
    if (msg) {
        window.alert(msg);
        return;
    }

    window.alert("Info is correct");
}

function validateInput(name, date_of_birth, age, email) {
    var msg = "";

    msg = isNull(name, date_of_birth, age, email);
    if (msg)
        return msg;

    var calculatedAge = calculateAge(date_of_birth.value);
    if (age.value != calculatedAge) {
        msg = "Age is invalid";
        age.style.border = "thick solid red";
        return msg;
    }

    var emailRegex = /\S+@\S+\.\S+/;
    if(!emailRegex.test(email.value)) {
        msg = "E-mail is invalid";
        email.style.border = "thick solid red";
        return msg;
    }
        
    return msg;
}

function isNull(name, date_of_birth, age, email) {
    var msg = ""

    if (name.value === "") {
        msg = msg.concat("Name cannot be empty\n");
        name.style.border = "thick solid red";
    }
    if (date_of_birth.value === "") {
        msg = msg.concat("Date of birth cannot be empty\n");
        date_of_birth.style.border = "thick solid red";
    }
    if (age.value === "") {
        msg = msg.concat("Age cannot be empty\n");
        age.style.border = "thick solid red";
    }
    if (email.value === "") {
        msg = msg.concat("E-mail cannot be empty");
        email.style.border = "thick solid red";
    }

    return msg;
}

function calculateAge(date_of_birth) {
    var today = new Date();
    var birthDate = new Date(date_of_birth);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}

function removeBorders(name, date_of_birth, age, email) {
    name.style.removeProperty('border');
    date_of_birth.style.removeProperty('border');
    age.style.removeProperty('border');
    email.style.removeProperty('border');
}