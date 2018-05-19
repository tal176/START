
function Feedback() {
    var $ = jQuery.noConflict();
    var uri = 'api/Feedback/CustomerFeedback';
    $.ajax({
        url: uri,
        dataType: 'json',
        data: {
            CompanyName: $("#CompanyName").val(), CustomerName: $("#CustomerName").val(), typeIssue: $("#typeIssue").val(),
            FeedbackDesc: $("#FeedbackDesc").val()
        },
            
        async: false,
        success: function (data) {

            $.each(data, function (key, item) {
                if (item.ErrMsg === "New feedback created") {
                    alert("New feedback created");
                    return true;
                }
            });
        }

    });

}
