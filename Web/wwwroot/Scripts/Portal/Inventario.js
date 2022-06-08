var oList;

$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $(".menuInventario").addClass("expand");
            $(".submenuInventario").css("display", "block");

            $('#btnupload').on('click', function () {
                var fileExtension = ['xls', 'xlsx'];
                var filename = $('#fileupload').val();
                if (filename.length == 0) {
                    alert("Seleccione Archivo Excel.");
                    return false;
                }
                else {
                    var extension = filename.replace(/^.*\./, '');
                    if ($.inArray(extension, fileExtension) == -1) {
                        alert("Porfavor seleccionar archivo excel.");
                        return false;
                    }
                }
                var fdata = new FormData();
                var fileUpload = $("#fileupload").get(0);
                var files = fileUpload.files;
                fdata.append(files[0].name, files[0]);
                $.ajax({
                    type: "POST",
                    url: "/ControlInventario/Import",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("XSRF-TOKEN",
                            $('input:hidden[name="__RequestVerificationToken"]').val());
                    },
                    data: fdata,
                    contentType: false,
                    processData: false,
                    success: function (response) {
                        console.log(response.List);
                        if (response.value.Content == 0)
                            alert('Ocurrio un error al subir el excel');
                        else {
                            $('#divPrint').html(response.value.Content);

                            Swal.fire({
                                title: 'Deseas Imprimir la Etiquetas',
                                showDenyButton: true,
                                showCancelButton: true,
                                confirmButtonText: 'SI',
                                denyButtonText: `No`,
                            }).then((result) => {
                                /* Read more about isConfirmed, isDenied below */
                                if (result.isConfirmed) {
                                    dsh.getPDF();
                                } else if (result.isDenied) {
                                    Swal.fire('Podras generarlo con el boton Generar Etiquetas', '', 'info')
                                }
                            })
                        }
                    },
                    error: function (e) {
                        $('#divPrint').html(e.responseText);
                    }
                });
            })

            $('#btnExport').on('click', function () {
                if (oFile.length == 0) {
                    alert("No haz importado ningun Excel");
                    return false;
                }
                dsh.getPDF(oList);
            });

        },

        getPDF() {
            fetch(url_export, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
            }).then(function (resp) {
                return resp.blob();
            }).then(function (blob) {
                download(blob, "Codigos_Barra");
            });
        },
    };


    dsh.init();
});
