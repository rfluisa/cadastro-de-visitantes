function cadastrar(){
    $.post("https://localhost:44337/api/values/cadastro",{"cpfcnpj": $('#cpfBool').val(), 
        "cpf": $('#cpf-cnpj').val(), "nome": $('#nome').val(), "sexoM": $('#m').val(),
        "sexoF": $('#f').val(), "sexoO": $('#o').val(), "telefone": $('#telefone').val()},
        function( data ){

    });
}

function login(){
    $.post("https://localhost:44337/api/values/login",{"usuario": $('#username').val(), 
     "senha": $('#pwd').val()} ,function( data ) {
     if(data){
        window.location = "historico.html";
     }else{
         alert("USUARIO INVALIDO");
     }
    });
}

function cadastrarUsuario(){
    $.post("https://localhost:44337/api/values/cadastrousuario",{"NomeUsuario": $('#username').val(), 
     "senha": $('#pwd').val(), "tipo": $('#tipoUsuario').val()} ,function( data ) {

    });
}

function updateUsers(){
    $.post("https://localhost:44337/api/values/readusuarios",function( data ) {
        var html = '';    
        $("#bodyUsers").html(html);
        for (e in data){
            html += '<tr><td>'+data[e].NomeUsuario+'</td>';
            html += '<td>'+data[e].Tipo+'</td></tr>';
        }
        $("#bodyUsers").append(html);
    });
}

function changePassword(){
    $.post("https://localhost:44337/api/values/updateUsuario",{"NomeUsuario": $('#username').val(), 
     "senha": $('#pwd').val()} ,function( data ) {

    });
}


function deleteUser(){
    $.post("https://localhost:44337/api/values/deleteusuario",{"NomeUsuario": $('#username').val(), 
     "senha": $('#pwd').val()} ,function( data ) {
     
    });
}
