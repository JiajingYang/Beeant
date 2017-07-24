$(function() {

    setInterval(function () {
        debugger;
        $.ajax({
            type: 'Post',
            url: '/WechatPay/Check?number='+window.Number,
            async: true,
            cache: false,
            dataType: 'text',
            success: function (data) {
                debugger;
                if (data == 'true') {
                    window.location.href = 'https://www.baidu.com/';
                }
            }
        });

    }, 3000);

})