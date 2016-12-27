/// <reference path="jquery-3.1.1.intellisense.js" />
/// <reference path="jquery-3.1.1.js" />

/*
Events

    This is the full list of Ajax events, and in the order in which they are triggered. The indented events are triggered for each and every Ajax request (unless a global option has been set). The ajaxStart and ajaxStop events are events that relate to all Ajax requests together.

    ajaxStart (Global Event)
        This event is triggered if an Ajax request is started and no other Ajax requests are currently running.
    beforeSend (Local Event)
        This event, which is triggered before an Ajax request is started, allows you to modify the XMLHttpRequest object (setting additional headers, if need be.)
    ajaxSend (Global Event)
        This global event is also triggered before the request is run.
    success (Local Event)
        This event is only called if the request was successful (no errors from the server, no errors with the data).
    ajaxSuccess (Global Event)
        This event is also only called if the request was successful.
    error (Local Event)
        This event is only called if an error occurred with the request (you can never have both an error and a success callback with a request).
    ajaxError (Global Event)
        This global event behaves the same as the local error event.
    complete (Local Event)
        This event is called regardless of if the request was successful, or not. You will always receive a complete callback, even for synchronous requests.
    ajaxComplete (Global Event)
        This event behaves the same as the complete event and will be triggered every time an Ajax request finishes.
    ajaxStop (Global Event)
        This global event is triggered if there are no more Ajax requests being processed.

*/

var loader = $(".loader").hide();

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
            beforeSend: function(){
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



