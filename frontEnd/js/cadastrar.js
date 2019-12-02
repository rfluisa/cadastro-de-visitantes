function Cadastrar() {
    parametros =
        {
            "cpfcnpj": $('#cpfBool').val(),
            "cpf": $('#cpf-cnpj').val(),
            "nome": $('#nome').val(),
            "sexoM": $('#m').val(),
            "sexoF": $('#f').val(),
            "sexoO": $('#o').val(),
            "telefone": $('#telefone').val()
        }
    CommonPost("visita/cadastro", parametros, function (data) {

    });
}