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
            $(item).addClass(opositeDevice); // add new device class

            $(item).attr('src', imgSrc[opositeDevice]); // new image
        });
        $('.deviceView').data('current', opositeDevice);
        $('.deviceView').find('i').addClass(icon[device]);
    }

    var init = function () {
        $('.deviceView').tooltip();
        $('.deviceView').on('click', function (eventArgs) { onDeviceViewClick(); });
        if (isMobile.Android()) {
            onDeviceViewClick();
        }
    }

    init();
});