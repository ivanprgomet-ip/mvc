/// <reference path="jquery-3.1.1.js" />

var form = $('form');//theres only one form on the page anyway

form.on("submit", function (e) {//attach event handler using jquery
    e.preventDefault();
    //if (form.valid) {
        $.ajax({
            method: "POST",
            url: "/Account/AlbumCreate",

            data: new FormData(form[0]),
            success: function (data) {
                $("#create-msg").append("album successfully created");
            },
            error: function (e) {
                $("#create-msg").append("something went soo wrong");
            },
            processData: false,
            contentType: false
        });
    //}
})