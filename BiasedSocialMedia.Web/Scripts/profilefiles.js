$(document).on("click", "#update-profile-btn", function (e) {
    e.preventDefault();
    console.log("clicked")
    $.ajax({
        url: "/Profile/UpdateProfile",
        type: "Post",
        data: $('form').serialize(),
        success: function (data) {
            location.reload();
        }
    })
});