var balance=0;
var imagedata;
var userId;

function IndexController_init(config) {
  
     userId = config.userId;


    UpdateBalanceContainer(userId);
    InitialListeners();
    theTour();
    GetUserPhoto(userId);
    

    var slider = document.getElementById("BetValue");
    var output = document.getElementById("bet");
    output.innerHTML = slider.value;

    slider.oninput = function() {
        output.innerHTML = this.value;
    }


    $('#betAndPlayBtn').on('click', function (event) {
        if (balance === 100) {
            toastr.warning("Wheel oF fortune offers you 100$ as  a beginner gift.Have Fun");
        }
        if (balance <= 50) {
          //  dialog.init();
            toastr.warning("Yor balance is getting very low ");
            toastr.warning("Consider using one of your coupon to raise your balance");
        } 

    });

}


function UpdateBalanceContainer(user) {

    $.ajax({
        type: "GET",
        url: "/api/Balance/GetBalance/",
        data: { userId: user },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {
            $("#balanceValue").hide(250).show(250);
            $("#balanceValue").text(msg);
            balance = msg;
            $("#BetValue").attr("max", balance);
        },
        fail: function(msg) {
            alert("error in getting the balance");
        }

    });
}




function GetUserPhoto(user) {
    $.ajax({
        type: "GET",
        url: "/api/User/GetUserPhoto/",
        data: { userId: user },
        cache:true
    }).always(function (data) {
        ImageData = data;
        if ((data === null) || (data === undefined) || (data.length <= 0)) {
            $("#imageProfiler").attr("src", "../../Content/img/userPhotoImageFail.png").fadeIn();
        }
        localStorage.setItem("image", JSON.stringify(data));

        $("#imageProfiler").attr("src", "data:image/png;base64,"+ data).fadeIn();
    });


}

function InitialListeners() {
    // box js 
    $(document).ready(function ($) {
        //open/close box
        $('.box-trigger').on('click', function (event) {
            event.preventDefault();
            if ($('.box-container').hasClass('open')) {
                $('.box-container').removeClass('open');
            } else {
                $('.box-container').addClass('open');
            }

        });

        $(".spinBtn").on("click", function (event) {
            $('.box-container').removeClass('open');
            $(".modal-close").addClass('disable');
        });

        //cache some jQuery objects
        var modalTrigger = $(".gs-modal-trigger"),
            transitionLayer = $(".gs-transition-layer"),
            transitionBackground = transitionLayer.children(),
            modalWindow = $(".gs-modal");
        previusWindow = $(".gs-popup");
        wheelShow = $(".wheel-container");

        var frameProportion = 1.78, //png frame aspect ratio
            frames = transitionLayer.data("frame"), //number of png frames
            resize = false;

        //set transitionBackground dimentions
        setLayerDimensions();
        $(window).on("resize", function () {
            if (!resize) {
                resize = true;
                (!window.requestAnimationFrame) ? setTimeout(setLayerDimensions, 300) : window.requestAnimationFrame(setLayerDimensions);
            }
        });

        //open modal window
        modalTrigger.on("click", function (event) {
            event.preventDefault();


            $('.box-container').addClass('open').fadeIn(900);
            var modalId = $(event.target).attr("href");
            transitionLayer.addClass("visible opening");
            wheelShow.removeClass("hidden");
            var delay = ($(".no-cssanimations").length > 0) ? 0 : 800;
            setTimeout(function () {
                modalWindow.filter(modalId).addClass("visible");
                transitionLayer.removeClass("opening");
            }, delay);

        });

        //close modal window
        modalWindow.on("click", ".modal-close", function (event) {
            event.preventDefault();
            transitionLayer.addClass("closing");
            modalWindow.removeClass("visible");
            wheelShow.addClass("hidden");
            transitionBackground.one("webkitAnimationEnd oanimationend msAnimationEnd animationend", function () {
                transitionLayer.removeClass("closing opening visible");
                transitionBackground.off("webkitAnimationEnd oanimationend msAnimationEnd animationend");
            });
            previusWindow.addClass("is-visible");
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
                "width": layerWidth * frames + "px",
                "height": layerHeight + "px",
            });

            resize = false;
        }

        //open popup
        $(".gs-popup-trigger").on("click",
            function (event) {
                event.preventDefault();
                $(".gs-popup").addClass("is-visible");
                $(".gs-intro").addClass("hidden");
            });

        //close popup
        $(".gs-popup").on("click", function (event) {
            if ($(event.target).is(".gs-popup-close") || $(event.target).is(".gs-popup") || $(event.target).is(".popup-back") || $(event.target).is(".gs-modal-trigger")) {
                event.preventDefault();
                $(this).removeClass("is-visible");
            }
        });

    });

}

