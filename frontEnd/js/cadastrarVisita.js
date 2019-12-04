function Cadastrar() {
    debugger;
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

function checkCpf() {
    parametros =
        {
            "cpf": $('#Cpfinfo').val()
        }

        if (1 === 0)
        window.location = "cadastropessoa.html";
    else {
        document.getElementById("cpf-true").style.display = "block";
        document.getElementById("cpf-true1").style.display = "block";
        document.getElementById("tituloSetor").style.display = "block";
        document.getElementById("predios").style.display = "block";
        document.getElementById("registrarVisita").style.display = "block";

        /*for(var i = 1; i <= 6; i++){
            document.getElementById(("cpf-true"+i)).style.display = "block";
        }//document.getElementById("cpf-true").style.display = "block";*/
        document.getElementById("pesquisarCPF").style.display = "none";
    }

    CommonPost("visita/TestarPessoa", parametros, function (data) {
        debugger;
        
    });
}