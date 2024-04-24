$("body").on('click', '.toggle-password', function () {
    $(this).toggleClass("fa-eye fa-eye-slash");
    var input = $("#pass_log_id");
    if (input.attr("type") === "password") {
        input.attr("type", "text");
    } else {
        input.attr("type", "password");
    }

});

$("body").on('click', '.toggle-password2', function () {
    $(this).toggleClass("fa-eye2 fa-eye-slash2");
    var input = $("#pass_log_id2");
    if (input.attr("type") === "password") {
        input.attr("type", "text");
    } else {
        input.attr("type", "password");
    }

});