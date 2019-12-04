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

    CommonPost("visita/TestarPessoa", parametros, function (data) {
        debugger;
        if (data == null)
            window.location = "cadastropessoa.html";
        else {
            var els = document.querySelectorAll("[id='cpf-true']");

            for(var i = 0; i < els.length; i++) 
                els[i].style.display = 'block'; 
            //document.getElementById("cpf-true").style.display = "block";
            document.getElementById("cpfPesquisar").style.display = "none";
        }
    });
}