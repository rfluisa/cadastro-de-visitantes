function CommonPost(metodo, json, callback) {
    $.ajaxSetup({
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        }
    });
    $.post("https://localhost:44337/api/values/" + metodo, json,callback);
}

function checkAuth(){
    if(localStorage.getItem("isLogged") == 0){
        window.location = "index.html";
    }
}


function Logout() {
    localStorage.setItem("isLogged", 0);
    CommonPost("logout", {}, function () {
    });
}