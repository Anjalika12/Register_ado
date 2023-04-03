
function validate() {

    let username = $("#username").val();
    let email = $("#email").val();
    let department = $("#dep").val();
    let designation = $("#des").val();
    let password = $("#pass").val();
    let cpassword = $("#conpass").val();
    let mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    if (username == "") {
        $("#uname").show();
        $("#uname").html("<h6>Enter name</h6>"); // setting html
        // alert("Enter Name");
        event.preventDefault();
    
    }
    else {
        $("#uname").hide();
        // document.getElementById('uname').hidden = true  
    }


    if (email == "") {
        $("#uemailregex").hide();
        $("#uemail").show();
        $("#uemail").html("<h6>Enter email</h6>"); // setting html
        event.preventDefault();   
    }
   else {
        $("#uemail").hide();
        if (!email.match(mailformat)) {
            $("#uemailregex").show();
            $("#uemailregex").html("<h6>Enter valid email</h6>"); // setting html
            event.preventDefault();
        }

        else {
            $("#uemailregex").hide()
        }
    }



    if (department == "") {
        $("#udep").show();
        $("#udep").html("<h6>Enter department</h6>"); // setting html
        event.preventDefault();
    }
    else {
        $("#udep").hide();
    }

    if (designation == "") {
        $("#udes").show();
        $("#udes").html("<h6>Enter designation</h6>"); // setting html
        event.preventDefault();
    }
     else {
        $("#udes").hide();
    }

    if (password == "") {
        $("#upass").show();
        $("#upass").html("<h6>Enter password</h6>"); // setting html
        event.preventDefault();
    }
    else {
        $("#upass").hide();
    }

    if (cpassword != password) {
        $("#uconpass").show();
        $("#uconpass").html("<h6>Passwords didn't matched</h6>"); // setting html
        event.preventDefault();
    }
    else {
     $("#uconpass").hide();
    }


}















//// Document is ready
//debugger
//$(document).ready(function () {
//    // Validate Username
//    $("#usercheck").hide();
//    let usernameError = true;
//    $("#usernames").keyup(function () {
//        validateUsername();
//    });

//    function validateUsername() {
//        let usernameValue = $("#usernames").val();
//        if (usernameValue.length == "") {
//            $("#usercheck").show();
//            usernameError = false;
//            return false;
//        } else if (usernameValue.length < 3 || usernameValue.length > 10) {
//            $("#usercheck").show();
//            $("#usercheck").html("**length of username must be between 3 and 10");
//            usernameError = false;
//            return false;
//        } else {
//            $("#usercheck").hide();
//        }
//    }
//});

//// Validate Email
//const email = document.getElementById("email");
//email.addEventListener("blur", () => {
//    let regex = /^([_\-\.0-9a-zA-Z]+)@([_\-\.0-9a-zA-Z]+)\.([a-zA-Z]){2,7}$/;
//    let s = email.value;
//    if (regex.test(s)) {
//        email.classList.remove("is-invalid");
//        emailError = true;
//    } else {
//        email.classList.add("is-invalid");
//        emailError = false;
//    }
//});

////validate department
//$("#depcheck").hide();
//$("#dep").keyup(function () {
//    validatedep();
//});
//function validatedep() {
//    let depval = $("#dep").val();
//    if (depval.length == "") {
//        $("#depcheck").show();
//        usernameError = false;
//        return false;
//    }
//    else {
//        $("#depcheck").hide();
//    }
//}

////validate designation
//$("#descheck").hide();
//$("#des").keyup(function () {
//    validatedes();
//});
//function validatedes() {
//    let desval = $("#des").val();
//    if (desval.length == "") {
//        $("#descheck").show();
//        usernameError = false;
//        return false;
//    }
//    else {
//        $("#descheck").hide();
//    }
//}

//// Validate Password
//$("#passcheck").hide();
//let passwordError = true;
//$("#password").keyup(function () {
//    validatePassword();
//});
//function validatePassword() {
//    let passwordValue = $("#password").val();
//    if (passwordValue.length == "") {
//        $("#passcheck").show();
//        passwordError = false;
//        return false;
//    }
//    if (passwordValue.length < 3 || passwordValue.length > 10) {
//        $("#passcheck").show();
//        $("#passcheck").html(
//            "**length of your password must be between 3 and 10"
//        );
//        $("#passcheck").css("color", "red");
//        passwordError = false;
//        return false;
//    } else {
//        $("#passcheck").hide();
//    }
//}

//// Validate Confirm Password
//$("#conpasscheck").hide();
//let confirmPasswordError = true;
//$("#conpassword").keyup(function () {
//    validateConfirmPassword();
//});
//function validateConfirmPassword() {
//    let confirmPasswordValue = $("#conpassword").val();
//    let passwordValue = $("#password").val();
//    if (passwordValue != confirmPasswordValue) {
//        $("#conpasscheck").show();
//        $("#conpasscheck").html("**Password didn't Match");
//        $("#conpasscheck").css("color", "red");
//        confirmPasswordError = false;
//        return false;
//    } else {
//        $("#conpasscheck").hide();
//    }
//}

//// Submit button
//$("#submitbtn").click(function () {
//    validateUsername();
//    validatePassword();
//    validateConfirmPassword();
//    validateEmail();
//    validatedep();
//    validatedes();
//    if (
//        usernameError == true &&
//        passwordError == true &&
//        confirmPasswordError == true &&
//        emailError == true
//    ) {
//        return true;
//    } else {
//        return false;
//    }
//});













