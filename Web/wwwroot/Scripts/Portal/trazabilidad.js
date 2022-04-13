$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            dsh.GetRequerimientos();
            dsh.GetRequerimientoDetalle('0007395');
        },

        GetRequerimientos() {
            $.ajax({

                cache: false,
                async: true,
                url: url_getRequerimientos,
                type: "GET",
                data: {
                    fecIni: new Date("01-01-2022").toUTCString(),
                    fecFin: new Date("04-01-2022").toUTCString()
                },
                datatype: false,
                contentType: false,
                success: function (data) {
                    console.log(data.value);
                },
                error: function () {
                    console.log("Error");
                }
            });
        },

        GetRequerimientoDetalle(idReq) {
            $.ajax({

                cache: false,
                async: true,
                url: url_getRequerimientoDetalle,
                type: "POST",
                data: {
                    idReq: '0007395'
                },
                success: function (data) {
                    console.log(data.value);
                },
                error: function () {
                    console.log("Error");
                }
            });
        },
    };


    dsh.init();
});



