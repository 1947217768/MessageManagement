
layui.use(['layedit', 'layer', 'jquery'], function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/Memo").build();
    var $ = layui.jquery
        , layer = layui.layer
        , layedit = layui.layedit;
    var changeStartValue = $("#Scontent").val();
    layedit.set({
        //暴露layupload参数设置接口 --详细查看layupload参数说明
        uploadImage: {
            url: '/Admin/UploadFileInfo/UploadImage?iPageId=1&iMethodId=1336',
            accept: 'image',
            acceptMime: 'image/*',
            exts: 'jpg|png|gif|bmp|jpeg',
            size: 1024 * 10,
            data: {
                name: "测试参数",
                age: 99
            }
            , done: function (data) {
                console.log(data);
            }
        },
        uploadVideo: {
            url: '/Admin/UploadFileInfo/UploadImage?iPageId=1&iMethodId=1336',
            accept: 'video',
            acceptMime: 'video/*',
            exts: 'mp4|flv|avi|rm|rmvb',
            size: 1024 * 10 * 2,
            done: function (data) {
                console.log(data);
            }
        }
        , uploadFiles: {
            url: 'your url',
            accept: 'file',
            acceptMime: 'file/*',
            size: '20480',
            autoInsert: true, //自动插入编辑器设置
            done: function (data) {
                console.log(data);
            }
        }
        //右键删除图片/视频时的回调参数，post到后台删除服务器文件等操作，
        //传递参数：
        //图片： imgpath --图片路径
        //视频： filepath --视频路径 imgpath --封面路径
        //附件： filepath --附件路径
        , calldel: {
            url: '/Admin/UploadFileInfo/DeleteFile?iPageId=39&iMethodId=1450',
            done: function (data) {
                console.log(data);
            }
        }
        , rightBtn: {
            type: "layBtn",//default|layBtn|custom  浏览器默认/layedit右键面板/自定义菜单 default和layBtn无需配置customEvent
            customEvent: function (targetName, event) {
                //根据tagName分类型设置
                switch (targetName) {
                    case "img":
                        alert("this is img");
                        break;
                    default:
                        alert("hello world");
                        break;
                };
                //或者直接统一设定
                //alert("all in one");
            }
        }
        //测试参数
        , backDelImg: true
        //开发者模式 --默认为false
        , devmode: true
        //是否自动同步到textarea
        , autoSync: true
        //内容改变监听事件
        , onchange: function (content) {
            var message = content;
            connection.invoke("SendMessage", message).catch(function (err) {
                return console.error(err.toString());
            });
            //console.log(content);
            //let changeValue = content.substring(changeStartValue.length, content.length);
            //changeStartValue = content;
            //console.log(changeValue);
            //保存
            //$.ajax({
            //    url: "/Admin/Memo/Save?iPageId=39&iMethodId=1451&sContent=" + content,
            //    type: "GET",
            //    headers: {
            //        "X-CSRF-TOKEN-Header": $("input[name='AntiforgeryFieldname']").val()
            //    },
            //    success: function (data) {//res为相应体,function为回调函数
            //    },
            //    error: function (XMLHttpRequest, textStatus, errorThrown) {
            //        layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            //    }
            //});
        }
        //插入代码设置 --hide:false 等同于不配置codeConfig
        , codeConfig: {
            hide: true,  //是否隐藏编码语言选择框
            default: 'javascript', //hide为true时的默认语言格式
            encode: true //是否转义
            , class: 'layui-code' //默认样式
        }
        //新增iframe外置样式和js
        , quote: {
            style: ['Content/css.css'],
            //js: ['/Content/Layui-KnifeZ/lay/modules/jquery.js']
        }
        //自定义样式-暂只支持video添加
        //, customTheme: {
        //    video: {
        //        title: ['原版', 'custom_1', 'custom_2']
        //        , content: ['', 'theme1', 'theme2']
        //        , preview: ['', '/images/prive.jpg', '/images/prive2.jpg']
        //    }
        //}
        //插入自定义链接
        //, customlink: {
        //    title: '插入layui官网'
        //    , href: 'https://www.layui.com'
        //    , onmouseup: ''
        //}
        , facePath: 'http://knifez.gitee.io/kz.layedit/Content/Layui-KnifeZ/'
        , devmode: true
        , videoAttr: ' preload="none" '
        //预览样式设置，等同layer的offset和area规则，暂时只支持offset ,area两个参数
        //默认为 offset:['r'],area:['50%','100%']
        //, previewAttr: {
        //    offset: 'r'
        //    ,area:['50%','100%']
        //}
        , tool: [
            'html', 'undo', 'redo', 'code', 'strong', 'italic', 'underline', 'del', 'addhr', '|', 'removeformat', 'fontFomatt', 'fontfamily', 'fontSize', 'fontBackColor', 'colorpicker', 'face'
            , '|', 'left', 'center', 'right', '|', 'link', 'unlink', 'images', 'image_alt', 'video', 'attachment', 'anchors'
            , '|'
            , 'table', 'customlink'
            , 'fullScreen', 'preview'
        ]
        , height: '500px'
    });
    var ieditor = layedit.build('Scontent');
    //设置编辑器内容
    //layedit.setContent(ieditor, "<h1>hello layedit</h1><p>对layui.layedit的拓展，基于layui v2.4.3.增加了HTML源码模式、插入table、批量上传图片、图片插入、超链接插入功能优化、视频插入功能、全屏功能、段落、字体颜色、背景色设置、锚点设置等功能。</p><br><br><div>by KnifeZ </div>", false);
    $("#openlayer").click(function () {
        layer.open({
            type: 2,
            area: ['700px', '500px'],
            fix: false, //不固定
            maxmin: true,
            shadeClose: true,
            shade: 0.5,
            title: "title",
            content: 'add.html'
        });
    });
    var isPinyin = false;
    //$("#openlayer").keyup(function () {
    //    $('#openlayer').on('compositionstart', function (e) { isPinyin = true; }, false);//此时为拼音输入法
    //    $('#openlayer').on('compositionend', function (e) {
    //        isPinyin = false;

    //    }, false);//此时为直接输入，包括数字、字符和英文输入

    //});

    //判断连接是否成功
    connection.start().then(function () {
        layer.msg("websocket连接成功!");
    }).catch(function (err) {
        return console.error(err.toString());
    });
    connection.on("ReceiveMessage", function (message) {
        //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        layedit.setContent(ieditor, message, false);

    });
});
