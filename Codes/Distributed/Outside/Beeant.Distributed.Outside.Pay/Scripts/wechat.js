$(function() {

    setInterval(function () {
        debugger;
        $.ajax({
            type: 'Post',
            url: '/Pay/Check?number='+window.Number,
            async: true,
            cache: false,
            dataType: 'text',
            success: function (data) {
                debugger;
                if (data == 'true') {
                    window.location.href = window.Url;
                }
            }
        });

    }, 3000);

})