$(function () {
    console.log("Page is ready");


$(document).bind("contextmenu", function (e) {
    e.preventDefault();
    console.log("Right Click, Prevent context menu from showing.");
});

    $(document).on("mousedown", ".game-button", function (event) {
        var row = $(this).closest("form").find('input[name="row"]').val();
        var col = $(this).closest("form").find('input[name="col"]').val();

        console.log("Clicked button at row:", row, "col:", col);
    switch (event.which) {
        case 1:
            //handles left clicks
            event.preventDefault();

            doButtonUpdate(row, col, "/game/HandleLeftClick");
            break;
        case 2:
            alert('Middle mouse button is pressed');
            break;
        case 3:
            // handles right clicks
            event.preventDefault();

            doButtonUpdate(row, col, "/game/HandleRightClick");
            break;
        default:
            alert('Nothing');
    }
});





// updates the button
function doButtonUpdate(row, col, urlString) {

    $.ajax({
        datatype: "html",
        method: "POST",
        url: urlString,
        data: {
            "row": row, 
            "col": col 

        },
        success: function (data) {
            //console.log(data);
            //console.log("Updating button at row:", gameBoard.row, "col:", gameBoard.col);
            $("#gameBoardContainer").html(data);

            

        }

    });
    };
});