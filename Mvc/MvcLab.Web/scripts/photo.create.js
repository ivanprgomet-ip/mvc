/// <reference path="jquery-1.10.2.intellisense.js" />

//ajax for uploading a photo

(function () {
    //get the photo create form
    var form = document.getElementById("form_photo_create");

    form.addEventListener("Submit", function (e) {
        e.preventDefault();

        //get the photo description textbox value of the form
        var photoDescription = document.getElementById("photo_create_description");

        //alert the description just submitted
        alert(photoDescription);
    });

})();