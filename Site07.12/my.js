window.onload = function () {
    //alert("Hello! Nice to see you :)");
    var counter = 4;
    var eventHandler = setInterval(function () {
        counter = tick_tack(counter, eventHandler);
    }, 1000);

    var items = document.getElementsByClassName("close_dialog");
    for (let i = 0; i < items.length; i++) {
        items[i].onclick = close_dialog;
    };
};
//show greeting dialog
function show_dialog() {
    var dlg = document.getElementById("happy_dialog");
    dlg.style.display = "block";
}
function close_dialog() {
    var dlg = document.getElementById("happy_dialog");
    dlg.style.display = "none";
}

function tick_tack(count, eventHandler) {
    var my_ticker = document.getElementById("tick_bomb")
    my_ticker.innerHTML = count;
    if (count <= 0) {
        clearInterval(eventHandler); //cancel timer
        show_dialog();

    }
    return --count;
}