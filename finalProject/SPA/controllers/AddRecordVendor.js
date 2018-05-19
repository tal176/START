
function AddRecordVendor() {
    var $ = jQuery.noConflict();
    var uri = 'api/Vendor/AddRecordVendor';
    $.ajax({
        url: uri,
        dataType: 'json',
        data: {
            VendorName: $("#VendorName").val(), VendorCountrey: $("#VendorCountrey").val(),
            VendorType: $("#VendorType").val(), VendorPhone: $("#CustomerRating").val()
        },

        async: false,
        success: function (data) {

            $.each(data, function (key, item) {
                if (item.ErrMsg === "Vendor record can`t be negative") {
                    alert("Vendor record can`t be negative");
                    return false;
                }
                else {
                    alert("All done, new record for vendor");
                    return trute;
                }

            });
        }

    });

}
