// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    console.log("Page is ready");
     /////////////          Punkt Startowy           //////////////////////
    $(document).on("click", ".pktStartowy", function (event) {
        var flaga = true;
        
            $(document).on("click", ".PoleBtn", function (event) {
                event.preventDefault();
                if (flaga == true) {
                flaga = false;
                    var StartId = $(this).val();
                    console.log("pole " + StartId + " zostało kliknięte");
                    StartUpdate(StartId);
                }
            })
        
    
    })

    function StartUpdate(StartId) {
        console.log("pole " + StartId + " w funkcji doButtonUpdate");
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/Pole/PoleStart',
            data: {
                "StartId": StartId
            },
            success: function (data) {
                console.log(data);
                $("#" + StartId).html(data);
            }
        })

        console.log("pole " + StartId + " koniec");
    }


    /////////////          Punkt końcowy           //////////////////////
    $(document).on("click", ".pktKoncowy", function (event) {
        var flaga = true;
        console.log("Wciśnięto przycisk koniec");
        $(document).on("click", ".PoleBtn", function (event) {
            event.preventDefault();
            if (flaga == true) {
                flaga = false;
                var KoniecId = $(this).val();
                console.log("pole " + KoniecId + " zostało kliknięte");
                KoniecUpdate(KoniecId);
            }
        })


    })

    function KoniecUpdate(KoniecId) {
        console.log("pole " + KoniecId + " w funkcji doButtonUpdate");
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/Pole/PoleKoniec',
            data: {
                "KoniecId": KoniecId
            },
            success: function (data) {
                console.log(data);
                $("#" + KoniecId).html(data);
            }
        })

        console.log("pole " + KoniecId + " koniec");
    }



     /////////////          Wyznaczenie trasy           //////////////////////
    $(document).on("click", ".WyznaczenieTrasy", function (event) {
            event.preventDefault();
                //var Pola = $(this).val();
                //console.log("pole " + StartId + " zostało kliknięte");
            WyznaczenieTrasy();
        })


    function WyznaczenieTrasy() {
        console.log("w funkcji wyznaczenieTrasy");
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/Pole/WyznaczenieTrasy',
            success: function (data) {
                console.log(data);
                $(".Siatka").html(data);
            }
        })

        console.log(" koniec wyznaczania trasy");
    }

    function Error() {
        console.log("w funkcji Error");
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/Pole/Error',
            success: function (data) {
                console.log(data);
                $(".Siatka").html(data);
            }
        })

        console.log(" koniec wyznaczania trasy");
    }

    /////////////////////         Przeszkody          //////////////////////
    $(document).on("click", ".DodaniePrzeszkod", function (event) {
        event.preventDefault();
        DodaniePrzeszkod();
    })

    function DodaniePrzeszkod() {
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/Pole/DodaniePrzeszkod',
            success: function (data) {
                console.log(data);
                $(".Siatka").html(data);
            }
        })
    }

    /////////////////////         Rozmiar          //////////////////////
    $(document).on("click", "#Rozmiar", function (event) {
        event.preventDefault();
        var Rozmiar = $(this).val();
        ZmianaRozmiaru(Rozmiar);
        })



    function ZmianaRozmiaru(Rozmiar) {
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/Pole/Rozmiar',
            data: {
                "Rozmiar": Rozmiar
            },
            success: function (data) {
                console.log(data);
                $(".Siatka").html(data);
            }
        })
    }



})