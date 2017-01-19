/*!
 *@name     jquery.barrager.js
 *@author   youming
 */
//var item = {
//    //img: 'static/heisenberg.png', //图片
//    info: jsondata.data, //文字
//    //href: '', //链接
//    close: true, //显示关闭按钮
//    speed: 6, //延迟,单位秒,默认6
//    bottom: 0, //距离底部高度,单位0px,默认随机
//    color: getRandomColor(), //颜色,默认白色
//    old_ie_color: '#000000', //ie低版兼容色,不能与网页背景相同,默认黑色
//};
(function ($) {

    $.fn.barrager = function (barrage) {
        barrage = $.extend({
            close: true,
            bottom: 0,
            max: 10,
            speed: 6,
            color: '#fff',
            old_ie_color: '#000000'
        }, barrage || {});

        var time = new Date().getTime();
        var barrager_id = 'barrage_' + time;
        var id = '#' + barrager_id;
        var div_barrager = $("<div class='barrage' id='" + barrager_id + "'></div>").appendTo($(this));
        //var window_height = $(window).height() - 100;
        //var this_height = (window_height > this.height()) ? this.height() : window_height;
        //var bottom = (barrage.bottom == 0) ? Math.floor(Math.random() * this_height + 40) : barrage.bottom;
        var bmax = $(window).height() - $(this).offset().top - 20;
        var bmin = $(this).offset().top + 10;
        var bottom = Math.floor(Math.random() * (bmax - bmin + 1) + bmin);
        var left = $(this).offset().left + $(this).width() - 10;
        div_barrager.css("bottom", bottom + "px");
        div_barrager.css("left", left + "px");
        div_barrager_box = $("<div class='barrage_box cl'></div>").appendTo(div_barrager);
        if (barrage.img) {

            div_barrager_box.append("<a class='portrait z' href='javascript:;'></a>");
            var img = $("<img src='' >").appendTo(id + " .barrage_box .portrait");
            img.attr('src', barrage.img);
        }

        div_barrager_box.append(" <div class='z p'></div>");
        if (barrage.close) {

            div_barrager_box.append(" <div class='close z'></div>");

        }

        var content = $("<a title='' href='' target='_blank'></a>").appendTo(id + " .barrage_box .p");
        content.attr({
            'href': barrage.href,
            'id': barrage.id
        }).empty().append(barrage.info);
        if (navigator.userAgent.indexOf("MSIE 6.0") > 0 || navigator.userAgent.indexOf("MSIE 7.0") > 0 || navigator.userAgent.indexOf("MSIE 8.0") > 0) {

            content.css('color', barrage.old_ie_color);

        } else {

            content.css('color', barrage.color);

        }

        var i = left;
        //div_barrager.css('margin-left', i);
        var Danmudom = this;
        var looper = setInterval(barrager, barrage.speed);
        function barrager() {

            var window_width = $(Danmudom).width() + $(Danmudom).offset().left;
            //var window_width = $(window).width() + 500;
            if ($(Danmudom).offset().left < i && i < window_width) {
                i -= 1;

                $(id).css('left', i);
                
            } else {

                $(id).remove();
                clearInterval(looper);
                return false;
            }

        }
       //looper = setInterval(barrager, barrage.speed);

        div_barrager_box.mouseover(function () {
            clearInterval(looper);
        });

        div_barrager_box.mouseout(function () {
            looper = setInterval(barrager, barrage.speed);
        });

        $(id + '.barrage .barrage_box .close').click(function () {

            $(id).remove();

        })

    }

    $.fn.barrager.removeAll = function () {

        $('.barrage').remove();

    }

})(jQuery);
