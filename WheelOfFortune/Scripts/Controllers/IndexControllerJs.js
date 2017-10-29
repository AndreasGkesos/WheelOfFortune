function IndexController_init() {


    UpdateBalanceContainer();


}


function UpdateBalanceContainer() {
    let userId = $("#balanceValueContainer").attr("data-userId");

    $.ajax({
        type: "GET",
        url: "/api/Balance/GetBalance/",
        data: { userId: userId },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#balanceValueContainer").hide(250).show(250);
            $("#balanceValueContainer").text(msg);
        },
        fail: function (msg) {
            alert("error in getting the balance");
        }

    });
}

