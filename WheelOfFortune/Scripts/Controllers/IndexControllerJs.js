function IndexController_init(config) {

    const userId = config.userId;
    UpdateBalanceContainer(userId);


}


function UpdateBalanceContainer(user) {

    $.ajax({
        type: "GET",
        url: "/api/Balance/GetBalance/",
        data: { userId: user },
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

