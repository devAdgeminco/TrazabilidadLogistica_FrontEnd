$(document).ready(function () {

    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $(".menuAdministracion").addClass("expand");
            $(".submenuAdministracion").css("display", "block");

            $(document).on("click", ".getUsuario", function () {
                var id = $(this).attr('dataId');
                var nombre = $(this).attr('dataNombre');
                $("#tituloModal").text('Modificar Usuario ' + nombre);
                dsh.GetCompanies();
                $('#divContrasena').hide();
                dsh.GetUsuario(id);
            });

            $(document).on("click", ".delete", function () {
                var id = $(this).attr('dataId');
                //console.log(id);
                Swal.fire({
                    title: 'Deseas Eliminar',
                    showDenyButton: true,
                    confirmButtonText: 'Si'
                }).then((result) => {
                    if (result.isConfirmed) {
                        dsh.DeleteUsuario($(this).attr('dataId'));
                    }
                })
            });

            $(document).on("click", ".contrasena", function () {
                var id = $(this).attr('dataId');
                //console.log(id);
                $('#codUsuarioContrasena').val(id);
            });

            $(document).on("click", "#btnAgregar", function () {
                $("#tituloModal").text('Nuevo Usuario');
                $('#divContrasena').show();
                dsh.limpiar();
            });

            $(document).on("click", "#btnGuardar", function () {
                if ($("#tituloModal").text() == 'Nuevo Usuario') {
                    dsh.InsertUsuario();
                } else {
                    dsh.UpdateUsuario();
                }
                $("#mUsuarios").modal('hide');
            });

            $(document).on("click", "#btnGuardarContrasena", function () {
                dsh.UpdateContrasena();
            });
            dsh.GetUsuarios();
        },

        limpiar() {
            $('#Usuario').val('');
            $('#codUsuario').val('');
            $('#Nombres').val('');
            $('#Apellidos').val('');
            dsh.GetCompanies()
            $('#Perfil').val(1101);
            $('#Contrasena').val('');
        },

        getDate(dateObject) {
            var d = new Date(dateObject);
            var day = d.getDate();
            var month = d.getMonth() + 1;
            var year = d.getFullYear();
            if (day < 10) {
                day = "0" + day;
            }
            if (month < 10) {
                month = "0" + month;
            }
            var date = day + "/" + month + "/" + year;

            return date;
        },

        GetUsuarios() {
            $.ajax({

                cache: false,
                async: true,
                url: url_getUsuarios,
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

                        var cambiarcontraseña = '<button dataId="' + ls[i].CodUsuario + '" type="button" class="btn btn-warning btn-xs contrasena" data-bs-toggle="modal" data-bs-target="#mContrasena" data-bs-toggle="tooltip" data-bs-placement="top" title="Cambiar Contraseña"><i class="fas fa-arrow-down-a-z"></i></button>';
                        var act = '<button dataId="' + ls[i].CodUsuario + '" type="button" class="btn btn-danger btn-xs delete" data-bs-toggle="tooltip" data-bs-placement="top" title="Eliminar"><i class="fas fa-eraser"></i></button>';

                        dataSet.push([ls[i].CodUsuario,
                            ls[i].Login,
                            ls[i].NombreCompleto,
                            ls[i].RazonSocial,
                            ls[i].Descripcion,
                            '<button type="button" dataId="' + ls[i].CodUsuario + '"dataNombre="' + ls[i].NombreCompleto + '" class="btn btn-primary btn-xs getUsuario" data-bs-toggle="modal" data-bs-target="#mUsuarios" data-bs-toggle="tooltip" data-bs-placement="top" title="Editar"><i class="fas fa-pencil"></i></button> '+
                            cambiarcontraseña + ' ' + act
                        ]);
                    }
                    //console.log('dataSet');
                    //console.log(dataSet);

                    $('#tUsuarios').DataTable({
                        destroy: true,
                        data: dataSet,
                        columns: [
                            { title: "CodUsuario" },
                            { title: "Login" },
                            { title: "NombreCompleto" },
                            { title: "Empresa" },
                            { title: "Tipo Usuario" },
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

        GetUsuario(id) {
            $.ajax({
                cache: false,
                async: true,
                url: url_GetUserForm,
                type: "POST",
                data: {
                    CodUsuario: id
                },
                success: function (data) {
                    let ls = JSON.parse(data.value).users[0];
                    //console.log(ls);
                    $('#Usuario').val(ls.Login);
                    $('#codUsuario').val(ls.CodUsuario);
                    $('#Nombres').val(ls.Nombres);
                    $('#Apellidos').val(ls.Apellidos);
                    $('#Empresa').val(ls.CodEmpresa);
                    $('#Perfil').val(ls.TipoUsuarioMa);
                },
                error: function () {
                    console.log(data.value);
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

                    $("#Empresa").find('option').remove();
                    for (var i = 0; i < ls.length; i++) {
                        $("#Empresa").append("<option value='" + ls[i].CodEmpresa + "'> " + ls[i].RazonSocial + " </option>");
                    }

                    $("#Empresa").val($("#Empresa option:first").val());
                },
                error: function () {
                    console.log("Error");
                }
            });
        },

        InsertUsuario() {
            let Login = $('#Usuario').val() ;
            let Nombres = $('#Nombres').val();
            let Apellidos = $('#Apellidos').val();
            let CodEmpresa = $('#Empresa').val();
            let TipoUsuarioMa = $('#Perfil').val();
            let Clave = $('#Contrasena').val();

            $.ajax({
                cache: false,
                async: true,
                url: url_InsertUser,
                type: "POST",
                data: {
                    Login: Login,
                    Nombres: Nombres,
                    Apellidos: Apellidos,
                    CodEmpresa: CodEmpresa,
                    TipoUsuarioMa: TipoUsuarioMa,
                    Clave: Clave
                },
                success: function (data) {
                    //console.log(data);
                    //console.log(data.value);
                    if (data.value) {
                        Swal.fire({
                            title: 'Guardado',
                            confirmButtonText: 'Ok',
                        }).then((result) => {
                            /* Read more about isConfirmed, isDenied below */
                            if (result.isConfirmed) {
                                window.location.href = url_usuarios;
                            }
                        })
                        
                    }
                },
                error: function () {
                    console.log(data.value);
                }
            });
        },

        UpdateUsuario() {
            let Login = $('#Usuario').val();
            let Nombres = $('#Nombres').val();
            let Apellidos = $('#Apellidos').val();
            let CodEmpresa = $('#Empresa').val();
            let TipoUsuarioMa = $('#Perfil').val();
            let Clave = $('#Contrasena').val();
            let CodUsuario = $('#codUsuario').val();

            $.ajax({
                cache: false,
                async: true,
                url: url_UpdateUser,
                type: "POST",
                data: {
                    CodUsuario: CodUsuario,
                    Login: Login,
                    Nombres: Nombres,
                    Apellidos: Apellidos,
                    CodEmpresa: CodEmpresa,
                    TipoUsuarioMa: TipoUsuarioMa,
                    Clave: Clave
                },
                success: function (data) {
                    console.log(data.value);
                    if (data.value) {
                        Swal.fire({
                            title: 'Modificado',
                            confirmButtonText: 'Ok',
                        }).then((result) => {
                            /* Read more about isConfirmed, isDenied below */
                            if (result.isConfirmed) {
                                window.location.href = url_usuarios;
                            }
                        })
                    }
                    
                },
                error: function () {
                    console.log(data.value);
                }
            });
        },

        DeleteUsuario(id) {
            $.ajax({
                cache: false,
                async: true,
                url: url_DeleteUser,
                type: "POST",
                data: {
                    CodUsuario: id
                },
                success: function (data) {
                    console.log(data);
                    if (true) {
                        Swal.fire({
                            title: 'Eliminado',
                            confirmButtonText: 'Ok',
                        }).then((result) => {
                            /* Read more about isConfirmed, isDenied below */
                            if (result.isConfirmed) {
                                window.location.href = url_usuarios;
                            }
                        })
                    }
                    
                },
                error: function () {
                    console.log(data.value);
                }
            });
        },

        UpdateContrasena() {
            CodUsuario = $('#codUsuarioContrasena').val();
            Clave = $('#contrasenaChange').val();
            $.ajax({
                cache: false,
                async: true,
                url: url_UpdatePswdUser,
                type: "POST",
                data: {
                    CodUsuario: CodUsuario,
                    Clave: Clave
                },
                success: function (data) {
                    //console.log(data);
                    if (true) {
                        Swal.fire({
                            title: 'Contraseña Cambiada',
                            confirmButtonText: 'Ok',
                        }).then((result) => {
                            /* Read more about isConfirmed, isDenied below */
                            if (result.isConfirmed) {
                                window.location.href = url_usuarios;
                            }
                        })
                    }
                },
                error: function () {
                    console.log(data.value);
                }
            });
        }
    };

    dsh.init();
});