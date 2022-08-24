$(".toggle-password").click(function () {
    $(this).toggleClass("fa-eye fa-eye-slash");

    var input = $($(this).attr("toggle"));

    if (input.attr("type") == "password") {
        input.attr("type", "text");
    } else {
        input.attr("type", "password");
    }
});
$('#signUpBtn').click(function (e) {
    e.preventDefault();
    var email = $('#email-field').val();
    var pass = $('#password-field').val();
    var repass = $('#re-password-field').val();
    console.log(repass == '')
    if (email == '') {
        $('#error-message').text("Email address can't be empty.");
    } else if (pass != repass) {
        $('#error-message').text("Password and Re-Password don't match");
    } else if (pass == '' || repass == '') {
        $('#error-message').text("Password and Re-Password can't be empty.");
    }
    else {
        $('#SignUpForm').submit();
    }
})
var timer;
var isUserNameValid = false;
$('#username-field').on("input", function () {
    $('#username-loading').show();
    $('#username-valid').hide();
    $('#username-invalid').hide();
    $('.my-loader').show();
    isUserNameValid = false;
    clearTimeout(timer);
    timer = setTimeout(() => {
        var username = $('#username-field').val();
        $.ajax({
            url: "/Login/CheckUserName?username=" + username,
            success: function (data) {
                $('.my-loader').hide();
                $('#username-loading').hide();
                isUserNameValid = data.isSuccess;
                if (data.isSuccess == true) {
                    $('#username-valid').show();
                    $('#username-invalid').hide();
                } else {
                    $('#username-invalid').show();
                    $('#username-valid').hide();
                }
            }
        });

    }, 1000);
});
$('#nextstep-btn').click(function (e) {
    e.preventDefault();
    var isChecked = $("#checkboxTerms").is(":checked");
    if (!isUserNameValid) {
        $('#nextstep-error-message').text('Kindly choose unique username')
        return;
    }
    if (isChecked) {
        $('#nextstep-error-message').hide();
        $('#next-step-form').submit();
    } else {
        $('#nextstep-error-message').text('Kindly accept terms and conditions')
    }
})
var userUploadedImage = false;
var preDefinedSelectedImageId = "0";

$(".step-profile-photo").click(function (e) {
    preDefinedSelectedImageId = $(this).data("id");
    $(".step-profile-photo").removeClass("selected");
    $(this).addClass("selected");
});

$("#input-image-upload").change(function () {
    if (this.files) showImage(this.files[0]);
});

function showImage(src) {
    if (src) {
        const reader = new FileReader();
        reader.readAsDataURL(src);
        reader.onload = function () {
            $(".user-selection").show();
            $(".avatar-selection").hide();
            $("#selected-image").attr("src", this.result);
            userUploadedImage = true;
            preDefinedSelectedImageId = "0";
        };
    }
}
$(".btn-remove-image").click(function (e) {
    userUploadedImage = false;
    $(".user-selection").hide();
    $(".avatar-selection").show();
    $("#selected-image").attr("src", "");
    $("#input-image-upload").val("");
});
$(".btn-upload-image").click(function (e) {
    e.preventDefault();
    $("#error-message").text("");
    var fileData = new FormData();
    var userid = $('#user-id-hidden').val();
    if (preDefinedSelectedImageId == "0" && userUploadedImage == false) {
        $("#error-message").text("Please select or upload photo.");
        return;
    } else if (preDefinedSelectedImageId != '' && userUploadedImage == false) {
        fileData = { id: preDefinedSelectedImageId }
    } else if (preDefinedSelectedImageId == '0' && userUploadedImage == true) {
        var fileUpload = $("#input-image-upload").get(0);
        var files = fileUpload.files;
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
    }
    $('.my-loader').show();
    $.ajax({
        url: "/Login/UploadProfilePhoto?imageId=" + preDefinedSelectedImageId + "&userid=" + userid,
        type: "POST",
        processData: false,
        contentType: false,
        data: fileData,
        success: function (data) {
            if (data.isSuccess) {
                $('.my-loader').hide();
                window.location = "/Home/Index"
            }
        }
    })
});