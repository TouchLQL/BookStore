
$(function () {
    var url = window.location.search;
    //    alert(url.length);
    //    alert(url.lastIndexOf('='));
    var loc = url.substring(url.lastIndexOf('=') + 1, url.length);
    var params = '{bookID:"' + loc + '"}';
    console.log(params);
    $.ajax({
        data:params,
        url: 'booksDetail.aspx/showDetails',
        type: 'post',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            var data = $.parseJSON(msg.d);
            $("#booksdetail").html("");
            $.each(data, function (idx, item) {

                $("#booksdetail").append('<img src="' + item.picture + '"  class="img5"/>' +
  	 	'<p class="fontStyle3">' + item.bookName + ' </p>' +
  	 	'<p class="fontStyle4">' + item.writer + ' </p>' +
  	 	'<p class="fontStyle5">￥' + item.price + ' </p>');
                $("#details").append('出版社:&nbsp;'+item.press+'<br />'+
                '库存:&nbsp;&nbsp;' + item.stock+ '<br />' +
                '类型:&nbsp;&nbsp;' + item.type + '<br />');
                $("#bookcontent").append('<p class="jianjie">简介：</p>' + '&nbsp;&nbsp;&nbsp;&nbsp;' + item.synopsis + '<br />');

            })

        },
        error: function () {
            alert("产品数据获取失败");
        }
    });
});

function buyBooks() {

    window.location.href = "shoppingCart.aspx";
};
