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
});