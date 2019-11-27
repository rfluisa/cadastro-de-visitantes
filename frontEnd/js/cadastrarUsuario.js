function CadastrarUsuario() {
    parametros =
        {
            "NomeUsuario": $('#username').val(),
            "senha": $('#pwd').val(),
            "tipo": $('#tipoUsuario').val()

        }
        
    CommonPost("cadastrousuario", parametros, function (data) {

    });
}