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
    $(".quit-game-btn").click(function (event) {
        event.preventDefault();
        $('#game').empty();
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