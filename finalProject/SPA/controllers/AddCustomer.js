
function AddCustomer() {
    var $ = jQuery.noConflict();
    var uri = 'api/Customer/AddCustomer';
    $.ajax({
        url: uri,
        dataType: 'json',
        data: {
            CompanyName: $("#CompanyName").val(),CustomerName: $("#CustomerName").val(),
            StreetAdress: $("#StreetAdress").val(),City: $("#City").val()
            ,Phonework: $("#Phonework").val(),Email: $("#Email").val()
            
        },
        async: false,
        success: function (data) {

            $.each(data, function (key, item) {
                if (item.ErrMsg === "Customer already exist") {
                    alert("Customer already exist");
                    return false;
                }
                else alert("All done, new customer created");
                    return true;
                }
                
            );
        }

    });

}
