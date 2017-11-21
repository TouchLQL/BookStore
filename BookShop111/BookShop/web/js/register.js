$(function () {
    $(".form_datetime").datetimepicker({
        minView: 'month',            //设置时间选择为年月日 去掉时分秒选择
        format:'yyyy-mm-dd',
        weekStart: 1,
        todayBtn:  1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        forceParse: 0,
        showMeridian: 1,
        language: 'zh-CN'              //设置时间控件为中文
    }); 
});

function adduser() {
    
    var password = $('#password2').val();
    var userName = $('#userName2').val();
    var sex = document.getElementsByName("sex") 
    for (i = 0; i < sex.length; i++) {
        if (sex[i].checked)
            var sexchose = sex[i].value;
    }
    var birth = $('#birth').val();
    var mail = $('#mail').val();
    var realName = $('#realName').val();
    var address = $('#address').val();
    var telephone = $('#telephone').val();

    if (password == '' || typeof (password) == "undefined"
		|| userName == '' || typeof (userName) == "undefined") {
        alert("用户名或密码不能为空！");
    }
    else 
    {
        var parame = {};
        parame.password = password;
        parame.userName = userName;
        parame.sex = sexchose;
        parame.birth = birth;
        parame.mail = mail;
        parame.realName = realName;
        parame.address = address;
        parame.telephone = telephone;
        console.log(parame);
        var datajosn = '{password:"' + password + '",userName:"' + userName + '",sex:"' + sexchose + '",birth:"' + birth + '",mail:"' + mail + '",realName:"' + realName + '",address:"' + address + '",telephone:"' + telephone+'"}';
       
        $.ajax({
            data: datajosn,
            type: 'post',
            dataType: 'json',
            url: 'register.aspx/registe',
            contentType: "application/json; charset=utf-8",
            
            success: function (msg) {
                if (msg.d == "0") {
                    alert("用户名已经存在！");
                }
                else {
                    alert("注册成功！");
                    window.location.href = "index.aspx";
                }
            },
            error: function () {
                alert("错误！");
            }
            
        });
        
    }
};

