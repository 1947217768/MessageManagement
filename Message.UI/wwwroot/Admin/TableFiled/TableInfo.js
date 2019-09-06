layui.use(['form', 'element', 'layer', 'table'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        table = layui.table;
    element = layui.element;
    //let sMappingCode = $("#MappingCode").val();
    var textarea = document.getElementsByTagName("textarea");
    for (var i = 0; i < textarea.length; i++) {
        let code = textarea[i].value;
        code=code.replace(new RegExp("<var>", "g"), "");
        code=code.replace(new RegExp("</var>", "g"), "");
        textarea[i].value = code;
    }
    $("#btnCopyMapingCode").bind("click", function () {
        Copy(document.getElementById("MappingCode"));
    });
    $("#btnCopyMapingCode").bind("click", function () {
        Copy(document.getElementById("MappingCode"));
    });
    
    $("#btnCopyAddOrModifyCode").bind("click", function () {
        Copy(document.getElementById("AddOrModifyCode"));
    });

    $("#btnCopyIRepositoryCode").bind("click", function () {
        Copy(document.getElementById("IRepositoryCode"));
    }); 
    $("#btnCopyRepositoryCode").bind("click", function () {
        Copy(document.getElementById("RepositoryCode"));
    }); 
    $("#btnCopyBaseRepositoryCode").bind("click", function () {
        Copy(document.getElementById("BaseRepositoryCode"));
    });
    $("#btnCopyIServiceCode").bind("click", function () {
        Copy(document.getElementById("IServiceCode"));
    });
    $("#btnCopyServiceCode").bind("click", function () {
        Copy(document.getElementById("ServiceCode"));
    });
    $("#btnCopyControllerCode").bind("click", function () {
        Copy(document.getElementById("ControllerCode"));
    });
    $("#btnCopyIndex_HtmlCode").bind("click", function () {
        Copy(document.getElementById("Index_HtmlCode"));
    }); 

    $("#btnCopyIndex_JsCode").bind("click", function () {
        Copy(document.getElementById("Index_JsCode"));
    });

    $("#btnCopyAddOrModifyhtmlCode").bind("click", function () {
        Copy(document.getElementById("AddOrModifyhtmlCode"));
    }); 
    $("#btnCopyAddOrModifyjsCode").bind("click", function () {
        Copy(document.getElementById("AddOrModifyjsCode"));
    }); 
});
function Copy(obj) {
    obj.select();
    document.execCommand("copy");
}