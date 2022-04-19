$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $(".menuTrazabilidad").addClass("expand");
            $(".submenuTrazabilidad").css("display", "block");

            dsh.GetOrdenCompra();
            $(document).on("click", ".getDetalle", function () {
                var id = $(this).attr('dataId');
                console.log(id);
                dsh.GetOrdenCompraDetalle(id);
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

        GetOrdenCompra() {
            $.ajax({

                cache: false,
                async: true,
                url: url_getOrdenCompra,
                type: "GET",
                data: {
                    fecIni: new Date("01-01-2022").toUTCString(),
                    fecFin: new Date("04-01-2022").toUTCString()
                },
                datatype: false,
                contentType: false,
                success: function (data) {

                    var ls = JSON.parse(data.value).ordenCompra;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {
                        dataSet.push([ls[i].OC_CNUMORD,
                            dsh.getDate(ls[i].OC_DFECDOC),
                            ls[i].OC_CCODPRO,
                            ls[i].OC_CRAZSOC,
                            ls[i].ESTADO,
                            '<button type="button" dataId="' + ls[i].OC_CNUMORD + '" class="btn btn-primary btn-xs getDetalle" data-bs-toggle="modal" data-bs-target="#mDetalle"><i class="fas fa-book fa-sm"></i></button>'
                        ]);
                    }
                    //console.log('dataSet');
                    //console.log(dataSet);

                    $('#tOC').DataTable({
                        destroy: true,
                        data: dataSet,
                        columns: [
                            { title: "Nº" },
                            { title: "Fecha" },
                            { title: "CodProd" },
                            { title: "Razon Social" },
                            { title: "Estado" },
                            { title: "Accion" }
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
                },
                error: function () {
                    console.log("Error");
                }
            });
        },
        GetOrdenCompraDetalle(id) {
            $.ajax({

                cache: false,
                async: true,
                url: url_getOrdenCompraDetalle,
                type: "POST",
                data: {
                    id: id
                },
                success: function (data) {
                    console.log(data.value);

                    var ls = JSON.parse(data.value).ordenCompra;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {
                        dataSet.push([ls[i].OC_CNUMORD,
                            ls[i].OC_DFECENT,
                            ls[i].OC_CCODIGO,
                            ls[i].OC_CDESREF,
                            ls[i].OC_NCANORD
                        ]);
                    }

                    $('#tOCDetalle').DataTable({
                        destroy: true,
                        data: dataSet,
                        columns: [
                            { title: "Nº" },
                            { title: "Fecha" },
                            { title: "Codigo" },
                            { title: "Descripcion" },
                            { title: "NORD" }
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
