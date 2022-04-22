$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $("#buttonCerrarSesion").click(function () {
                dsh.SET_CerrarSesion();
            });
        },

        SET_CerrarSesion() {
            $.ajax({
                cache: false,
                async: true,
                url: URL_CERRARSESION,
                type: "POST",
                datatype: "json",
                contentType: "application/json;charset=UTF-8",
                data: null,
                success: function (data) {
                    document.location.href = URL_AUTENTICACION;
                },
                error: function (request) {
                }
            });
        }
    };


    dsh.init();
});
