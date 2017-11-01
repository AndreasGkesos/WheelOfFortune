function SpinsController_init() {
    $(document).ready(function () {
        var table = $("#Spins").DataTable({
            ajax: {
                
                url: "/api//Spins/GetByUserId",
                dataSrc: ""

            },
            columns: [
                {
                    data: "Id"                  
                },
                {
                    data: "BetValue"
                },
                {
                    data: "ResultValue"
                }
            ]
        });
}