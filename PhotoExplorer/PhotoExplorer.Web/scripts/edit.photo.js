/// <reference path="jquery-3.1.1.js" />

var form = $('form');

form.on('submit', function (e) {

    e.preventDefault();

    var formdata = new FormData(form[0]);

    $.ajax({
        url: "/Account/PhotoEdit",
        method: "post",
        data: formdata,
        processData: false,
        contentType: false,
        success: function (data) {
            console.log("edit suceeded");
            window.location = $('#BackToDetails').attr('href');
        },
        error: function (data) {
            console.log("Couldn't update image details");
        }
    });

});