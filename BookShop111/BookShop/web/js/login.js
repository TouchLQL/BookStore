window.onload = function () {

    /*加载登陆蒙板弹窗*/
    var loginbox = document.getElementById("alertBox");
    var imask = document.getElementById("curtain");
    var sheight = document.documentElement.scrollHeight;
    var swidth = document.documentElement.scrollWidth;
    var wheight = document.documentElement.clientHeight;

    var oMask = document.getElementById("curtain");
    oMask.style.height = "849px";
    oMask.style.width = swidth + "px";

    var oVerify = document.getElementById("alertBox");
    var dHeight = oVerify.offsetHeight;
    var dWidth = oVerify.offsetWidth;
    var lastwidth = swidth - dWidth;
    var lastheight = wheight - dHeight;

    oVerify.style.left = lastwidth / 2 - 175 + "px";
    oVerify.style.top = "202px";
    loginbox.style.display = "none";
    imask.style.display = "none";

    $(".fixed-table-pagination").addClass("IchangeStyle");

    $(".h-login").click(function () {

        loginbox.style.display = "block";
        imask.style.display = "block";
    });

    $(".close").click(function () {
        loginbox.style.display = "none";
        imask.style.display = "none";
    });

};

function login() {
  
    var loginbox = document.getElementById("alertBox");
    var imask = document.getElementById("curtain");
    var password = $('#password').val();
    var username = $('#userName').val();
    if (password == '' || typeof (password) == "undefined"
		|| username == '' || typeof (username) == "undefined") {
        alert("用户名或密码不能为空！");
    } else {
        var parame = '{password:"' + password + '",userName:"' + username + '"}';
        $.ajax({
            data: parame,
            type: 'post',
            dataType: 'json',
            url: 'Index.aspx/Login',
            contentType: "application/json; charset=utf-8",
            success: function (a) {
              
                if (a.d =="0") {
                    alert("用户名或密码错误！");
                  
                    
                } else {
                    alert("登录成功，请继续操作！");
                    $('#login').hide();
                    $('#alertBox').hide();
                    loginbox.style.display = "none";
                    imask.style.display = "none";
                }
            
            }
        });
    }
}
