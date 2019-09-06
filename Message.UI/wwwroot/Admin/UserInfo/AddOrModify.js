layui.config({
    base: "/layui/"
}).extend({
    "selectM": "selectM"
});
layui.use(['form', 'layer', 'selectM'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery, selectM = layui.selectM;
    var iPageId = GetParameter("iPageId"),
        iAddorModifyMethodeId = $("#iAddorModifyMethodeId").val();
    var iUserId = $("#Id").val();
    var arrUserRoleId = new Array();
    if (iUserId > 0) {
        $.ajax({
            type: 'Get',
            async: false,
            url: '/Admin/UserRole/GetUserRoleIdList?iUserId=' + iUserId + '&iPageId=' + iPageId + '&iMethodId=1351',
            dataType: "json",
            success: function (res) {
                arrUserRoleId = res;
                console.log(arrUserRoleId);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('操作失败！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
    }
    //选择角色下拉框
    var tagIns1 = selectM({
        //元素容器【必填】
        elem: '#roles'
        //候选数据【必填】
        , data: '/Admin/Roles/GetRoleList?iPageId=' + iPageId + '&iMethodId=1323'
        , max: 1000
        , selected: arrUserRoleId
        , width: 250
        //添加验证
       // , verify: 'required'
    });
form.on("submit(btnSubmit)", function (data) {
    layer.load();
    //获取防伪标记
    $.ajax({
        type: 'POST',
        url: '/Admin/UserInfo/AddOrModify?iPageId=' + iPageId + '&iMethodId=' + iAddorModifyMethodeId,
        data: {
            Id: $("#Id").val(),  //主键
            SloginName: $("#SloginName").val(),
            SuserName: $("#SuserName").val(),
            SuserEmail: $("#SuserEmail").val(),
            SuserPhone: $("#SuserPhone").val(),
            BisLock: $("#BisLock").get(0).checked,
            Sremarks: $("#Sremarks").val(),
            lstRoleId: tagIns1.values
        },
        dataType: "json",
        headers: {
            "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
        },
        success: function (res) {//res为相应体,function为回调函数
            layer.closeAll('loading');
            var alertIndex;
            if (res.Code === 0) {
                alertIndex = layer.alert(res.Msg, { icon: 1 }, function () {
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                    top.layer.close(alertIndex);
                });
                //$("#res").click();//调用重置按钮将表单数据清空
            }
            else {
                alertIndex = layer.alert(res.Msg, { icon: 5 }, function () {
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                    top.layer.close(alertIndex);
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.closeAll('loading');
            layer.alert('操作失败！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
        }
    });
    return false;
});
form.verify({
    SloginName: function (value, item) { //value：表单的值、item：表单的DOM对象
        if (!new RegExp("^[a-zA-Z0-9_\u4e00-\u9fa5\\s·]+$").test(value)) {
            return '登录名不能有特殊字符';
        }
        if (/(^\_)|(\__)|(\_+$)/.test(value)) {
            return '登录名首尾不能出现下划线\'_\'';
        }
        if (/^\d+\d+\d$/.test(value)) {
            return '登录名不能全为数字';
        }
    }
    //我们既支持上述函数式的方式，也支持下述数组的形式
    //数组的两个值分别代表：[正则匹配、匹配不符时的提示文字]
    //, pass: [
    //    /^[\S]{6,12}$/
    //    , '密码必须6到12位，且不能出现空格'
    //]
});

});