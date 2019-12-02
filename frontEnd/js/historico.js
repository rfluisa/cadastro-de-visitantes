function load(){
    CommonPost("visita/historico", {}, function (data) {
        var html = '';
        $("#bodyHistory").html(html);
        for (e in data) {
            html += '<tr><td>' + data[e].NomePessoa + '</td>';
            html += '<td>' + data[e].PlacaCarro + '</td>';
            html += '<td>' + new Date(Date.parse(data[e].DataEntrada)).toLocaleString() + '</td>';
            html += '<td>' + new Date(Date.parse(data[e].DataSaida)).toLocaleString() + '</td>';
            html += '<td>' + data[e].NomeSetor + '</td>';
            html += '<td>' + ((data[e].DataSaida == null) ? 'Ativo' : 'Inativo')  + '</td></tr>';
        }
        $("#bodyHistory").append(html);
    });
    checkAuth();
}