const { post } = require("jquery");

jQuery(document).ready(function (s) {
    $('#txtSecretario').focus();

    $('#btnEntrar').on('click', function () {
        if ($('#txtSecretario').val() != "" & $('#txtContraseña'.val() != "")){
            Validate($('#txtSecretario').val(), $('#txtContraseña'.val()));
        }
        else {
            Swal.fire(
                'error',
                'Favor de ingresar su correo y contraseña',
                'error'
            );
        }
    });


    function Validate(Correo, Contraseña) {
        var record = {
            Correo: Correo,
            Contraseña: Contraseña
        };

        $.ajax({
            url: '/Secretarias/GetSecretary',
            async: false,
            type: 'POST',
            data: record,
            beforeSend: function (xhr, opts) {
            }, complete: function () {

            }, success: function (data) {
                if (data.status == true) {
                    window.location.href = "/Home/Index"
                }
                else if (data.status == false) {
                    Swal.fire(
                        'error',
                        data.message,
                        'error'
                    );

                }
            },
            error: function (data) {
                Swal.fire(
                    'error',
                    data.message,
                    'error'
                );
            }
        });
    }


});