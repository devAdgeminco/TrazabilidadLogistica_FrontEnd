$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $(".menuCodigoBarras").addClass("expand");
            $(".submenuCodigoBarras").css("display", "block");
        },
    };


    dsh.init();
});
