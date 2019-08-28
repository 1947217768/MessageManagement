layui.use(['form', 'layer', 'upload'], function () {
    var form = layui.form;
    $ = layui.jquery;
    var layer = parent.layer === undefined ? layui.layer : top.layer,
        upload = layui.upload;
    //上传头像
    upload.render({
        elem: '.userFaceBtn',
        url: '/Admin/UploadFileInfo/UploadImage/',
        size: 1024,
        method: "post",
        before: function (obj) {
            layer.load(); //上传loading
        },
        done: function (res, index, upload) {
            if (res.code === 0) {
                $('#userFace').attr('src', res.data.src);
                window.sessionStorage.setItem('userFace', res.data.src);
                $("#Avatar").val(res.data.src);
                $("#Uid").val(res.data.Uid);
            }
            else {
                layer.msg(res.msg);
            }
            layer.closeAll('loading'); //关闭loading
        },
        error: function (index, upload) {
            layer.closeAll('loading'); //关闭loading
        }
    });
    form.on("submit(btnSubmit)", function () {
        //获取防伪标记
        layer.load();
        $.ajax({
            type: 'POST',
            url: '/Admin/UserInfo/PersonalInfo/',
            data: {
                SuserName: $("#SuserName").val(),
                SuserEmail: $("#SuserEmail").val(),
                SuserPhone: $("#SuserPhone").val(),
                SoldPassWord: $("#SoldPassWord").val(),
                SnewPassWord: $("#SnewPassWord").val(),
                SconfirmPassWord: $("#SconfirmPassWord").val(),
                Uid: $("#Uid").val()
            },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
            },
            success: function (res) {//res为相应体,function为回调函数
                layer.closeAll('loading');
                var alertIndex;
                if (res.Code === 0) {
                    alertIndex = layer.alert(res.Msg, { icon: 1 }, function (index) {
                        layer.close(index);
                        parent.parent.location.reload();
                        top.layer.close(alertIndex);
                    });

                } else {
                    alertIndex = layer.alert(res.Msg, { icon: 5 }, function (index) {
                        layer.close(index);
                        location.reload();
                        top.layer.close(alertIndex);
                    });
                }

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.closeAll('loading');
                layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            },
            complete: function () {
                obj.text("立即提交").removeAttr("disabled").removeClass("layui-disabled");
            }
        });
        return false;
    });

});