//Usage

//load your JSON (you could jQuery if you prefer)
function loadJSON(callback) {

    var xobj = new XMLHttpRequest();
    xobj.overrideMimeType("application/json");
    xobj.open('GET', '/api/WheelConfiguration/GetWheelConfiguration', true);
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
    //e is the result object
    console.log('Spin Count: '  + e.spinCount  + ' - ' +  'Win: '   +e.win +  ' - ' +  'Message: '  + e.msg);
    var betValue = 5;
    var resultValue = betValue * e.userData.score;
     
             var spinModelObject =
             {
                         ScoreValue: e.userData.score,
                         BetValue: betValue,
                         ResultValue: resultValue,
                         ExecutionDate: Date.now(),
                         WheelConfigurationId: configId
            }

                var spinObjStringified = JSON.stringify(spinModelObject);
     
         
             $.ajax({
                     type: "POST",
                     url: "/api/Spin/AddSpin",
                     data: spinObjStringified,
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (msg) {
                             alert("everything all right");
                         },
                     fail:function (msg) {
                                 alert("error");
                             }
                 
                     });
    // if you have defined a userData object...
    if (e.userData) {

        console.log('User defined score: '  + e.userData.score);

    }

    //if(e.spinCount == 3){
    //show the game progress when the spinCount is 3
    //console.log(e.target.getGameProgress());
    //restart it if you like
    //e.target.restart();
    //}  

}

//your own function to capture any errors
function myError(e) {
    //e is error object
    console.log('Spin Count: ' +  e.spinCount +  ' - ' +  'Message: ' +  e.msg);

}

function myGameEnd(e) {
    //e is gameResultsArray
    console.log(e);
    TweenMax.delayedCall(5, function () {
        /*location.reload();*/
    })


}

var configId;
function init() {
    loadJSON(function (response) {
        // Parse JSON string to an object
        var jsonData = JSON.parse(response);
        //if you want to spin it using your own button, then create a reference and pass it in as spinTrigger
        var mySpinBtn = document.querySelector('.spinBtn');
        //create a new instance of Spin2Win Wheel and pass in the vars object
        var myWheel = new Spin2WinWheel();

        configId = jsonData.configId;

        //WITH your own button
        myWheel.init({ data: jsonData, onResult: myResult, onGameEnd: myGameEnd, onError: myError, spinTrigger: mySpinBtn });

        //WITHOUT your own button
        //myWheel.init({data:jsonData, onResult:myResult, onGameEnd:myGameEnd, onError:myError);
    });
}



//And finally call it
init();
