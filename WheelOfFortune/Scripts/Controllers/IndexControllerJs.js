var balance=0;
var imagedata;
function IndexController_init(config) {
  
    const userId = config.userId;
    UpdateBalanceContainer(userId);

    GetUserPhoto(userId);
    

   
    /* $(document).on("click", "#betValueSubmit", function () {
         alert("sfdsadf");
         var inputField = $("#BetValue");
         console.log("inputField  :" + inputField.html());
         if (!CheckBetInput(inputField)) {
             console.log("mphke sto lathos");
             $(this).attr("href", "#");
         }
         $(this).attr("href", "#modal - 1");
         window.location.replace("#modal - 1");
 
     });*/

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
        console.log(data);
        if ((data === null) || (data === undefined) || (data.length <= 0)) {
            $("#imageProfiler").attr("src", "../../Content/img/userPhotoImageFail.png").fadeIn();
        }
        localStorage.setItem("image", JSON.stringify(data));

        $("#imageProfiler").attr("src", "data:image/png;base64,"+ data).fadeIn();
    });


}