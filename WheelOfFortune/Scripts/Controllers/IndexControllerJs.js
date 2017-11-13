var balance=0;
var imagedata;
var userId;

function IndexController_init(config) {
  
     userId = config.userId;


    UpdateBalanceContainer(userId);
    InitialListeners();
    GetUserPhoto(userId);
    

    var slider = document.getElementById("BetValue");
    var output = document.getElementById("bet");
    output.innerHTML = slider.value;

    slider.oninput = function() {
        output.innerHTML = this.value;
    }


    $('#betAndPlayBtn').on('click', function (event) {
        if (balance === 100) {
            toastr.warning("Wheel OF fortune offers you 100$ as  a beginner gift.Have Fun");
        }
        if (balance <= 50) {
            dialog.init();
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

function CheckBetInput(event) {
        let $buttonClicked = $(event.target);
        let $inputValue = $buttonClicked.text();




   
    if ($inputValue.length === 0) {//0
        alert("Please enter a bet Value so you can play");
        return false;
    } else if (/^[0-9,.]*$/.test($inputValue)) {//1
        alert("You didnt enter valid input");
        return false;
    } else if ($inputValue > balance) {//2
        alert("You cant enter bet larger than your current balance");
        return false;
    }

    return true;
 }
    
  //0 user didnt enter anything
  //1 user didnt provide a valid input to bet
  //2 user didnt enter bet smaller than his/her current balance


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

        function checkBetInput($inputElem) {
            let $inputValue = $inputElem.text();
            console.log($inputElem);
            console.log("its inside");
            if ($inputValue.length === 0) {//0
                alert("Please enter a bet Value so you can play");
                return false;
            } else if (/^[0-9,.]*$/.test($inputValue)) {//1
                alert("You didnt enter valid input");
                return false;
            } else if ($inputValue > balance) {//2
                alert("You cant enter bet larger than your current balance");
                return false;
            }

            return true;
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
var dialog = bootbox.dialog({
    title: 'Oops your current balance is too low',
    message: '<p>Select Add Coupon to add one of your available coupons or unfortunately you cant play any more :(</p>',
    buttons: {
        Back: {
            label: "Back to Index!",
            className: 'btn-info',
            callback: function() {
                     
                }
             },
            Add: {
                label: "Add Coupon",
                className: 'btn-success',
                callback: function() {
                    bootbox.prompt("Please enter a coupon so you can play more!!!",
                        function(result) {
                            console.log(result);
                            while (result.lenght <= 5) {
                                bootbox.prompt("Please enter a  valid coupon so you can play more!!!",
                                    function(result) {
                                        if (result <= 5) {
                                            return;
                                        }
                                        var coupon = result;
                                        console.log(result);
                                        $("#betAndPlayBtn").attr("href", "#modal - 1");
                                    });
                            }

                        });

                }
           

        }
    }
});   
