/// <reference path="jquery-3.1.1.intellisense.js" />

//AJAX is about loading data in the background and display it on the webpage, without reloading the whole page

//when the document has finnished rendering..
$(document).ready(function () {

    //find and retrieve the current form on the page..
    var form = $("form_photo_create");

    //and start listening for what happens when the form gets submitted..
    form.submit(function (e) {

        //dont send the form automatically!
        e.preventDefault();

        //upload the file (photo) and the form with the help of ajax!
        $.ajax({

            //we are making a post, because the controller action is attributed with the post attribute
            method: "Post",

            url: "/Photo/Create",

            data: new FormData(document.getElementsByTagName("Form")[0]),

            //when our call is done, and we get an answer
            //then we run the following function
            success: function (data) {

                $("div#result").html(data)
            },

            //these are required for us to use formdata!
            processData: false,
            contentType: false
        });
    });
});