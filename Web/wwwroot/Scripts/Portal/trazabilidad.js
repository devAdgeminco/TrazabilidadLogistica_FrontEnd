$(document).ready(function () {
    
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $(".menuTrazabilidad").addClass("expand");
            $(".submenuTrazabilidad").css("display", "block");



            $("#fecIni").val(dsh.formatDate(dsh.sumarDias(new Date(), -90)));
            $("#fecFin").val(dsh.formatDate(new Date()));

            $("#btnBuscar").on("click", function () {
                dsh.GetRequerimientos();
            });

            dsh.GetRequerimientos();
            $(document).on("click", ".getDetalle", function () {
                var idCotizacion = $(this).attr('dataId');
                console.log(idCotizacion);
                dsh.GetRequerimientoDetalle(idCotizacion);
            });

            //$('#example').DataTable();
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
            ].join('-');
        },

        GetRequerimientos() {

            var fecIni = $("#fecIni").val();
            var fecFin = $("#fecFin").val();

            $.ajax({

                cache: false,
                async: true,
                url: url_getRequerimientos,
                type: "GET",
                data: {
                    fecIni: fecIni,
                    fecFin: fecFin
                },
                datatype: false,
                contentType: false,
                success: function (data) {
                    
                    var ls = JSON.parse(data.value).requerimientos;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {
                        dataSet.push([ls[i].RC_CNROREQ,
                        dsh.getDate(ls[i].RC_DFECREQ),
                                    ls[i].RC_PRIOR,
                                    ls[i].TG_CDESCRI,
                                    dsh.getDate(ls[i].RC_DFECA01),
                                    ls[i].RC_CNUMORD,
                            '<button type="button" dataId="' + ls[i].RC_CNROREQ + '" class="btn btn-primary btn-xs getDetalle" data-bs-toggle="modal" data-bs-target="#mDetalle"><i class="fas fa-book fa-sm"></i></button>'
                        ]);
                    }
                    //console.log('dataSet');
                    //console.log(dataSet);

                    $('#tRequerimientos').DataTable({
                        dom: 'lBfrtip',
                        buttons: [
                            'excel'
                        ],
                        destroy: true,
                        data: dataSet,
                        columns: [
                            { title: "Nº" },
                            { title: "Fecha" },
                            { title: "Prioridad" },
                            { title: "Estado" },
                            { title: "Fecha Estado" },
                            { title: "Nº OC" },
                            { title: "Accion" }
                        ],
                        "order": [[0, "desc"]],
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

        GetRequerimientoDetalle(idReq) {
            $.ajax({

                cache: false,
                async: true,
                url: url_getRequerimientoDetalle,
                type: "POST",
                data: {
                    idReq: idReq
                },
                success: function (data) {
                    console.log(data.value);

                    var ls = JSON.parse(data.value).requerimientoDetalle;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {
                        dataSet.push([ls[i].RD_CNROREQ,
                            ls[i].RD_CITEM,
                            ls[i].RD_CCODIGO,
                            ls[i].RD_CDESCRI,
                            ls[i].RD_CUNID,
                            ls[i].RD_NQPEDI,
                            ls[i].RD_CCENCOS
                        ]);
                    }
                    //console.log('dataSet');
                    //console.log(dataSet);

                    $('#tRequerimientosDetalle').DataTable({
                        destroy: true,
                        data: dataSet,
                        columns: [
                            { title: "Nº Req" },
                            { title: "Item" },
                            { title: "Codigo" },
                            { title: "Descripcion" },
                            { title: "UN" },
                            { title: "QPEDI" },
                            { title: "CENCOS" }
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



