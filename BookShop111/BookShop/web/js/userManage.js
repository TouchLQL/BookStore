function getId() {
    var id = "";
    var tr = $(".gridTbody table").find("tr.selected");
    if (tr.length > 0) {
        id = $(tr).find(".id").html();
    }
    document.getElementById("hidId").value = id;
}

function getId1() {
    if (confirm("是否删除？")) {
        var id = "";
        var tr = $(".gridTbody table").find("tr.selected");
        if (tr.length > 0)
            id = $(tr).find(".id").html();
        document.getElementById("hidId").value = id;
        return true;
    }

    return false;
}
//第一行默认选中
$(document).ready(function () {
    $(".gridTbody table tr:eq(0)").click();
});