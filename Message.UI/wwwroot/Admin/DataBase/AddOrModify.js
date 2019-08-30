layui.config({
    base: "/layui/"
}).extend({
    "selectM": "selectM"
});
layui.use(['form', 'layer', 'selectM'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;
    form.on("submit(btnSubmit)", function (data) {
        layer.load();
        //获取防伪标记
        $.ajax({
            type: 'POST',
            url: '/Admin/DataBase/AddOrModify',
            data: {
                Id: $("#Id").val(),  //主键
                SdataBaseName: $("#SdataBaseName").val(),
                Sremarks: $("#Sremarks").val()
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
});