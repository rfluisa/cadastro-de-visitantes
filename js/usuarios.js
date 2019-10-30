function LerUsuarios() {
    CommonPost("readusuarios", {}, function (data) {
        var html = '';
        $("#bodyUsers").html(html);
        for (e in data) {
            html += '<tr><td>' + data[e].NomeUsuario + '</td>';
            html += '<td>' + data[e].Tipo + '</td></tr>';
        }
        $("#bodyUsers").append(html);
    });
}

function MudarSenharUsuario() {
    parametros =
        {
            "NomeUsuario": $('#username').val(),
            "senha": $('#pwd').val()
        }

    CommonPost("updateUsuario", parametros, function (data) {

    });

}

function DeletarUsuario() {
    parametros =
        {
            "NomeUsuario": $('#username').val(),
            "senha": $('#pwd').val()
        }

    CommonPost("deleteUsuario", parametros, function (data) {

    });
}