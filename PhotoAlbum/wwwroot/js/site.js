function GetComments(id) {
    $.ajax({
        url: '/Home/GetPartial',
        type: 'POST',
        cache: false,
        async: true,
        dataType: "html",
        data: id
    })
        .done(function (result) {
            $('#insertComments').html(result);
        }).fail(function (xhr) {
            console.log('error : ' + xhr.status + ' - ' + xhr.statusText + ' - ' + xhr.responseText);
        });
}