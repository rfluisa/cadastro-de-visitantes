function toggleSetores(){
    op = predios.value;

    for(i=0; i<13; i++){
        letter = String.fromCharCode('A'.charCodeAt() + i);
        if(op == ("predio-"+letter))
            document.getElementById(("setores-"+letter)).style.display = "block";
        else
            document.getElementById(("setores-"+letter)).style.display = "none";
    }
}