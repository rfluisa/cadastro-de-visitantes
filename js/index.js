function cadastrar(){
    $.post("https://localhost:44337/api/values/cadastro",{"cpfcnpj": $('#cpfBool').val(), 
        "cpf": $('#cpf-cnpj').val(), "nome": $('#nome').val(), "sexoM": $('#m').val(),
        "sexoF": $('#f').val(), "sexoO": $('#o').val(), "telefone": $('#telefone').val()},
        function( data ){
        $( ".result" ).html( data );
    });
}

function login(){
    $.post("https://localhost:44337/api/values/login",{"usuario": $('#username').val(), 
     "senha": $('#pwd').val()} ,function( data ) {
     $( ".result" ).html( data );
    });
}

function cadastrarUsuario(){
    $.post("https://localhost:44337/api/values/cadastroUsuario",{"usuario": $('#username').val(), 
     "senha": $('#pwd').val(), "tipo": $('#tipoUsuario')} ,function( data ) {
     $( ".result" ).html( data );
    });
}

function updateUsers(){
    $.post("https://localhost:44337/api/values/readusuarios",function( data ) {
        var html = '';    
        for (e in data){
            html += '<tr><td>'+data[e].NomeUsuario+'</td>';
            html += '<td>'+data[e].Tipo+'</td></tr>';
        }
        $("#bodyUsers").append(html);
    });
}