$(function() {

    function setPayForm() {
        if ($("#selPayTypes").find("li.select").attr("PayTypeName") == "支付宝") {
            $("#fmPayType").attr("target", "");
            $("#hfseccesshandle").val("");
            $("#hffailhandle").val("");
            $("#hfcreatehandle").val("");
        } else {
            $("#fmPayType").attr("target", "fmPayType");
            $("#hfseccesshandle").val("parent.seccess");
            $("#hffailhandle").val("parent.fail");
            $("#hfcreatehandle").val("parent.create");
        }
    }

    var orderPay = function () {
        if ($("#selPayTypes").find("li").length == 0) {
            window.location.href = $("#selPayTypes").attr("NopayUrl");
            return;
        }
        $("#fmPayType").attr("action", $("#selPayTypes").find("li.select").attr("ActionUrl"));
        setPayForm();
    }

  
    $(".paytype-bd ul li").click(function () {
        if (!$(this).hasClass("select")) {
            $(this).addClass("select").siblings().removeClass("select");
            orderPay();
        }
    });

})