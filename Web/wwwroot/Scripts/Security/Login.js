$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            dsh.GetCompanies();

            $("#btnLogin").on("click", function () {
                dsh.Login();
            })
        },

        Login() {

            var formData = new FormData($("#formLogin")[0]);
            //var formData = new FormData();
            //formData.append("User", "luis");
            //formData.append("Contrasena", "12345");
            //formData.append("Company", "1");

            $.ajax({

                cache: false,
                async: true,
                url: url_Authenticate,
                type: "POST",
                data: formData,
                processData: false, 
                contentType: false,
                success: function (data) {
                    console.log(data);

                    window.location.href = url_trazabilidad;
                },
                error: function () {
                    console.log("Error");
                }
            });
        },

        GetCompanies() {
            $.ajax({

                cache: false,
                async: true,
                url: url_getCompanies,
                type: "GET",
                data: {
                    //value: "12345"
                },
                datatype: false,
                contentType: false,
                success: function (data) {
                    var ls = JSON.parse(data.value).company;

                    $("#Company").find('option').remove();
                    for (var i = 0; i < ls.length; i++) {
                        $("#Company").append("<option value='" + ls[i].CodEmpresa + "'> " + ls[i].RazonSocial + " </option>");
                    }

                    $("#Company").val($("#Company option:first").val());
                },
                error: function () {
                    console.log("Error");
                }
            });
        },
    };

    dsh.init();
});