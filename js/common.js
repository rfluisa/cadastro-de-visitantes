function CommonPost(metodo, json,callback) {
    $.post("https://localhost:44337/api/values/" + metodo, json, function (data) {
        callback(data);
    });
}