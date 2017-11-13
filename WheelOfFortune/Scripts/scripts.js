
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
                success: function (msg) {
                    alert("msg" + msg);
                    $($input).val("");
                    if (msg === "true") {
                        toastr.success("Great you just turned your coupon to cash");
                        toastr.success("Do not waste ay more time click the Bet And PLay button and start" +
                            "making some money");
                    }
                    toastr.error("Wrong coupon value.Maybe your coupon has expired or it ts just invalid");
                },
                fail: function (msg) {
                    toastr.error("Wrong coupon value.Maybe your coupon has expired or it ts just invalid");
                }
            })
        }
      
    });

    

 