// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    console.log("Page is ready");
    $(document).on("click",".PoleBtn",function (event) {
        event.preventDefault();
        var poleId = $(this).val();
        console.log("pole " + poleId + " zostało kliknięte");
        doButtonUpdate(poleId);
    })

    function doButtonUpdate(poleId) {
        console.log("pole " + poleId + " w funkcji doButtonUpdate");
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/Pole/PoleStart',
            data: {
                "poleId": poleId
            },
            success: function (data) {
                console.log(data);
                $("#" + poleId).html(data);
            }
        })

        console.log("pole " + poleId + " koniec");
    }
})