layui.config({
    base: "/layui/"
}).extend({
    "tableSelect": "tableSelect"
});
layui.use(['form', 'layer', 'tableSelect'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        tableSelect = layui.tableSelect;
    var iPageId = GetParameter("iPageId"),
        iAddorModifyMethodeId = $("#iAddorModifyMethodeId").val();
        //菜单
        tableSelect.render({
            elem: '#SmenuName',	//定义输入框input对象 必填
            checkedKey: 'Id', //表格的唯一建值，非常重要，影响到选中状态 必填
            searchKey: 'Sname',	//搜索输入框的name值 默认keyword
            searchPlaceholder: '搜索菜单名称',	//搜索输入框的提示文字 默认关键词搜索
            table: {	//定义表格参数，与LAYUI的TABLE模块一致，只是无需再定义表格elem
                url: '/Admin/Menu/LoadData?iPageId=' + iPageId + '&iMethodId=1306',
                cols: [[
                    { type: "radio", fixed: "left", width: 50 },
                    { field: "Id", title: 'Id', width: 50, align: "center" },
                    { field: 'Sname', title: '菜单名称', minWidth: 50, align: "center" },
                    { field: 'SlinkUrl', title: 'URL', minWidth: 50, align: "center" },
                    { field: 'Sremarks', title: '备注', align: 'center' }
                ]]
            },
            done: function (elem, data) {
                console.log(elem);
                console.log(data);
                $("#SmenuName").val(data.data[0].Sname);
                $("#ImenuId").val(data.data[0].Id);
            }
        });
    //Action
    tableSelect.render({
        elem: '#SactionName',	//定义输入框input对象 必填
        checkedKey: 'Id', //表格的唯一建值，非常重要，影响到选中状态 必填
        searchKey: 'ScontrollerName',	//搜索输入框的name值 默认keyword
        searchPlaceholder: '搜索控制器',	//搜索输入框的提示文字 默认关键词搜索
        table: {	//定义表格参数，与LAYUI的TABLE模块一致，只是无需再定义表格elem
            url: '/Admin/SystemAction/LoadData?iPageId=' + iPageId + '&iMethodId=1328',
            cols: [[
                { type: "radio", fixed: "left", width: 50 },
                { field: "Id", title: 'Id', width: 70, align: "center" },
                { field: 'ScontrollerName', title: '控制器', minWidth: 50, align: "center" },
                { field: 'SactionName', title: 'Action', minWidth: 50, align: "center" },
                { field: 'SresultType', title: '返回类型', minWidth: 50, align: "center" },
                { field: 'Sremarks', title: '备注', align: 'center' }
            ]]
        },
        done: function (elem, data) {
            console.log(elem);
            console.log(data);
            $("#SactionName").val(data.data[0].SactionName);
            $("#IactionId").val(data.data[0].Id);
        }
    });


    form.on("submit(btnSubmit)", function (data) {
        layer.load();
        //获取防伪标记
        $.ajax({
            type: 'POST',
            url: '/Admin/MenuAction/AddOrModify?iPageId=' + iPageId + '&iMethodId=' + iAddorModifyMethodeId,
            data: {
                Id: $("#Id").val(),
                Sremarks: $("#Sremarks").val(),
                ImenuId: $("#ImenuId").val(),
                IactionId: $("#IactionId").val(),
                Sexplain: $("#Sexplain").val(),
                BisValid: $("#BisValid").get(0).checked
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