$(function () {
    console.log("Page is Ready");

    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
        console.log("context menu hidden on right click!");
    });

    //$(document).on("click", ".game-button", function (event) {
    //    event.preventDefault();

    //    var buttonNumber = $(this).val();
    //    console.log("button " + buttonNumber + " clicked");
    //    doButtonUpdate(buttonNumber);
    //});

    $(document).on("mousedown", ".game-button", function (event) {
        switch (event.which) {
            case 1:
                //alert('left click');
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("button " + buttonNumber + " left clicked");
                doButtonUpdate(buttonNumber, "/button/ShowOneButton");
                break;
            case 2:
                alert('middle click');
                break;
            case 3:
                //alert('right click');
                event.preventDefault();

                var buttonNumber = $(this).val();
                console.log("button " + buttonNumber + " right clicked");
                doButtonUpdate(buttonNumber, "/button/RightClickShowOneButton");
                break;
            default:
                alert('not a click');
        }
    });


});

function doButtonUpdate(buttonNumber, urlString) {
    $.ajax({
        datatype: "json",
        method: 'POST',
        url: urlString,
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