$(function () {

    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
    });

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

    $(".quit-game-btn").click(function (event) {
        event.preventDefault();
        $('#game').empty();
    });

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

    // updates the button
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