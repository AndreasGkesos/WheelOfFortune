//Usage

//load your JSON (you could jQuery if you prefer)
function loadJSON(callback) {

    const xobj = new XMLHttpRequest();
    xobj.overrideMimeType("application/json");
    xobj.open("GET", "/api/WheelConfiguration/GetWheelConfiguration", true);
    //xobj.open("GET", "/WheelContent/wheel_data.json", true);
    xobj.onreadystatechange = function () {
        if (xobj.readyState == 4 && xobj.status == "200") {
            //Call the anonymous function (callback) passing in the response
            callback(xobj.responseText);
        }
    };
    xobj.send(null);
}

//your own function to capture the spin results
function myResult(e) {
    let resultValue = 0;
    let betValue = $("#BetValue").val();

    alert(betValue);

    alert("bet value" + betValue);

    $(".modal-close").removeClass('disable');
 
    resultValue = betValue * e.userData.score;

        let spinModelObject = {
            ScoreValue: e.userData.score,
            BetValue: betValue,
            ResultValue: resultValue,
            ExecutionDate: Date.now(),
            WheelConfigurationId: configId
        };

        let spinObjStringified = JSON.stringify(spinModelObject);

    $.when(
        $.ajax({
            type: "POST",
            url: "/api/Spins/AddSpin",
            data: spinObjStringified,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
            alert("everything all right");
        },
        fail: function(msg) {
            alert("error");
        }
    })
).done(function (x) {
    $.ajax({
        type: "GET",
        url: "/api/Balance/GetBalance?userId=" + window.userId.toString(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#balanceValue").hide(250).show(250);
            $("#balanceValue").text(msg);
            console.log(msg);

        },
        fail: function (msg) {
            alert("error in getting the balance");
        }

    });
    });
 
        

       


   

    }
    
   
   
    // if you have defined a userData object...
  


//your own function to capture any errors
function myError(e) {
    //e is error object
    console.log('Spin Count: ' +  e.spinCount +  ' - ' +  'Message: ' +  e.msg);

}

function myGameEnd(e) {
    //e is gameResultsArray
    console.log(e);
    TweenMax.delayedCall(5,
        function() {
            /*location.reload();*/
        });


}

let configId;
function init() {
   
        loadJSON(function (response) {
            // Parse JSON string to an object
            let jsonData = JSON.parse(response);
            //if you want to spin it using your own button, then create a reference and pass it in as spinTrigger
            let mySpinBtn = document.querySelector(".spinBtn");
            //create a new instance of Spin2Win Wheel and pass in the lets object
            let myWheel = new Spin2WinWheel();

            configId = jsonData.configId;

            //WITH your own button
            myWheel.init({ data: jsonData, onResult: myResult, onGameEnd: myGameEnd, onError: myError, spinTrigger: mySpinBtn });

         
        });
    }
    




//And finally call it


    init();


