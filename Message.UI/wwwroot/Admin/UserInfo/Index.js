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
        url: '/Admin/UserInfo/LoadData/',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "dataTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: "Id", title: 'Id', width: 50, align: "center" },
            { field: 'SloginName', title: '登录名', minWidth: 50, align: "center" },
            { field: 'SuserName', title: '用户昵称', minWidth: 50, align: "center" },
            { field: 'SuserPhone', title: '手机号码', minWidth: 80, align: "center" },
            { field: 'SuserEmali', title: '邮箱地址', minWidth: 100, align: "center" },
            { field: 'Sremarks', title: '备注', align: 'center' },
            { field: 'BisLock', title: '是否锁定', minWidth: 100, fixed: "right", align: "center", templet: '#IsLock' }
        ]]
    });

    $("#btnSearch").click(function () {
        table.reload("dataTable", {
            url: '/Admin/UserInfo/LoadData/',
            page: {
                curr: 1
            },
            where: {
                SloginName: $("#SloginName").val(),
                SuserName: $("#SuserName").val(),
                SuserEmail: $("#SuserEmail").val(),
                SuserPhone: $("#SuserPhone").val(),
                Sremarks: $("#Sremarks").val(),
                BisLock: $("#BisLock").get(0).checked
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
            content: "/Admin/UserInfo/AddOrModify/",
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find("#Id").val(edit.Id);
                    body.find("#SloginName").val(edit.SloginName);
                    body.find("#SuserName").val(edit.SuserName);
                    body.find("#SuserEmail").val(edit.SuserEmail);
                    body.find("#SuserPhone").val(edit.SuserPhone);
                    body.find("#SuserEmail").val(edit.SuserEmail);
                    body.find("input:checkbox[id='BisLock']").prop("checked", edit.BisLock);
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
            arrUserId = [];
        if (data.length > 0) {
            for (var i in data) {
                arrUserId.push(data[i].Id);
            }
            layer.confirm('确定删除选中的用户？', { icon: 3, title: '提示信息' }, function (index) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/UserInfo/DeleteRange/',
                    data: { arrUserId: arrUserId },
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
            layer.msg("请选择需要删除的用户");
        }
    });

    form.on('switch(IsLock)', function (data) {
        var tipText = '确定锁定当前用户吗？';
        if (!data.elem.checked) {
            tipText = '确定启用当前用户吗？';
        }
        layer.confirm(tipText, {
            icon: 3,
            title: '系统提示',
            cancel: function (index) {
                data.elem.checked = !data.elem.checked;
                form.render();
                layer.close(index);
            }
        }, function (index) {
            changeLockStatus(data.value, data.elem.checked);
            layer.close(index);
        }, function (index) {
            data.elem.checked = !data.elem.checked;
            form.render();
            layer.close(index);
        });
    });

    function changeLockStatus(iUserId, bIsLock) {
        $.ajax({
            type: 'POST',
            url: '/Admin/UserInfo/ChangeUserLockStates/',
            data: { Id: iUserId, BisLock: bIsLock },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
            },
            success: function (data) {
                layer.msg(data.Msg, {
                    time: 2000 //2s后自动关闭
                }, function () {
                    tableIns.reload();
                    layer.close(index);
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
    }
});
