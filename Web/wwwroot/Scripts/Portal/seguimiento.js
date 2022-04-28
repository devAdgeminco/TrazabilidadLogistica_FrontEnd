$(document).ready(function () {

    var dsh = {
        init: function () {
            dsh.evento();
        },
        evento() {
            $(".menuTrazabilidad").addClass("expand");
            $(".submenuTrazabilidad").css("display", "block");

            $(document).on("click", "#btnBuscar", function () {
                dsh.GetRequerimiento();
                dsh.GetOrdenCompra();
                dsh.GetPartesEntrada();
            });

            document.getElementById("cReq").style.display = "none";
            document.getElementById("cOC").style.display = "none";
            document.getElementById("cIA").style.display = "none";
            document.getElementById("cAlmacenDestino").style.display = "none";
            document.getElementById("cValeEntrega").style.display = "none";

            $(document).on("click", ".uno", function () {
                $('.uno').addClass('active');
                $('.dos').removeClass('active');
                $('.tres').removeClass('active');
                $('.cuatro').removeClass('active');
                $('.cinco').removeClass('active');

                document.getElementById("cReq").style.display = "block";
                document.getElementById("cOC").style.display = "none";
                document.getElementById("cIA").style.display = "none";
                document.getElementById("cAlmacenDestino").style.display = "none";
                document.getElementById("cValeEntrega").style.display = "none";
                
            });
            $(document).on("click", ".dos", function () {
                $('.dos').addClass('active');
                $('.uno').removeClass('active');
                $('.tres').removeClass('active');
                $('.cuatro').removeClass('active');
                $('.cinco').removeClass('active');

                document.getElementById("cReq").style.display = "none";
                document.getElementById("cOC").style.display = "block";
                document.getElementById("cIA").style.display = "none";
                document.getElementById("cAlmacenDestino").style.display = "none";
                document.getElementById("cValeEntrega").style.display = "none";
            });
            $(document).on("click", ".tres", function () {
                $('.tres').addClass('active');
                $('.uno').removeClass('active');
                $('.dos').removeClass('active');
                $('.cuatro').removeClass('active');
                $('.cinco').removeClass('active');

                document.getElementById("cReq").style.display = "none";
                document.getElementById("cOC").style.display = "none";
                document.getElementById("cIA").style.display = "block";
                document.getElementById("cAlmacenDestino").style.display = "none";
                document.getElementById("cValeEntrega").style.display = "none";
            });
            $(document).on("click", ".cuatro", function () {
                $('.cuatro').addClass('active');
                $('.uno').removeClass('active');
                $('.dos').removeClass('active');
                $('.tres').removeClass('active');
                $('.cinco').removeClass('active');

                document.getElementById("cReq").style.display = "none";
                document.getElementById("cOC").style.display = "none";
                document.getElementById("cIA").style.display = "none";
                document.getElementById("cAlmacenDestino").style.display = "block";
                document.getElementById("cValeEntrega").style.display = "none";
            });
            $(document).on("click", ".cinco", function () {
                $('.cinco').addClass('active');
                $('.uno').removeClass('active');
                $('.dos').removeClass('active');
                $('.tres').removeClass('active');
                $('.cuatro').removeClass('active');

                document.getElementById("cReq").style.display = "none";
                document.getElementById("cOC").style.display = "none";
                document.getElementById("cIA").style.display = "none";
                document.getElementById("cAlmacenDestino").style.display = "none";
                document.getElementById("cValeEntrega").style.display = "block";
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

        GetRequerimiento() {

            let idReq = $('#Req').val();

            $.ajax({

                cache: false,
                async: true,
                url: url_getRequerimiento,
                type: "GET",
                data: {
                    idReq: idReq
                },
                datatype: false,
                contentType: false,
                success: function (data) {
                    if (data.status) {
                        var ls = JSON.parse(data.value).requerimiento;
                        if (ls.length > 0) {
                            $('.uno').removeClass('disabled');
                            $('.uno').addClass('completed');
                            dataSet = [];
                            for (var i = 0; i < ls.length; i++) {
                                dataSet.push([ls[i].RC_CNROREQ,
                                dsh.getDate(ls[i].RC_DFECREQ),
                                ls[i].RC_PRIOR,
                                ls[i].TG_CDESCRI,
                                dsh.getDate(ls[i].RC_DFECA01),
                                ls[i].RC_CNUMORD
                                ]);
                            }
                            //console.log('dataSet');
                            //console.log(dataSet);

                            $('#tRequerimientos').DataTable({
                                destroy: true,
                                data: dataSet,
                                columns: [
                                    { title: "Nº" },
                                    { title: "Fecha" },
                                    { title: "Prioridad" },
                                    { title: "Estado" },
                                    { title: "Fecha Estado" },
                                    { title: "Nº OC" }
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
                        } else {
                            $('#tRequerimientos').DataTable();
                        }
                    }
                },
                error: function () {
                    console.log("Error");
                }
            });
        },
        GetOrdenCompra() {
            let idReq = $('#Req').val();
            

            $.ajax({

                cache: false,
                async: true,
                url: url_getOCompra,
                type: "GET",
                data: {
                    idReq: idReq
                },
                datatype: false,
                contentType: false,
                success: function (data) {
                    if (data.status) {
                        var ls = JSON.parse(data.value).oCompra;
                        if (ls.length > 0) {
                            $('.dos').removeClass('disabled');
                            $('.dos').addClass('completed');
                            dataSet = [];
                            for (var i = 0; i < ls.length; i++) {
                                dataSet.push([ls[i].OC_CNUMORD,
                                dsh.getDate(ls[i].OC_DFECDOC),
                                ls[i].OC_CCODPRO,
                                ls[i].OC_CRAZSOC,
                                ls[i].ESTADO,
                                ls[i].OC_CCOTIZA
                                ]);
                            }
                            //console.log('dataSet');
                            //console.log(dataSet);

                            $('#tOC').DataTable({
                                destroy: true,
                                data: dataSet,
                                columns: [
                                    { title: "Nº OC" },
                                    { title: "Fecha" },
                                    { title: "CodProd" },
                                    { title: "Razon Social" },
                                    { title: "Estado" },
                                    { title: "Requerimiento" }
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
                        } else {
                            $('#tOC').DataTable();
                        }
                    }
                    

                    
                },
                error: function () {
                    console.log("Error");
                }
            });
        },
        GetPartesEntrada() {
            let idReq = $('#Req').val();

            $.ajax({

                cache: false,
                async: true,
                url: url_getParteEntrada,
                type: "GET",
                data: {
                    idReq: idReq
                },
                datatype: false,
                contentType: false,
                success: function (data) {
                    if (data.status) {
                        var ls = JSON.parse(data.value).parteEntrada;
                        if (ls.length > 0) {
                            $('.tres').removeClass('disabled');
                            $('.tres').addClass('completed');

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
                                ls[i].OC_CCOTIZA
                                ]);
                            }
                            //console.log('dataSet');
                            //console.log(dataSet);

                            $('#tPE').DataTable({
                                destroy: true,
                                data: dataSet,
                                columns: [
                                    { title: "CTD" },
                                    { title: "N° Parte Entrada" },
                                    { title: "Descripcion" },
                                    { title: "Fecha" },
                                    { title: "FTDOC" },
                                    { title: "FNDOC" },
                                    { title: "N° OC" },
                                    { title: "Requerimiento" }
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
                        } else {
                            $('#tPE').DataTable();
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