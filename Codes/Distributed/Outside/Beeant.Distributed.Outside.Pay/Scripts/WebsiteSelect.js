$(function() {


    var orderPay = function () {
        if ($("#selPayTypes").find("li").length == 0) {
            window.location.href = $("#selPayTypes").attr("NopayUrl");
            return;
        }
        $("#fmPayType").attr("action", $("#selPayTypes").find("li.select").attr("ActionUrl"));
   
    }

  
    $(".paytype-bd ul li").click(function () {
        if (!$(this).hasClass("select")) {
            $(this).addClass("select").siblings().removeClass("select");
            orderPay();
        }
    });

})