function Login() {
    parametros =
        {
            "usuario": $('#username').val(),
            "senha": $('#pwd').val()
        }

    CommonPost("login", parametros, function (data) {
        if (data) {
            window.location = "historico.html";
        } else {
            alert("USUARIO INVALIDO");
        }
    }, false);
}