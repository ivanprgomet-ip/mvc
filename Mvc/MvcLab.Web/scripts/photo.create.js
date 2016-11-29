/// <reference path="jquery-3.1.1.intellisense.js" />

//$(document).ready(function () {

//    var form = $("form");//find the form defined on the page
    
//    form.submit(function (e) {//this happens when the form is submitted

//        e.preventDefault();

//        $.ajax({
//            method: "POST",
//            url: '/Photo/Create',
//            data: new FormData(document.getElementsByTagName("form")[0]),
//            success: function (data) {
//                //this gets returned as html AFTER we have recieved the eg. partial view _photo or whatever we choose. 
//                //so all that html gets returned into the div with id result as html after getting the view html on the serverside.
//                $('#result').html(data); 
//            },
//            processData: false,
//            contentType: false
//        });

//    })
//});

    //$(document).ajaxStart(function () {
    //    //show a progress modal of your choosing
    //    showProgressModal('loading');
    //});
    //$(document).ajaxStop(function () {
    //    //hide the progress modal 
    //    hideProgressModal();
//});


//insert loader gif into view
//when clicked on submit, show the gif img
//onbegin (showloadingindciator) , oncomplete(hideloadingindicator)