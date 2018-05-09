//function Register() {
//    var $ = jQuery.noConflict();
//    var uri = 'api/HomePage/Register';
//    $.ajax({
//        url: uri,
//        dataType: 'json',
//        data: { NameContact: $("#txtNickName").val(), UserName: $("#txtPassword").val(), Company: $("#txtPassword").val(), Pass: $("#txtPassword").val(), Email: $("#txtPassword").val(), Location: $("#txtPassword").val(), Phone: $("#txtPassword").val() },
//        async: false,
//        success: function (data) {
            
//            $.each(data, function (key, item)
//            {
//                if (item.ErrMsg != "OK") {
//                    alert("Registration Error");
//                }
//                return false; //get out of the loop
//            });
            
//        }
//    });
//}