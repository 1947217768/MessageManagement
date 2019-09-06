layui.use(['form', 'element', 'layer', 'table'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        table = layui.table,
        element = layui.element;
    var iPageId = GetParameter("iPageId"),
        iLoadDataMethodeId = $("#iLoadDataMethodeId").val(),
        iAddorModifyMethodeId = $("#iAddorModifyMethodeId").val(),
        iDeleteMethodeId = $("#iDeleteMethodeId").val();

    var tableIns = table.render({
        elem: '#dataTable',
        url: '/Admin/MenuAction/LoadData?iPageId=' + iPageId + '&iMethodId=' + iLoadDataMethodeId,
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "dataTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: "Id", title: 'ID', width: 50, align: "center" },
            { field: "SmenuName", title: '菜单名称', width: 200, align: "center" },
            { field: "ScontrollerName", title: '控制器', width: 200, align: "center" },
            { field: "SactionName", title: 'Action', width: 300, align: "center" },
            { field: "Sexplain", title: '说明', width: 200, align: "center" },
            { field: "BisValid", title: '是否有效', width: 70, align: "center" },
            { field: "Sremarks", title: '备注', width: 300, align: "center" }
        ]]
    });
    $("#btnSearch").click(function () {
        table.reload("dataTable", {
            url: '/Admin/MenuAction/LoadData?iPageId=' + iPageId + '&iMethodId=' + iLoadDataMethodeId,
            page: {
                curr: 1
            },
            where: {
                Sremarks: $("#Sremarks").val(),
                Sexplain: $("#Sexplain").val(),
                SmenuName: $("#SmenuName").val(),
                ScontrollerName: $("#ScontrollerName").val(),
                SactionName: $("#SactionName").val()
            }
        });
    });
    //添加用户
    function addManager(edit) {
        var tit = "添加";
        if (edit) {
            tit = "编辑";
        }
        var index = layui.layer.open({
            title: tit,
            type: 2,
            anim: 1,
            area: ['800px', '90%'],
            content: '/Admin/MenuAction/AddOrModify?iPageId=' + iPageId + '&iMethodId=' + iAddorModifyMethodeId,
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find("#Id").val(edit.Id);
                    body.find("#Sremarks").text(edit.Sremarks === null ? "" : edit.Sremarks);
                    body.find("#ImenuId").val(edit.ImenuId);
                    body.find("#IactionId").val(edit.IactionId);
                    body.find("#SmenuName").val(edit.SmenuName);
                    body.find("#SactionName").val(edit.SactionName);
                    body.find("#Sexplain").val(edit.Sexplain);
                    body.find("input:checkbox[id='BisValid']").prop("checked", edit.BisValid);
                    form.render();
                }
            }
        });
    }
    $("#btnAdd").click(function () {
        addManager();
    });
    $("#btnCopy").click(function () {
        var checkStatus = table.checkStatus('dataTable'),
            data = checkStatus.data;
        if (data.length === 1) {
            data[0].Id = 0;
            addManager(data[0]);
        } else if (data.length > 1) {
            layer.msg("只能选择一条数据!");
        } else {
            layer.msg("请选择需要复制的数据!");
        }
    });
    $("#btnUpdate").click(function () {
        var checkStatus = table.checkStatus('dataTable'),
            data = checkStatus.data;
        if (data.length === 1) {
            addManager(data[0]);
        } else if (data.length > 1) {
            layer.msg("只能选择一条数据!");
        } else {
            layer.msg("请选择需要修改的数据!");
        }
    });

    //批量删除
    $("#btnDelete").click(function () {
        var checkStatus = table.checkStatus('dataTable'),
            data = checkStatus.data,
            arrId = [];
        if (data.length > 0) {
            for (var i in data) {
                arrId.push(data[i].Id);
            }
            layer.confirm('确定删除选中的数据？', { icon: 3, title: '提示信息' }, function (index) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/MenuAction/DeleteRange?iPageId=' + iPageId + '&iMethodId=' + iDeleteMethodeId,
                    data: { arrId: arrId },
                    dataType: "json",
                    headers: {
                        "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
                    },
                    success: function (data) {//res为相应体,function为回调函数
                        layer.msg(data.Msg, {
                            time: 2000 //20s后自动关闭
                        }, function () {
                            tableIns.reload();
                            layer.close(index);
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
                    }
                });
            });
        } else {
            layer.msg("请选择需要删除的数据");
        }
    });
});
