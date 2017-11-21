$(function () {
    var changeHeight = function () {
        //设置表格容器的高度
        var tableHeight = $(".gridScroller").height() - ($("#page").height() - $(window).height());
        //调整表头高度和表格内容对齐
        var tableHeader = $(".gridHeader table")[0];
        var tableBody = $(".gridScroller table")[0];
        $(".gridScroller").css("height", tableHeight + "px");
        $(tableHeader).find("tr th").each(function () {
            $(this).wrapInner("<div></div>");
        });
        $(tableBody).find("tr td").each(function () {
            $(this).wrapInner("<div></div>");
        });
        $(tableHeader).find("th").each(function (index) {
            var td = $(tableBody).find("tr:first td")[index];
            var thWidth = $(this).width();
            $(this).css("width", thWidth + "px");
            $(td).css("width", thWidth + "px");
        });
        $(".gridScroller").bind("scroll", function () {
            var scrollLeft = $(this)[0].scrollLeft / -1 + "px";
            $(".gridThead").css("left", scrollLeft);
        });
        var tableHeaderWidth = $(tableHeader).width();
        $(tableHeader).css("width", tableHeaderWidth);
        $(tableBody).css("width", tableHeaderWidth);
        $(tableHeader).css("table-layout", "fixed");
        $(tableBody).css("table-layout", "fixed");
        if ($(tableBody).find("tr").length == 0) {
            $(".gridScroller .gridTbody").css("width", $(tableBody).css("width"));
            $(".gridScroller .gridTbody").css("height", "1px");
        }
    }
    changeHeight();

    //添加表格事件
    $(".gridTbody table tr").mouseover(function () {
        $(this).addClass("hover");
    });
    $(".gridTbody table tr").mouseout(function () {
        $(this).removeClass("hover");
    });
    $(".gridTbody table tr").click(function (e) {
        $(".gridTbody table tr").removeClass("selected");
        $(".gridTbody table td").removeClass("selected");
        $(this).addClass("selected");
    });
    $(".gridTbody table td").mouseover(function (e) {
        $(".gridTbody table td").removeClass("selected");
        if ($(this).parent("tr.selected").length == 0) {
            $(this).addClass("selected");
        }
    });
    $(".gridTbody table td").mouseout(function () {
        $(this).removeClass("selected");
    });
    $(window.document).click(function (e) {
        if ($(e.target).parents(".gridTbody").length == 0) {
            $(".gridTbody table tr").removeClass("selected");
        }
    });
});