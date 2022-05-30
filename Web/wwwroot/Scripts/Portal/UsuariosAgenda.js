$(document).ready(function () {

    var dsh = {
        init: function () {
            dsh.evento();
        },
        evento() {
            $(".menuAdministracion").addClass("expand");
            $(".submenuAdministracion").css("display", "block");

            dsh.GetUsuarios();
        },

        GetUsuarios() {
            $.ajax({

                cache: false,
                async: true,
                url: url_getUsersAgenda,
                type: "POST",
                //data: {
                //    idReq: idReq
                //},
                success: function (data) {
                    //console.log(data.value);

                    var ls = JSON.parse(data.value).users;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {

                        var cambiarcontraseña = '<button dataId="' + ls[i].id + '" type="button" class="btn btn-warning btn-xs contrasena" data-bs-toggle="modal" data-bs-target="#mContrasena" data-bs-toggle="tooltip" data-bs-placement="top" title="Cambiar Contraseña"><i class="fas fa-arrow-down-a-z"></i></button>';
                        var act1 = '<button dataId="' + ls[i].id + '" type="button" class="btn btn-danger btn-xs delete" data-bs-toggle="tooltip" data-bs-placement="top" title="Eliminar"><i class="fas fa-eraser"></i></button>';
                        var act2 = '<button dataId="' + ls[i].id + '" type="button" class="btn btn-' + (ls[i].validado == 1 ? 'success' : 'danger') + ' btn-xs validado" data-bs-toggle="tooltip" data-bs-placement="top" title="Validar"><i class="fas fa-' + (ls[i].validado == 1 ? 'check' : 'user-large-slash' ) + '"></i></button>';

                        dataSet.push([ls[i].id,
                            ls[i].usuario,
                            ls[i].nombres,
                            ls[i].apellidos,
                            ls[i].rucEmpresa,
                            ls[i].email,
                        '<button type="button" dataId="' + ls[i].CodUsuario + '"dataNombre="' + ls[i].NombreCompleto + '" class="btn btn-primary btn-xs getUsuario" data-bs-toggle="modal" data-bs-target="#mUsuarios" data-bs-toggle="tooltip" data-bs-placement="top" title="Editar"><i class="fas fa-pencil"></i></button> ' +
                        cambiarcontraseña + ' ' + act1 + ' ' + act2
                        ]);
                    }
                    //console.log('dataSet');
                    //console.log(dataSet);

                    $('#tUsuarios').DataTable({
                        destroy: true,
                        data: dataSet,
                        columns: [
                            { title: "Id" },
                            { title: "Usuario Proveedor" },
                            { title: "Nombres" },
                            { title: "Apellidos" },
                            { title: "RUC" },
                            { title: "Correo" },
                            { title: "Acciones" }
                        ],
                        language: {
                            "processing": "Procesando...",
                            "lengthMenu": "Mostrar _MENU_ registros",
                            "zeroRecords": "No se encontraron resultados",
                            "emptyTable": "Ningún dato disponible en esta tabla",
                            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
                            "search": "Buscar:",
                            "infoThousands": ",",
                            "loadingRecords": "Cargando...",
                            "paginate": {
                                "first": "Primero",
                                "last": "Último",
                                "next": "Siguiente",
                                "previous": "Anterior"
                            },
                            "aria": {
                                "sortAscending": ": Activar para ordenar la columna de manera ascendente",
                                "sortDescending": ": Activar para ordenar la columna de manera descendente"
                            },
                            "emptyTable": "No hay datos disponibles en la tabla",
                            "zeroRecords": "No se encontraron coincidencias",
                            "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                            "infoEmpty": "Mostrando 0 a 0 de 0 entradas",
                            "infoFiltered": "(Filtrado de _MAX_ total de entradas)",
                            "lengthMenu": "Mostrar _MENU_ entradas",
                        }
                    });

                    //$('#tRequerimientos').DataTable().destroy();
                    //$('#tRequerimientos').DataTable();
                },
                error: function () {
                    console.log("Error");
                }
            });
        },
    };

    dsh.init();
});