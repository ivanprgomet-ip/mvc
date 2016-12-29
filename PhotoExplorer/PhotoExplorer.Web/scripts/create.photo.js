/// <reference path="jquery-3.1.1.js" />

var form = $('form');
var loader = $(".loader").hide();

form.on('submit', function (e) {

    e.preventDefault();

    var formdata = new FormData(form[0]);

    $.ajax({
        url: "/Account/PhotoCreate",
        method: "post",
        data: formdata,
        processData: false,
        contentType: false,
        success: function (data) {
            $("#photocreate-msg").append("photo successfully uploaded");
        },
        error: function (data) {
            $("#photocreate-msg").append("something went soo wrong");
        },
        beforeSend: function () {
            loader.show();
        },
        complete: function () {
            loader.hide();
        }
    });

});