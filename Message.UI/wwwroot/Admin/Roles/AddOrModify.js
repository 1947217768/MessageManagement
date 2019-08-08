layui.config({
    base: "/layui/"
}).extend({
    "selectM": "selectM"
});
layui.use(['form', 'layer', 'selectM'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery, selectM = layui.selectM;
    var iRoleId = $("#Id").val();
    var arrUserId = new Array();
    var arrMenuId = new Array();
    if (iRoleId > 0) {
        $.ajax({
            type: 'Get',
            async: false,
            url: '/Admin/UserRole/GetRoleUserIdList?iRoleId=' + iRoleId,
            dataType: "json",
            success: function (res) {
                arrUserId = res;
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('操作失败！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
        $.ajax({
            type: 'Get',
            async: false,
            url: '/Admin/RoleMenu/GetRoleMenu?iRoleId=' + iRoleId,
            dataType: "json",
            success: function (res) {
                arrMenuId = res;
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('操作失败！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
    }
    //选择用户下拉框
    var tagIns1 = selectM({
        //元素容器【必填】
        elem: '#users'
        //候选数据【必填】
        , data: "/Admin/UserInfo/GetUserList/"
        , max: 1000
        , selected: arrUserId
        , width: 250
        //添加验证
        // , verify: 'required'
    });
    //选择菜单下拉框
    var tagIns2 = selectM({
        //元素容器【必填】
        elem: '#menus'
        //候选数据【必填】
        , data: "/Admin/Menu/GetMenuList/"
        , max: 1000
        , selected: arrMenuId
        , width: 250
        //添加验证
        // , verify: 'required'
    });
    form.on("submit(btnSubmit)", function (data) {
        //获取防伪标记
        $.ajax({
            type: 'POST',
            url: '/Admin/Roles/AddOrModify',
            data: {
                Id: $("#Id").val(),  //主键
                SroleName: $("#SroleName").val(),
                Sremarks: $("#Sremarks").val(),
                lstUserId: tagIns1.values,
                lstMenuId: tagIns2.values
            },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
            },
            success: function (res) {//res为相应体,function为回调函数
                var alertIndex;
                if (res.Code === 0) {
                    alertIndex = layer.alert(res.Msg, { icon: 1 }, function () {
                        layer.closeAll("iframe");
                        //刷新父页面
                        parent.location.reload();
                        top.layer.close(alertIndex);
                    });
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
                layer.alert('操作失败！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
        return false;
    });
});