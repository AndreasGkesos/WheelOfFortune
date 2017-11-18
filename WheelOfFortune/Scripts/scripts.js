
function openNav() {
    document.getElementById("mySidenav").style.width = "400px";
    document.getElementById("main").style.marginLeft = "400px";
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
    //load pic from local storage
    var image = JSON.parse(localStorage.getItem("image"));
    $("#imageProfiler").attr("src", "data:image/png;base64," + image).fadeIn();
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
    document.body.style.backgroundColor = "white";
}

$("#depositCodeSubmit").on("click",
    function (event) {
        let $button = $(this);
        console.log($button);
        let $input = $button.prev("input");
        if ($input.val() === "") {
            toastr.error("Please enter a valid coupon");
        
        } else {
            $.ajax({
                type: "GET",
                url: "/api/Coupon/Exchange?code=" + $input.val(),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $($input).val("");
                    if (msg.toString() === "true") {
                        toastr.options.fadeOut = 2500;
                        toastr.success("Great you just turned your deposit code to cash");
                        toastr.success("Do not waste any more time click \n the Bet And Play button and start " +
                            "making some money");
                        $("#betAndPlayBtn").show();
                        let user = $("#betAndPlayBtn").attr("data-userId");
                        UpdateBalanceContainer(user);

                    } else {
                        toastr.error("Wrong code value . Maybe your code has expired or it ts just invalid");

                    }
                },
                fail: function(msg) {
                    toastr.error("Wrong code value.Maybe your code has expired or it ts just invalid");
                }
            });
        }
      
    });

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
            if (balance === 0.00) {
                toastr.warning("Unfortunately you can not play anymore if you dont raise your balance");
                toastr.warning("Consider using one of your coupon to raise your balance");
                $("#betAndPlayBtn").hide();
            }

        },
        fail: function(msg) {
            alert("error in getting the balance");
        }

    });
}