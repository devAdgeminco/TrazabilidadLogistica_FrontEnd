$(document).ready(function () {

    var dsh = {
        init: function () {
            dsh.evento();
        },
        evento() {

            $(document).on("click", ".getAgendaDetalle", function () {
                var id = $(this).attr('dataId');
                console.log(id);
                dsh.GetAgendaDetalle(id);
            });

            $(document).on("change", "#sAprobacion", function () {
                var id = $(this).attr('dataId');
                var value = $(this).val();
                console.log(id);
                console.log(value);
                dsh.setAprobacion(id, value);
            });

            dsh.GetAgenda();
        },

        sumarDias(fecha, dias) {
            fecha.setDate(fecha.getDate() + dias);
            return fecha;
        },

        padTo2Digits(num) {
            return num.toString().padStart(2, '0');
        },

        formatDate(date) {
            return [
                date.getFullYear(),
                dsh.padTo2Digits(date.getMonth() + 1),
                dsh.padTo2Digits(date.getDate()),
            ].join('');
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

        GetAgenda() {
            $.ajax({

                cache: false,
                async: true,
                url: url_agenda,
                type: "POST",
                //data: {
                //    idReq: idReq
                //},
                success: function (data) {
                    //console.log(data.value);

                    var ls = JSON.parse(data.value).agenda;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {                        
                        var act1 = '<button dataId="' + ls[i].id + '" type="button" class="btn btn-danger btn-xs getAgendaDetalle" data-bs-toggle="modal" data-bs-target="#mDetalle" style="margin-top: 10%;"><i class="ion ion-md-exit"></i></button>'

                        dataSet.push([ls[i].id,
                            ls[i].nroOrden,
                            dsh.getDate(ls[i].fechaAgenda),
                            ls[i].horaAgenda,
                            ls[i].RucProv,
                            ls[i].RazonSocial,
                            ls[i].DetalleOC,
                            '<div class="row">' +
                                '<div class="col-8">' +
                                    '<select id="sAprobacion" dataId="' + ls[i].id + '" class="form-select" aria-label="">' +
                                        '<option value="0" ' + (ls[i].Aprobacion == false ? 'selected' : '') + '>No entregado</option>' +
                                        '<option value="1" ' + (ls[i].Aprobacion == true ? 'selected' : '') + '>Conforme</option>' +
                                    '</select>  ' +
                                '</div>' +
                                '<div class="col-4">' +
                                    act1 +
                                '</div>' +
                            '</div>'
                        ]);
                    }
                    //console.log('dataSet');
                    //console.log(dataSet);

                    $('#tAgenda').DataTable({
                        destroy: true,
                        responsive:true,
                        data: dataSet,
                        columns: [
                            { title: "Id" },
                            { title: "Orden Compra" },
                            { title: "Fecha Programada" },
                            { title: "Hora Programada" },
                            { title: "RUC" },
                            { title: "Razon Social" },
                            { title: "Detalle OC" },
                            { title: "Acciones", width: "200px" }
                        ],
                        "order": [[1, "asc"]],
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

        GetAgendaDetalle(id) {
            
            $.ajax({

                cache: false,
                async: true,
                url: url_agendaDetalle,
                type: "POST",
                data: {
                    id: id
                },
                success: function (data) {
                    //console.log(data.value);

                    var ls = JSON.parse(data.value).agendaDetalle;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {

                        dataSet.push([ls[i].codProducto,
                            ls[i].Descripcion,
                            ls[i].cantidad
                        ]);
                    }
                    //console.log('dataSet');
                    //console.log(dataSet);

                    $('#tAgendaDetalle').DataTable({
                        destroy: true,
                        responsive: true,
                        data: dataSet,
                        columns: [
                            { title: "Codigo Producto" },
                            { title: "Producto" },
                            { title: "Cantidad" }
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

        setAprobacion(id,value) {
                $.ajax({

                    cache: false,
                    async: true,
                    url: url_setAprobacionAgenda,
                    type: "POST",
                    data: {
                        id: id,
                        value: value
                    },
                    success: function (data) {
                        //console.log(data.value);
                        if (data.status) {
                            Swal.fire('Agenda actualizada').then((result) => {
                                window.location.href = url_proveedor;
                            })
                        }
                    },
                    error: function () {
                        console.log("Error");
                    }
                });
},
    };

    dsh.init();
});