function theTour() {
    jQuery(document).ready(function ($) {
        //check if a .ww-tour-wrapper exists in the DOM - if yes, initialize it
        $('.ww-tour-wrapper').exists() && initTour();

        function initTour() {
            var tourWrapper = $('.ww-tour-wrapper'),
                tourSteps = tourWrapper.children('li'),
                stepsNumber = tourSteps.length,
                coverLayer = $('.ww-cover-layer'),
                tourStepInfo = $('.ww-more-info'),
                tourTrigger = $('#ww-tour-trigger');

            // Height Calculator 
            function calcBottomVal(link,target) {
                var offset = link.offset();
                var top = offset.top;
                var bottom = $(window).height() - top - link.height() - 15;
                    target.css('bottom', bottom);               
            }
            

            //create the navigation for each step of the tour
            createNavigation(tourSteps, stepsNumber);

            tourTrigger.on('click', function () {
                calcBottomVal($('#betAndPlayBtn'), $('.ww-single-step:nth-of-type(1)'));
                $('.ww-single-step:nth-of-type(2)').css({ 'bottom': 20 + 72 + 90 + 10 + 'px', 'right': '400px' });
                
                //start tour
                if (!tourWrapper.hasClass('active')) {
                    //in that case, the tour has not been started yet
                    tourWrapper.addClass('active');
                    showStep(tourSteps.eq(0), coverLayer);
                }
            });

            //change visible step
            tourStepInfo.on('click', '.ww-prev', function (event) {
                //go to prev step - if available
                (!$(event.target).hasClass('inactive')) && changeStep(tourSteps, coverLayer, 'prev');
                if (tourSteps.eq(1)) {
                    $('.box-container').removeClass('open');
                    $('.gs-modal').removeClass('visible').fadeIn(900);
                }
            });
            tourStepInfo.on('click', '.ww-next', function (event) {
                //go to next step - if available
                (!$(event.target).hasClass('inactive')) && changeStep(tourSteps, coverLayer, 'next');

                $('.gs-modal').addClass('visible').fadeIn(900);
                $('.box-container').addClass('open');





            });

            //close tour
            tourStepInfo.on('click', '.ww-close', function (event) {
                closeTour(tourSteps, tourWrapper, coverLayer);      
                $('.box-container').removeClass('open');
                $('.gs-modal').removeClass('visible').fadeIn(900);
            });

            //detect swipe event on mobile - change visible step
            tourStepInfo.on('swiperight', function (event) {
                //go to prev step - if available
                if (!$(this).find('.ww-prev').hasClass('inactive') && viewportSize() == 'mobile') changeStep(tourSteps, coverLayer, 'prev');
            });
            tourStepInfo.on('swipeleft', function (event) {
                //go to next step - if available
                if (!$(this).find('.ww-next').hasClass('inactive') && viewportSize() == 'mobile') changeStep(tourSteps, coverLayer, 'next');
            });

            //keyboard navigation
            $(document).keyup(function (event) {
                if (event.which == '37' && !tourSteps.filter('.is-selected').find('.ww-prev').hasClass('inactive')) {
                    changeStep(tourSteps, coverLayer, 'prev');
                } else if (event.which == '39' && !tourSteps.filter('.is-selected').find('.ww-next').hasClass('inactive')) {
                    changeStep(tourSteps, coverLayer, 'next');
                } else if (event.which == '27') {
                    closeTour(tourSteps, tourWrapper, coverLayer);
                }
            });
        }

        function createNavigation(steps, n) {
            var tourNavigationHtml = '<div class="ww-nav"><span><b class="ww-actual-step">1</b> of ' + n + '</span><ul class="ww-tour-nav"><li><a href="#0" class="ww-prev">&#171; Previous</a></li><li><a href="#0" class="ww-next">Next &#187;</a></li></ul></div><a href="#0" class="ww-close">Close</a>';

            steps.each(function (index) {
                var step = $(this),
                    stepNumber = index + 1,
                    nextClass = (stepNumber < n) ? '' : 'inactive',
                    prevClass = (stepNumber == 1) ? 'inactive' : '';
                var nav = $(tourNavigationHtml).find('.ww-next').addClass(nextClass).end().find('.ww-prev').addClass(prevClass).end().find('.ww-actual-step').html(stepNumber).end().appendTo(step.children('.ww-more-info'));
            });
        }

        function showStep(step, layer) {
            step.addClass('is-selected').removeClass('move-left');
            smoothScroll(step.children('.ww-more-info'));
            showLayer(layer);
        }

        function smoothScroll(element) {
            (element.offset().top < $(window).scrollTop()) && $('body,html').animate({ 'scrollTop': element.offset().top }, 100);
            (element.offset().top + element.height() > $(window).scrollTop() + $(window).height()) && $('body,html').animate({ 'scrollTop': element.offset().top + element.height() - $(window).height() }, 100);
        }

        function showLayer(layer) {
            layer.addClass('is-visible').on('webkitAnimationEnd oanimationend msAnimationEnd animationend', function () {
                layer.removeClass('is-visible');
            });
        }

        function changeStep(steps, layer, bool) {
            var visibleStep = steps.filter('.is-selected'),
                delay = (viewportSize() == 'desktop') ? 300 : 0;
            visibleStep.removeClass('is-selected');

            (bool == 'next') && visibleStep.addClass('move-left');

            setTimeout(function () {
                (bool == 'next')
                    ? showStep(visibleStep.next(), layer)
                    : showStep(visibleStep.prev(), layer);
            }, delay);
        }

        function closeTour(steps, wrapper, layer) {
            steps.removeClass('is-selected move-left');
            wrapper.removeClass('active');
            layer.removeClass('is-visible');
        }

        function viewportSize() {
            /* retrieve the content value of .ww-main::before to check the actua mq */
            return window.getComputedStyle(document.querySelector('.ww-tour-wrapper'), '::before').getPropertyValue('content').replace(/"/g, "").replace(/'/g, "");
        }
    });

    //check if an element exists in the DOM
    jQuery.fn.exists = function () { return this.length > 0; }
}


//var dialog = bootbox.dialog({
//    title: 'Oops your current balance is too low',
//    message: '<p>Select Add Coupon to add one of your available coupons or unfortunately you cant play any more :(</p>',
//    buttons: {
//        Back: {
//            label: "Back to Index!",
//            className: 'btn-info',
//            callback: function() {
                     
//                }
//             },
//            Add: {
//                label: "Add Coupon",
//                className: 'btn-success',
//                callback: function() {
//                    bootbox.prompt("Please enter a coupon so you can play more!!!",
//                        function(result) {
//                            console.log(result);
//                            while (result.lenght <= 5) {
//                                bootbox.prompt("Please enter a  valid coupon so you can play more!!!",
//                                    function(result) {
//                                        if (result <= 5) {
//                                            return;
//                                        }
//                                        var coupon = result;
//                                        console.log(result);
//                                        $("#betAndPlayBtn").attr("href", "#modal - 1");
//                                    });
//                            }

//                        });

//                }
           

//        }
//    }
//});   
