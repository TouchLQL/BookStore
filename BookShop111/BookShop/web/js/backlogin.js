
function backlogin() {
    var password = $('#password').val();
    var username = $('#account').val();
    if (password == '' || typeof (password) == "undefined"
		|| username == '' || typeof (username) == "undefined") {
        alert("用户名或密码不能为空！");
    } else {
        var parame = '{password:"' + password + '",userName:"' + username + '"}';
        $.ajax({
            data: parame,
            type: 'post',
            dataType: 'json',
            url: 'backLogin.aspx/backlogin',
            contentType: "application/json; charset=utf-8",
            success: function (a) {

                if (a.d == "0") {
                    alert("用户名或密码错误！");


                } else {
                    //alert("登录成功，请继续操作！");
                    window.location.href = "../../Default.aspx";
                }

            }
        });
    }
}