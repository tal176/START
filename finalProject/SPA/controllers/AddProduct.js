
function AddItem() {
    var $ = jQuery.noConflict();
    var uri = 'api/HomePage/AddItem';
    $.ajax({
        url: uri,
        dataType: 'json',
        data: {
            CompanyName: $("#CompanyName").val(), ProductId: $("#ProductId").val(), ProductName: $("#ProductName").val(), Quantity: $("#Quantity").val()
            ,MinStock: $("#MinStock").val(), ManufItemKey: $("#ManufItemKey").val(), CompanyOfTheManufcter: $("#CompanyOfTheManufcter").val()},
        async: false,
        success: function (data)
        {

            $.each(data, function (key, item) {
                if (item.ErrMsg === "Duplication") {
                    alert("item id exist");
                    return false;
                }
                else if (item.ErrMsg === "Item stock can`t be negative") {
                    alert("Item stock can`t be negative");
                    return false;
                }
                else if (item.ErrMsg === "Connection Issue") {
                    alert("Connection Issue");
                    return false;
                }
                else alert("Ok");
            });
        }
        
    });

}
