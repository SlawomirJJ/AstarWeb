// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    console.log("Page is ready");
    $(".Pole").click(function (event) {
        event.preventDefault();
        console.log("button was clicked");
        var poleId = $(this).attr('data-variableid2');
        //var poleId = document.getelementsbyclassname('demo').getAttribute('data-value');
        //var poleId = element.getAttribute('data-myValue');
        console.log("pole " + poleId + " zostało kliknięte")
    })
})