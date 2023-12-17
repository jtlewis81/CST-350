$(function () {
    console.log("Page is Ready");

    // this function call on the radio buttons makes the sumbit button pointless
    $(".customerRadio").change(function () {
        console.log("customer radio button selected");
        doCustomerUpdate();
    });

    $("#selectCustomer").click(function (event) {
        event.preventDefault();
        console.log("select customer button clicked");
        doCustomerUpdate();
    });

    function doCustomerUpdate() {
        $.ajax({
            datatype: "text/plain",
            url: "customer/ShowOnePerson",
            data: $("form").serialize(),
            success: function (data) {
                console.log(data);
                $("#customerInfoArea").html(data);
            }
        });
    };

});
