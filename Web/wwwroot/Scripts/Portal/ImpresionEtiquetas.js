var table;

$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            $(".menuCodigoBarras").addClass("expand");
            $(".submenuCodigoBarras").css("display", "block");

            $(document).on("click", "#btnBuscar", function () {
                dsh.getBarraCodigoOC();
            });
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

        getBarraCodigoOC() {
            let id = $('#Req').val();

            $.ajax({

                cache: false,
                async: true,
                url: url_getBarraCodigoOC,
                type: "GET",
                data: {
                    id: id
                },
                datatype: false,
                contentType: false,
                success: function (data) {
                    if (data.status) {
                        var ls = JSON.parse(data.value).codigoBarrasOC;
                        if (ls.length > 0) {
                            dataSetReq = [];
                            for (var i = 0; i < ls.length; i++) {
                                dataSetReq.push([
                                    ls[i].OCompra,
                                    dsh.getDate(ls[i].FecOCompra),
                                    ls[i].REQUERIM,
                                    dsh.getDate(ls[i].FecEntrega),
                                    ls[i].RUCProv,
                                    ls[i].RazonSocial,
                                    ls[i].DetalleOC,
                                    ls[i].Comprador,
                                    ls[i].Solicitante
                                ]);
                            }
                            //console.log('dataSet');
                            //console.log(dataSet);

                            $('#tOC').DataTable({
                                destroy: true,
                                responsive: true,
                                select: true,
                                data: dataSetReq,
                                columns: [
                                    { title: "OCompra" },
                                    { title: "F.OCompra" },
                                    { title: "REQUERIM" },
                                    { title: "F.Entrega" },
                                    { title: "RUC Proveedor" },
                                    { title: "RazonSocial" },
                                    { title: "DetalleOC" },
                                    { title: "Comprador" },
                                    { title: "Solicitante" }
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

                            table = $('#tOC').DataTable();
                            
                            $('#tOC').on('click', 'tr', function () {
                                //alert(table.row(this).data());
                                //table.row(':eq(0)', { page: 'current' }).select();
                                var rowData = table.row(this).data();
                                dsh.getBarraCodigoOCD(rowData[0]);

                            });

                            //var idx = table.cell('.selected', 0).index();
                            //var data = table.rows(idx.row).data();
                            //console.log(data);

                            

                        } else {
                            //$('#tOC').DataTable();
                        }
                    }
                },
                error: function () {
                    console.log("Error");
                }
            });
        },

        getBarraCodigoOCD(id) {

            $.ajax({

                cache: false,
                async: true,
                url: url_getBarraCodigoOCD,
                type: "GET",
                data: {
                    id: id
                },
                datatype: false,
                contentType: false,
                success: function (data) {
                    if (data.status) {
                        var ls = JSON.parse(data.value).codigoBarrasOCD;
                        if (ls.length > 0) {
                            var html = '';
                            for (var i = 0; i < ls.length; i++) {
                                var fil = ls[i];
                                var tr = '';
                                tr += '<tr>';
                                tr += '<td data="' + fil.CODIGO + '">' + fil.CODIGO + '</td>';
                                tr += '<td>' + fil.DETALLEPROD + '</td>';
                                tr += '<td class="barcode">' + fil.CODIGO + '</td>';
                                tr += '<td><input class="form-control form-control-sm" type="number" value="0"></td>';
                                tr += '</tr>';

                                html += tr;
                            }

                            $('#tBody_OCD').html(html);

                            //var idx = table.cell('.selected', 0).index();
                            //var data = table.rows(idx.row).data();
                            //console.log(data);



                        } else {
                            //$('#tOC').DataTable();
                        }
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
