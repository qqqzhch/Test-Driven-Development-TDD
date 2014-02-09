
function geturl(id) {
    $.get("/browse/UrlInfo/" + id + "/ajax", function (data) {
        if (data == "") {
            alert("Get the url address error");
            $("#urladd").text(data);
            $("#urladd").attr("href", data);
        }
        else {
            $("#urladd").text(data);
            $("#urladd").attr("href", data);
        }
    });
}


