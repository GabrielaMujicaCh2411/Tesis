/**
 * Configura la búsqueda dinámica para uno varios campos del formulario
 * @param {any} action Función que ejecuta la búsqueda, actualiza los resultados y esconde el loader
 * @param {any} searchFieldsSelector Selector jQuery de los campos que activaran la búsqueda dinámica
 */
function ConfiguraBusquedaDinamica(action, searchFieldsSelector) {
    var timer;
    var x;

    $(searchFieldsSelector).keyup(function () {
        if (x) { x.abort() } // If there is an existing XHR, abort it.
        clearTimeout(timer); // Clear the timer so we don't end up with dupes.
        timer = setTimeout(function () { // assign timer a new timeout
            //x = $.getJSON(...); // run ajax request and store in x variable (so we can cancel)
            $("#overlay").removeClass("hidden");
            x = action();
        }, 500); // 2000ms delay, tweak for faster/slower
    });
}

jQuery.procesaRespuestaVistaParcial = function (data, div, callback) {
    div.html(data);
    div.show('slow');
    if (div.hasClass('modal'))
        div.modal('show');

    $('[data-toggle="tooltip"]').tooltip();

    if ($("#errorAplicacion").length) {
        $("#errorAplicacion").modal('show');
        $("#errorAplicacion").find(("#okButton")).click(function (event) {
            $("#errorAplicacion").modal('hide');
            $(div).empty();
            if (div.hasClass('modal'))
                div.modal('hide');
        });

    }
};

//facade  $.ajax
jQuery.llamadaAjax = function (tipo, tipoData, tipoContent, urlAccion, datos, successFunction, errorFunction) {
    /*
    * tipo = 'GET' / 'POST'
    * tipoData = 'html' / 'json' tipo de datos a recibir
    * tipoContent = 'html' / 'json' tipo de datos a enviar al controlador
    */
    $.ajax({
        type: tipo,
        url: urlAccion,
        data: datos,
        cache: false,
        dataType: tipoData,
        contentType: "application/" + tipoContent + "; charset=utf-8",
        success: successFunction,
        error: errorFunction
    }
    );
};

//ErrorAjax
function notificacionAjax(heading, text, okButtonTxt) {

    var confirmModal =
        $('<div class="modal fade">' +
            '<div class="modal-dialog">' +
            '<div class="modal-content">' +
            '<div class="modal-header">' +
            '<a class="close" data-dismiss="modal" >&times;</a>' +
            '<h4>' + heading + '</h4>' +
            '</div>' +

            '<div class="modal-body">' +
            '<p>' + text + '</p>' +
            '</div>' +

            '<div class="modal-footer">' +
            '<a href="#" id="okButton" class="btn btn-danger">' +
            okButtonTxt +
            '</a>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>');

    confirmModal.find('#okButton').click(function (event) {
        confirmModal.modal('hide');
    });

    confirmModal.modal('show');
}


function is_numeric(e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 188]) !== -1 ||
        (e.keyCode == 65 && e.ctrlKey === true) ||
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        return;
    }

    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
}

function onlyletters(e) {
    var key = e.keyCode || e.which,
        tecla = String.fromCharCode(key).toLowerCase(),
        letras = " áéíóúabcdefghijklmnñopqrstuvwxyz",
        especiales = [8, 37, 39, 46],
        tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}