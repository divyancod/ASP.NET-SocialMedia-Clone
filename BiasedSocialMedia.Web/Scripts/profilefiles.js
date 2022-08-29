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

var originalImage = '';
var changed = false;
$(document).on("click", "#openModalBtn", function (e) {
    originalImage = $('#selected-image').prop('src');
    $('#my-modal').addClass('open');
});
$(document).on("click", "#closeModalBtn", function (e) {
    $('#my-modal').removeClass('open');
});
$("#input-image-upload").change(function () {
    if (this.files) showImage(this.files[0]);
});
function showImage(src) {
    if (src) {
        const reader = new FileReader();
        reader.readAsDataURL(src);
        reader.onload = function () {
            changed = true;
            $("#selected-image").attr("src", this.result);
        };
    }
}
$(".btn-remove-image").click(function (e) {
    changed = false;
    $("#selected-image").attr("src", originalImage);
});
$('.btn-change-photo').click(function (e) {
    if (changed == true) {
        var fileData = new FormData();
        var fileUpload = $("#input-image-upload").get(0);
        var files = fileUpload.files;
        for (var i = 0; i < files.length; i++) {
            fileData.append("files", files[i]);
        }
        $('.my-loader').show();
        $.ajax({
            url: "/Profile/ChangeProfilePhoto",
            type: "POST",
            processData: false,
            contentType: false,
            data: fileData,
            success: function (data) {
                if (data.isSuccess) {
                    $('.my-loader').hide();
                    location.reload();
                }
            }
        })
    }
})