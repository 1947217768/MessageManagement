layui.use(['form', 'layer'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;
    var iPageId = GetParameter("iPageId"),
        iAddorModifyMethodeId = $("#iAddorModifyMethodeId").val();
    form.on("submit(btnSubmit)", function (data) {
        layer.load();
        $.ajax({
            type: 'POST',
            url: '/Admin/TableFiled/AddOrModify?iPageId=' + iPageId + '&iMethodId=' + iAddorModifyMethodeId,
            data: {
                Id: $("#Id").val(),
                IdataTableId: $("#IdataTableId").val(),
                SfiledName: $("#SfiledName").val(),
                Sexplain: $("#Sexplain").val(),
                IdataTypeId: $("#IdataTypeId").val(),
                BisEmpty: $("#BisEmpty").is(':checked'),
                ImaxLength: $("#ImaxLength").val(),
                Sremarks: $("#Sremarks").val()
            },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
            },
            success: function (res) {
                layer.closeAll('loading');
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
                layer.closeAll('loading');
                layer.alert('操作失败！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
        return false;
    });
});