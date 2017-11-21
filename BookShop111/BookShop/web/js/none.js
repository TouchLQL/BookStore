function getbytype(get) {
    var type3 = get.innerHTML;
    var params = '{type:"' + type3 + '"}';
    $.ajax({
        data: params,
        type: 'post',
        dataType: 'json',
        url: 'index.aspx/getBytype',
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "0") {
                window.location.href = "None.aspx";
            }
            if (msg) {
                var myobj = $.parseJSON(msg.d);
                var books = "";
                var types = "";
                var n = 0;
                var j = 6;
                if (myobj.length < 6) {
                    n = myobj.length;
                }
                else
                    n = j;
                for (var i = 0; i < n; i++) {
                    books += "<div class='picture'>" + "<a class='piclist' href='booksDetails.aspx?ISBN='" + myobj[i].ISBN + "'>" +
                        "<img src='../images/" + myobj[i].picture + "' class='img2'/>" + "</a><br/>" +
                        "<p class='font2'>" + "<a class='bookname' href='booksDetails.aspx?ISBN='" + myobj[i].ISBN + "'>" + myobj[i].bookName + "</a>" + "<div class='price'>" + myobj[i].price + "</div>" +
                        "</p>" + "</div>"
                }
                var excellent = document.getElementById("bookPictures");
                excellent.innerHTML = books;
            }

        },
        error: function () {
            alert("错误！");
        }
    });
}