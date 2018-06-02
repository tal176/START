
function AddVendor() {
    var $ = jQuery.noConflict();
    var uri = 'api/Vendor/AddVendor';
    $.ajax({
        url: uri,
        dataType: 'json',
        data: {
            VendorName: $("#VendorName").val(), VendorCompany: $("#VendorCompany").val(), VendorCountrey: $("#VendorCountrey").val(),
            VendorType: $("#VendorType").val(), VendorPhone: $("#VendorPhone").val()       
            , VendorMail: $("#VendorMail").val()
        },
        
        async: false,
        success: function (data) {

            $.each(data, function (key, item) {
                if (item.ErrMsg === "Vendor already exist") {
                    alert("Vendor already exist");
                    return false;
                }
                else {
                    alert("All done, new Vendor in stock");
                    return trute;
                }

            });
        }

    });

}
