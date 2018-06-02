
function AddPurchaseOrder() {
    var $ = jQuery.noConflict();
    var uri = 'api/Purchase/AddPurchaseOrder';
    $.ajax({
        url: uri,
        dataType: 'json',
        data: {
            purhcaseOrderId: $("#purhcaseOrderId").val(), CompanyName: $("#CompanyName").val(), Quantity: $("#Quantity").val(),
            Payment: $("#Payment").val(), ProductName: $("#ProductName").val(), VendorName: $("#VendorName").val(), VendorCountrey: $("#VendorCountrey").val()
            , ShipTo: $("#ShipTo").val(), PhoneContact: $("#PhoneContact").val(), Reason: $("#Reason").val()
        },
        async: false,
        success: function (data) {

            $.each(data, function (key, item) {
                if (item.ErrMsg === "Connection problem") {
                    alert("Connection problem");
                    return false;
                }
                else alert("New purchase order has been created");
            });
        }
       
    });

}
