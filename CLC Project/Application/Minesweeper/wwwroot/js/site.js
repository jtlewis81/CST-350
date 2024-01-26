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

    // open saved games in partial view
    $(".game-saves-button").click(function (event) {
        event.preventDefault();

        $.ajax({
            datatype: 'html',
            method: 'POST',
            url: '/Game/SavedGames',

            success: function (data) {
                console.log(data);
                $('#game').html(data);
            }
        });
    });

    // delete game button

    $(document).on("click", ".game-delete-button", function (event) {
        event.preventDefault();
        var id = $(this).data("game-id");
        console.log('gameId:', id);

        $.ajax({
            url: '/Game/DeleteGame', // Update the URL to include the gameId
            type: 'DELETE',
            data: { gameId: id},
            success: function (data) {
                console.log('Game deleted successfully.');
                $('#game').html(data);
            },
            error: function (error) {
                console.error('Error deleting game:', error);
            }
        });
    });

    // Load game button

    $(document).on("click", ".game-load-button", function (event) {
        event.preventDefault();
        var id = $(this).data("game-id");
        console.log('gameId:', id);

        $.ajax({
            url: '/Game/LoadGame/', // Add a trailing slash here
            type: 'GET',
            data: { gameId: id },
            success: function (data) {
                console.log('Game loaded successfully.');
                $('#game').html(data);
                doCellUpdate(-1, -1, "/game/HandleLeftClick");
            },
            error: function (error) {
                console.error('Error loading game:', error);
            }
        });
    });

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