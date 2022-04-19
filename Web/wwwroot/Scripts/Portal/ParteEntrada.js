$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $(".menuTrazabilidad").addClass("expand");
            $(".submenuTrazabilidad").css("display", "block");

            dsh.GetPartesEntrada();
            $(document).on("click", ".getDetalle", function () {
                var id = $(this).attr('dataId');
                console.log(id);
                dsh.GetPartesEntradaDetalle(id);
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

        GetPartesEntrada() {
            $.ajax({

                cache: false,
                async: true,
                url: url_getPartesEntrada,
                type: "GET",
                data: {
                    fecIni: new Date("01-01-2022").toUTCString(),
                    fecFin: new Date("04-01-2022").toUTCString()
                },
                datatype: false,
                contentType: false,
                success: function (data) {

                    var ls = JSON.parse(data.value).partesEntrada;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {
                        dataSet.push([ls[i].C5_CTD,
                                ls[i].C5_CNUMDOC,
                                ls[i].A1_CDESCRI,
                                ls[i].C5_DFECDOC,
                                ls[i].C5_CRFTDOC,
                                ls[i].C5_CRFNDOC,
                                ls[i].C5_CNUMORD,
                            '<button type="button" dataId="' + ls[i].C5_CNUMDOC + '" class="btn btn-primary btn-xs getDetalle" data-bs-toggle="modal" data-bs-target="#mDetalle"><i class="fas fa-book fa-sm"></i></button>'
                        ]);
                    }
                    //console.log('dataSet');
                    //console.log(dataSet);

                    $('#tPE').DataTable({
                        destroy: true,
                        data: dataSet,
                        columns: [
                            { title: "CTD" },
                            { title: "N°" },
                            { title: "Descripcion" },
                            { title: "Fecha" },
                            { title: "FTDOC" },
                            { title: "FNDOC" },
                            { title: "N° Ord" },
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
                },
                error: function () {
                    console.log("Error");
                }
            });
        },

        GetPartesEntradaDetalle(id) {
            $.ajax({

                cache: false,
                async: true,
                url: url_getPartesEntradaDetalle,
                type: "POST",
                data: {
                    id: id
                },
                success: function (data) {
                    console.log(data.value);

                    var ls = JSON.parse(data.value).parteEntraDetalle;

                    //console.log(ls);
                    dataSet = [];
                    for (var i = 0; i < ls.length; i++) {
                        dataSet.push([ls[i].C6_CITEM,
                            ls[i].C6_CCODIGO,
                            ls[i].C6_CDESCRI,
                            ls[i].C6_NCANTID
                        ]);
                    }

                    $('#tPEDetalle').DataTable({
                        destroy: true,
                        data: dataSet,
                        columns: [
                            { title: "Item" },
                            { title: "Codigo" },
                            { title: "Descripcion" },
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
    };


    dsh.init();
});
