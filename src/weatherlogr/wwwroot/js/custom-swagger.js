function ready(callback) {
    // in case the document is already rendered
    if (document.readyState != 'loading') callback();
    // modern browsers
    else if (document.addEventListener) document.addEventListener('DOMContentLoaded', callback);
    // IE <= 8
    else document.attachEvent('onreadystatechange', function () {
        if (document.readyState == 'complete') callback();
    });
}

ready(update_TopBar);

function update_TopBar() {
    var topBar = document.getElementsByClassName("topbar-wrapper");
    if (topBar.length == 0) {
        window.setTimeout(update_TopBar, 100);
        return;
    }
    var header = document.createElement("a");
    header.href = "/";
    header.innerText = "WeatherLogR";

    let topbarWrapper = topBar[0];

    topbarWrapper.insertBefore(header, topbarWrapper.firstChild);
}