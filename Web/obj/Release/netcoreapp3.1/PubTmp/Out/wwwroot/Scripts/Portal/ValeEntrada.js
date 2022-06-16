$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $(".menuTrazabilidad").addClass("expand");
            $(".submenuTrazabilidad").css("display", "block");
        },
    };


    dsh.init();
});
