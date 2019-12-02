function CadastrarUsuario() {
    parametros =
        {
            "NomeUsuario": $('#username').val(),
            "senha": $('#pwd').val(),
            "tipo": $('#tipoUsuario').val()

        }
        
    CommonPost("usuario/CadastroUsuario", parametros, function (data) {

    });
}