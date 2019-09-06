layui.use(['form', 'element', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;
    element = layui.element;
    var iPageId = GetParameter("iPageId"),
        iLoadDataMethodeId = $("#iLoadDataMethodeId").val(),
        iAddorModifyMethodeId = $("#iAddorModifyMethodeId").val(),
        iDeleteMethodeId = $("#iDeleteMethodeId").val();
    //用户列表
    var tableIns = table.render({
        elem: '#dataTable',
        url: '/Admin/Menu/LoadData?iPageId=' + iPageId + '&iMethodId=' + iLoadDataMethodeId,
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "dataTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: "Id", title: 'Id', width: 50, align: "center" },
            { field: 'Sname', title: '菜单名称', minWidth: 50, align: "center" },
            { field: 'SlinkUrl', title: 'URL', minWidth: 50, align: "center" },
            { field: 'Isort', title: '排序', minWidth: 80, align: "center" },
            { field: 'Sremarks', title: '备注', align: 'center' },
            { field: 'Bdisplay', title: '是否隐藏', minWidth: 100, fixed: "right", align: "center", templet: '#BdisplayTmp' }
        ]]
    });

    $("#btnSearch").click(function () {
        table.reload("dataTable", {
            url: '/Admin/Menu/LoadData?iPageId=' + iPageId + '&iMethodId=' + iLoadDataMethodeId,
            page: {
                curr: 1
            },
            where: {
                Sname: $("#Sname").val(),
                Sremarks: $("#Sremarks").val(),
                Bdisplay: $("#Bdisplay").get(0).checked
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
            content: '/Admin/Menu/AddOrModify?iPageId=' + iPageId + '&iMethodId=' + iAddorModifyMethodeId,
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find("#Id").val(edit.Id);
                    body.find("#Sname").val(edit.Sname);
                    body.find("#SlinkUrl").val(edit.SlinkUrl);
                    body.find("#SiconUrl").val(edit.SiconUrl);
                    body.find("#Isort").val(edit.Isort);
                    body.find("#SuserEmail").val(edit.SuserEmail);
                    body.find("input:checkbox[id='Bdisplay']").prop("checked", edit.Bdisplay);
                    body.find("#IparentId").val(edit.IparentId);
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
            layer.confirm('确定删除选中的数据？', { icon: 3, title: '提示信息' }, function (index) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/Menu/DeleteRange?iPageId=' + iPageId + '&iMethodId=' + iDeleteMethodeId,
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

    function changeState(iMenuId, bDisplpy) {
        $.ajax({
            type: 'POST',
            url: '/Admin/Menu/ChangeMenuState?iPageId=' + iPageId + '&iMethodId=1309',
            data: { Id: iMenuId, Bdisplay: bDisplpy },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
            },
            success: function (data) {
                layer.msg(data.msg, {
                    time: 2000 //2s后自动关闭
                }, function () {
                    tableIns.reload();
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
    }

    form.on('switch(BdisplayTmp)', function (data) {
        var tipText = '确定隐藏当前菜单吗？';
        if (!data.elem.checked) {
            tipText = '确定显示当前菜单吗？';
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
            changeState(data.value, data.elem.checked);
            layer.close(index);
        }, function (index) {
            data.elem.checked = !data.elem.checked;
            form.render();
            layer.close(index);
        });
    });
});
