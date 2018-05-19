
function AddOrder() {
    var $ = jQuery.noConflict();
    var uri = 'api/Customer/CusotmerOrder';
    $.ajax({
        url: uri,
        dataType: 'json',
        data: {
            OrderId: $("#OrderId").val(), CompanyName: $("#CompanyName").val(),Quantity: $("#Quantity").val()
            , ProductName: $("#ProductName").val(), CustomerName: $("#CustomerName").val(), ShipTo: $("#ShipTo").val(),    
            PhoneContact: $("#PhoneContact").val(), SupposedToArrive: $("#SupposedToArrive").val()
        },
        async: false,
        success: function (data) {

            $.each(data, function (key, item) {
                if (item.ErrMsg === "Stock is not aviable") {
                    alert("Stock is not aviable");
                    return false;
                }
                else if (item.ErrMsg === "Not enoght quantity") {
                    alert("Not enoght quantity");
                    return false;
                }
                else alert("New order complite");
            });
        }

    });

}
