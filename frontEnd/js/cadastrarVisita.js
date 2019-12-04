function CadastrarPessoa() {
    parametros =
        {
            "Cpf": $('#cpf-cnpj').val(),
            "Nome": $('#nome').val(),
            "Sexo": $('#m').is(':checked') ? $('#m').val() : ($('#f').is(':checked') ? $('#f').val() : ($('#o').is(':checked') ? $('#o').val() : null)),
            "Telefone": $('#telefone').val()
        }
    CommonPost("visita/cadastro", parametros, function (data) {

    });
}

function CadastrarVisita() {
    debugger;
    parametros =
        {
            "CPF": $('#Cpfinfo').val(),
            "Placa": ($('#placa').val() == "") ? $('#veiculos').val() : $('#placa').val(),
            "NomeSetor": $('#predios').val(),
            "Ano": $('#ano').val(),
            "Marca": $('#marca').val(),
            "Modelo": $('#modelo').val()
        }
    CommonPost("visita/visita", parametros, function (data) {

    });
}

function checkCpf() {
    parametros =
        {
            "cpf": $('#Cpfinfo').val()
        }



    CommonPost("visita/TestarPessoa", parametros, function (data) {
        if (data == null)
            window.location = "cadastropessoa.html";
        else {
            $("#info").html(data.Nome);

            for (i = 0; i < data.Veiculospessoas.length; i++) {
                $("#veiculos").append('<option value="' + data.Veiculospessoas[i].VEICULOSVEICULO.Placa + '"> ' + data.Veiculospessoas[i].VEICULOSVEICULO.Placa + ' </option >')
            }

            document.getElementById("cpf-true").style.display = "block";
            document.getElementById("info").style.display = "block";
            document.getElementById("cpf-true1").style.display = "block";
            document.getElementById("tituloSetor").style.display = "block";
            document.getElementById("predios").style.display = "block";
            document.getElementById("registrarVisita").style.display = "block";
            document.getElementById("pesquisarCPF").style.display = "none";
        }

    });
}

function load() {
    checkAuth();
    $('#Cpfinfo').val(sessionStorage.getItem("cpf"));
}