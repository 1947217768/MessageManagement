layui.config({
    base: "/layui/"
}).extend({
    "selectM": "selectM"
});
layui.use(['form', 'layer', 'selectM'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery, selectM = layui.selectM;
    var iMenuId = $("#Id").val();
    var arrUserRoleId = new Array();
    if (iMenuId > 0) {
        $.ajax({
            type: 'Get',
            async: false,
            url: '/Admin/RoleMenu/GetMenuRole?iMenuId=' + iMenuId,
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
        , data: "/Admin/Roles/GetRoleList/"
        , max: 1000
        , selected: arrUserRoleId
        , width: 250
        //添加验证
        // , verify: 'required'
    });
    form.on("submit(btnSubmit)", function (data) {
        //获取防伪标记
        $.ajax({
            type: 'POST',
            url: '/Admin/Menu/AddOrModify',
            data: {
                Id: $("#Id").val(),  //主键
                Sname: $("#Sname").val(),
                SlinkUrl: $("#SlinkUrl").val(),
                Isort: $("#Isort").val(),
                SiconUrl: $("#SiconUrl").val(),
                IparentId: $("#IparentId").val(),
                Bdisplay: $("#Bdisplay").get(0).checked,
                Sremarks: $("#Sremarks").val(),
                lstRoleId: tagIns1.values
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
                layer.alert('操作失败！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
        return false;
    });
});