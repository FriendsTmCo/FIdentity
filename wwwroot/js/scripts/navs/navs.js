/*=========================================================================================
    File Name: nav.js
    Description: Navigation available in Bootstrap share general markup and styles, from the base .nav class to the active and disabled states. Swap modifier classes to switch between each style.
==========================================================================================*/
(function (window, document, $) {
    'use strict';
    // for active tab arrow
    $(document).on('click', '.nav-tabs .nav-item', function () {
        $(this).addClass('current').siblings().removeClass('current');
    });
    // add current class to parent of active class
    $('.nav-tabs .nav-item').find('.active').parent().addClass("current");
})(window, document, jQuery);