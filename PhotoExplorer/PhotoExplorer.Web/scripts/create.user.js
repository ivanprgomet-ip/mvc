/// <reference path="jquery-3.1.1.intellisense.js" />
/// <reference path="jquery-3.1.1.js" />

var loader = $(".loader").hide();
var form = $('form');//theres only one form on the page anyway

form.on("submit", function (e) {//attach event handler using jquery
    e.preventDefault();
    //if (form.valid) {
    $.ajax({
        method: "POST",
        url: "/Authenticate/Register",
        data: new FormData(form[0]),
        success: function (data) {
            $("#register-msg").append("user successfully registered");
        },
        error: function (e) {
            $("#register-msg").append("something went soo wrong");
        },
        beforeSend: function () {
            loader.show();
        },
        complete: function () {
            loader.hide();
        },
        processData: false,
        contentType: false
    });
    //}
})
