function Login() {
    parametros =
        {
            "usuario": $('#username').val(),
            "senha": $('#pwd').val()
        }

    CommonPost("login", parametros, function (data) {
        if (data) {
            localStorage.setItem("isLogged", 1);
            window.location = "historicoVisitas.html";
        } else {
            alert("USUARIO INVALIDO");
        }
    });
}