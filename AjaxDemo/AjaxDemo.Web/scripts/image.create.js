/// <reference path="jquery-3.1.1.intellisense.js" />

$(document).ready(function () {
    var form = $("form"); 

    // Nu vill vi lyssna på vad som händer när man trycker på "Ladda upp"
    form.submit(function (e) {

       
        e.preventDefault();

    

        $.ajax({
            // Vi gör en POST, för att /Home/Index är markerad med HttPost
            method: "POST",

            // Ta en titt på hur vi nu ändrat /Gallery/List
            // Som vi sett innan så returnerade Upload en Lista av bilderna efter att det laddats upp - Hur funkar detta nu?
            url: "/Home/Index",


            // Datan vi ska skicka är av typen FormData, detta låter oss skicka med filen!
            // FormData vill ha ett DOM-element, därför använder vi document.getElementsByTagName, och tar sedan första formuläret vi hittar för vi har bara ett
            data: new FormData(document.getElementsByTagName("form")[0]),

            // När vårt anrop är klart, och vi får ett svar
            // Då kör vi följande funktion
            success: function (data) {

                // Titta nu i Upload.cshtml
                // Ser du att längst ner har vi <div id="result"></div>
                // Följande anrop byter ut HTML-koden som finns i denna div
                // Mot det vår PartialView renderat på server sidan, alltså får vi våra nya bilder!
                $("div#result").html(data);
            },

            // Dessa måste sättas för att vi ska kunna använda FormData!
            processData: false,
            contentType: false
        });
    });
})