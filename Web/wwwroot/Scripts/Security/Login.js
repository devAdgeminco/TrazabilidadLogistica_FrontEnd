$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            console.log(url_getCompanies);
            dsh.GetCompanies();
        },

        GetCompanies() {
            $.ajax({

                cache: false,
                async: true,
                url: "https://localhost:44396/api/Company/companies",
                type: "GET",
                datatype: false,
                contentType: false,
                success: function (data) {
                    console.log(data.company);
                    $("#Company").find('option').remove();
                    for (var i = 0; i < data.company.length; i++) {
                        $("#Company").append("<option value='" + data.company[i].CodEmpresa + "'> " + data.company[i].RazonSocial + " </option>");
                    }

                    $("#Company").val($("#Company option:first").val());
                }

            });
        },
    };

    dsh.init();
});