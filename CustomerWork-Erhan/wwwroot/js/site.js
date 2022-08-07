// Sayfa yüklendiğinde
$(document).ready(function () {
//$(function () {
    $('#Country').change(function () {
        $.ajax({
            type: 'GET',
            url: '/Customer/CityGet',
            dataType: 'json',
            data: { countryId: $("#Country").val() },
            success: function (result) {
                $("#City").html('');
                $("#City").append('<option value="' + -1 + '">' + "Seçiniz" + '</option>');

                $.each(result, function (i, item) {
                    $("#City").append('<option value="' + item.id + '">' + item.description + '</option>');
                });
            },
            error: function (ex) {
                alert('hata' + ex);
            }
        });
    });


});