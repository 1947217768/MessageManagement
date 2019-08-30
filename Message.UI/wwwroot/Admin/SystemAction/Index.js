layui.use(['form', 'element', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;
    element = layui.element;
    //用户列表
    var tableIns = table.render({
        elem: '#dataTable',
        url: '/Admin/SystemAction/LoadData/',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "dataTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: "Id", title: 'Id', width: 70, align: "center" },
            { field: 'ScontrollerName', title: '控制器', minWidth: 50, align: "center" },
            { field: 'SactionName', title: 'Action', minWidth: 50, align: "center" },
            { field: 'SresultType', title: '返回类型', minWidth: 50, align: "center" },

            { field: 'Sremarks', title: '备注', align: 'center' }
        ]]
    });

    $("#btnSearch").click(function () {
        table.reload("dataTable", {
            url: '/Admin/SystemAction/LoadData/',
            page: {
                curr: 1
            },
            where: {
                ScontrollerName: $("#ScontrollerName").val(),
                SactionName: $("#SactionName").val(),
                Sremarks: $("#Sremarks").val()
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
            content: "/Admin/SystemAction/AddOrModify/",
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find("#Id").val(edit.Id);
                    body.find("#ScontrollerName").val(edit.ScontrollerName);
                    body.find("#SactionName").val(edit.SactionName);
                    body.find("#IcontrollerId").val(edit.IcontrollerId);
                    body.find("#SresultType").val(edit.SresultType); 

                    body.find("#Sremarks").text(edit.Sremarks === null ? "" : edit.Sremarks);
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
            layer.confirm('确定删除选中的方法？', { icon: 3, title: '提示信息' }, function (index) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/SystemAction/DeleteRange/',
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
    //反射控制器
    $("#btnRef").click(function () {
        layer.load();
        $.ajax({
            type: 'POST',
            url: '/Admin/SystemAction/ReflectionController/',
            //data: { arrUserId: arrUserId },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
            },
            success: function (data) {//res为相应体,function为回调函数
                layer.closeAll('loading'); //关闭loading
                layer.msg(data.msg, {
                    time: 2000 //20s后自动关闭
                }, function () {
                    tableIns.reload();
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.closeAll('loading'); //关闭loading
                layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
    });

});
