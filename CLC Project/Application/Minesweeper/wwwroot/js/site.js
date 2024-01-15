$(function () {
    
    // prevent righ-click context menu
    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
    });

    // loads a new game in the dashboard
    $(".game-start-button").click(function (event) {
        event.preventDefault();

        $.ajax({
            datatype: 'html',
            method: 'POST',
            url: '/Game/',
            // data: 0, pass difficulty data here?
            success: function (data) {
                console.log(data);
                $('#game').html(data);
            }
        });
    });

    // closes an open game
    //$(".quit-game-btn").click(function (event) {
    //    console.log('Button clicked!');
    //    event.preventDefault();
    //    $('#game').empty();
    //});
    $(document).on("click", ".quit-game-btn", function (event) {
        event.preventDefault();
        $('#game').empty();
    });

    // //saves the current game 
    //$(document).on("click", ".save-game-btn", function (event) {
    //    event.preventDefault();
    //    console.log('Save button clicked');
    //    // Collect game board data
    //    var gameBoardData = collectGameBoardData();

    //    // Your AJAX request to save the game
    //    $.ajax({
    //        datatype: 'json', // Change to 'json'
    //        contentType: 'application/json', // Set content type to JSON
    //        method: 'POST',
    //        url: '/Game/SaveGame',
    //        data: JSON.stringify(gameBoardData), // Convert the data to JSON string
    //        success: function (data) {
    //            console.log('Game Saved');
    //            console.log(data);
    //            // Handle the response as needed
    //        }
    //    });
    //});


    // handle left/right/center mouse clicks
    $(document).on("mousedown", ".game-button", function (event) {
        var cellRow = $(this).closest("form").find('input[name="row"]').val();
        var cellCol = $(this).closest("form").find('input[name="col"]').val();
        switch (event.which) {
            case 1: // left click
                event.preventDefault();
                doCellUpdate(cellRow, cellCol, "/game/HandleLeftClick");
                break;
            case 2: // middle click
                break;
            case 3: // right click
                event.preventDefault();
                doCellUpdate(cellRow, cellCol, "/game/HandleRightClick");
                break;
            default: console.log("mouse click was not left, center, or right!");
        }
    });

    // update the specified cell
    function doCellUpdate(row, col, urlString) {

        $.ajax({
            datatype: 'html',
            method: 'POST',
            url: urlString,
            data: {
                "row": row,
                "col": col
            },
            success: function (data) {
                $("#gameBoardContainer").html(data);
            }
        });
    };
   
    
});