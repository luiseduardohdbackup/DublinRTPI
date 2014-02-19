$(document).ready(function () {

    var isMobile = (function () {
        return {
            Android: function () {
                return navigator.userAgent.match(/Android/i) ? true : false;
            },
            BlackBerry: function () {
                return navigator.userAgent.match(/BlackBerry/i) ? true : false;
            },
            iOS: function () {
                return navigator.userAgent.match(/iPhone|iPad|iPod/i) ? true : false;
            },
            Windows: function () {
                return navigator.userAgent.match(/IEMobile/i) ? true : false;
            },
            any: function () {
                return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Windows());
            }
        };
    })();

    var onDeviceViewClick = function () {

        function Show(item) {
            $(item).hide();
            var e = item;
            setTimeout(function () { $(e).show(); }, 200);
        }

        var icon = {
            android: 'fa-android',
            iOS: 'fa-apple'
        };

        var device = $('.deviceView').data('current');
        var opositeDevice = device == "iOS" ? "android" : "iOS";

        if (opositeDevice == "iOS") {
            $('.playstore').addClass('hide');
            $('.appstore').removeClass('hide');
            $('.oslabel').html('Android');
        }
        else {
            $('.appstore').addClass('hide');
            $('.playstore').removeClass('hide');
            $('.oslabel').html('iOS');
        }


        $('.deviceView').find('i').removeClass(icon[opositeDevice]);
        $('.' + device).each(function (index, item) {
            Show($(item));

            var imgSrc = {
                android: $(item).data('android'),
                iOS: $(item).data('ios')
            };

            $(item).removeClass(device); // remove device class
            $(item).removeClass('fadeIn').addClass("hide");
            $(item).addClass(opositeDevice); // add new device class

            $(item).attr('src', imgSrc[opositeDevice]); // new image
        });
        $('.deviceView').data('current', opositeDevice);
        $('.deviceView').find('i').addClass(icon[device]);
    }

    $(window).scroll(function () {
        $('.animatedElement').each(function () {
            var imagePos = $(this).offset().top;

            var topOfWindow = $(window).scrollTop();
            if (imagePos < topOfWindow + 400) {
                $(this).removeClass("hide").addClass("fadeIn");
            }
        });
    });

    var init = function () {
        $('.deviceView').tooltip();
        $('.deviceView').on('click', function (eventArgs) { onDeviceViewClick(); });
        if (isMobile.Android()) {
            onDeviceViewClick();
        }
    }

    init();
});