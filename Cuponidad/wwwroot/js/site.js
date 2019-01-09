
AjaxGet: function AjaxGet(pUrl, pData, rSucess, rFail, rError) {
    return $.ajax({
        url: pUrl,
        data: pData,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (rSucess != null)
                rSucess(data);
        },
        error: function (data) {
            if (data.status == 400) {
                if (rFail == null)
                    if (data.responseJSON.ErrorMessage) alert(data.responseJSON.ErrorMessage);
                if (data.responseText) alert(data.responseText);
                else
                    rFail(data);
            }
            else if (data.status == 405) {
                if (rError == null)
                    if (data.responseJSON.ErrorMessage) alert(data.responseJSON.ErrorMessage);
                if (data.responseText) alert(data.responseText);
                else
                    rError(data);
            }
            else
                alert("Invalid Response");
        }

    })
}
