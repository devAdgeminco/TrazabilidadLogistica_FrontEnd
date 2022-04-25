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
                    dsh.alerts('Correcto!!', 'success');
                    window.location.href = url_trazabilidad;
                },
                error: function (data) {
                    dsh.alerts(data.responseJSON.value,'danger');
                }
            });
        },

        alerts(mensaje, type) {
            $('#liveAlertPlaceholder').html('');
            var alertPlaceholder = document.getElementById('liveAlertPlaceholder');
            var wrapper = document.createElement('div');
            wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + mensaje + '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>';

            alertPlaceholder.append(wrapper);
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