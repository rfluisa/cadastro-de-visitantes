function CommonPost(metodo, json, callback) {
    $.ajaxSetup({
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        }
    });
    $.post("https://localhost:44337/api/values/" + metodo, json,callback);
}