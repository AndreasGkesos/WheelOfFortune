function openNav() {
    document.getElementById("mySidenav").style.width = "400px";
    document.getElementById("main").style.marginLeft = "400px";
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft= "0";
    document.body.style.backgroundColor = "white";
}


jQuery(document).ready(function ($) {
    //open popup
    $('.gs-popup-trigger').on('click', function (event) {
        event.preventDefault();
        $('.gs-popup').addClass('is-visible');
        $('.gs-intro').addClass('hidden');
    });

    //close popup
    $('.gs-popup').on('click', function (event) {
        if ($(event.target).is('.gs-popup-close') || $(event.target).is('.gs-popup') || $(event.target).is('.popup-back') || $(event.target).is('.gs-modal-trigger')) {
            event.preventDefault();
            $(this).removeClass('is-visible');
        }
    });
    //close popup when clicking the esc keyboard button
    $(document).keyup(function (event) {
        if (event.which == '27') {
            $('.gs-popup').removeClass('is-visible');
        }
    });
});


jQuery(document).ready(function ($) {
    //cache some jQuery objects
    var modalTrigger = $('.gs-modal-trigger'),
        transitionLayer = $('.gs-transition-layer'),
        transitionBackground = transitionLayer.children(),
        modalWindow = $('.gs-modal');
    previusWindow = $('.gs-popup');
    wheelShow = $('.wheel-container');

    var frameProportion = 1.78, //png frame aspect ratio
        frames = transitionLayer.data('frame'), //number of png frames
        resize = false;

    //set transitionBackground dimentions
    setLayerDimensions();
    $(window).on('resize', function () {
        if (!resize) {
            resize = true;
            (!window.requestAnimationFrame) ? setTimeout(setLayerDimensions, 300) : window.requestAnimationFrame(setLayerDimensions);
        }
    });

    //open modal window
    modalTrigger.on('click', function (event) {
        event.preventDefault();
        var modalId = $(event.target).attr('href');
        transitionLayer.addClass('visible opening');
        wheelShow.removeClass('hidden');
        var delay = ($('.no-cssanimations').length > 0) ? 0 : 800;
        setTimeout(function () {
            modalWindow.filter(modalId).addClass('visible');
            transitionLayer.removeClass('opening');
        }, delay);
    });

    //close modal window
    modalWindow.on('click', '.modal-close', function (event) {
        event.preventDefault();
        transitionLayer.addClass('closing');
        modalWindow.removeClass('visible');
        wheelShow.addClass('hidden');
        transitionBackground.one('webkitAnimationEnd oanimationend msAnimationEnd animationend', function () {
            transitionLayer.removeClass('closing opening visible');
            transitionBackground.off('webkitAnimationEnd oanimationend msAnimationEnd animationend');
        });
        previusWindow.addClass('is-visible');
    });

    function setLayerDimensions() {
        var windowWidth = $(window).width(),
            windowHeight = $(window).height(),
            layerHeight, layerWidth;

        if (windowWidth / windowHeight > frameProportion) {
            layerWidth = windowWidth;
            layerHeight = layerWidth / frameProportion;
        } else {
            layerHeight = windowHeight * 1.2;
            layerWidth = layerHeight * frameProportion;
        }

        transitionBackground.css({
            'width': layerWidth * frames + 'px',
            'height': layerHeight + 'px',
        });

        resize = false;
    }
});