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
     if(data){
        window.location("historico.html");
     }else{
         alert("USUARIO INVALIDO");
     }
    });
}

function cadastrarUsuario(){
    $.post("https://localhost:44337/api/values/cadastroUsuario",{"usuario": $('#username').val(), 
     "senha": $('#pwd').val(), "tipo": $('#tipoUsuario')} ,function( data ) {
     $( ".result" ).html( data );
    });
}

function updateUsers(){
    $.post("https://localhost:44337/api/values/readUsuarios",function( data ) {
        var html = '';    
        for (e in data){
            html += '<tr><td>'+e.NomeUsuario+'</td>';
            html += '<td>'+e.Tipo+'</td></tr>';
        }
        $("#bodyUsers").append(html);
    });
}

function changePassword(){
    $.post("https://localhost:44337/api/values/updateUsuario",{"usuario": $('#username').val(), 
     "senha": $('#pwd').val()} ,function( data ) {
     $( ".result" ).html( data );
    });
}


function deleteUser(){
    $.post("https://localhost:44337/api/values/deleteUsuario",{"usuario": $('#username').val(), 
     "senha": $('#pwd').val()} ,function( data ) {
     $( ".result" ).html( data );
    });
}
