$(document).ready(function () {
    $('.remove').click(function () {
        let user = $(this).closest('.user');
        let userId = user.data('id');
        let url = urls.removeUser + '?id=' + userId;

        $.get(url).done(function (ansFromServer) {
            if (ansFromServer) {
                user.remove();
            }
        });
    });

    $('#generate').click(function() {
        $('#showMod').modal();
        $('#goodMessage').hide();
        $('#notGoodMessage').hide();
    });

    $('#saveForm').click(function() {
        let data = $('#create').serialize();

        let name = $('#userName').val();
        let birth = $('#birth').val();
        let age = $('#age').val();

        if (name == "" || birth == "" || age == "") {
            $('#notGoodMessage').show();
            $('#goodMessage').hide();
            return false;
        }

        $.ajax({
            type: "post",
            data: data,
            url: "/User/Generate",
            success: function (result) {
                console.log(result);
                $('#goodMessage').show();
                $('#notGoodMessage').hide();
                $('#create')[0].reset();
            }
        });
    });
});