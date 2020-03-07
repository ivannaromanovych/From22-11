window.onload = function () {
    var urlPrivat = `https://api.privatbank.ua/p24api/pboffice?json=&city`;
    var xhr = new XMLHttpRequest();
    xhr.open('GET', urlPrivat, true);
    xhr.send();
    xhr.onreadystatechange = function () {
        if (xhr.readyState != 4) return;

        else {
            let array = JSON.parse(xhr.responseText);
            var arr = [];
            for (let i = 0; i < array.length; i++) {
                arr.push(array[i].city);
            }
        }
        var rezult = Array.from(new Set(arr));
        $("#txtSearch").autocomplete({
            source: rezult
        });
    }
};