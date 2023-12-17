$(function () {
    console.log("Page is Ready");

    $(document).on("click", ".game-button", function (event) {
        event.preventDefault();

        var buttonNumber = $(this).val();
        console.log("button " + buttonNumber + " clicked");
        doButtonUpdate(buttonNumber);
    });

});

function doButtonUpdate(buttonNumber) {
    $.ajax({
        datatype: "json",
        method: 'POST',
        url: "/button/showOneButton",
        data: {
            "buttonNumber": buttonNumber
        },
        success: function (data) {
            console.log(data);
            $("#" + buttonNumber).html(data);
            checkForMatch();      
        }
    });
};

function checkForMatch() {
    var gameWon = true;
    var state = $(".game-button:first").data("state");
    $(".game-button").each(function () {
        if ($(this).data("state") !== state) {
            gameWon = false;
        }
    });

    if (gameWon === true) {
        $("#gameMessage").html("Congrats! You Win!");
    }
    else {
        $("#gameMessage").html("Try to match all the buttons!");
    }

};