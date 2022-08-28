$('#btn-submit-post').click(function (e) {
    e.preventDefault();
    var postContent = $('#post-text-area').val();
    if (postContent == '') {
        showToast(1, "Write something to post", 0);
        return;
    }
    showToast(1, "Sending your post...", 0)

    var fileData = new FormData();
    fileData.append("PostContent",postContent);

    var fileUpload = $("#input-post-upload").get(0);
    var files = fileUpload.files;
    for (var i = 0; i < files.length; i++) {
        fileData.append("files", files[i]);
    }

    $.ajax({
        url: "/Home/SubmitPost",
        type: "POST",
        processData: false,
        contentType: false,
        data: fileData,
        success: function (data) {
            $('#all-posts-container').html(data);
            $('#post-text-area').val("");
        }
    })
})

$(document).on("click", ".post-like-btn", function (event) {
    var currentItem = $(this);
    var postId = $(this).data("id");
    $.ajax({
        url: "/Home/LikePost?status=0&postId="+postId,
        type: "GET",
        success: function (data) {
            if (data != null && data != '')
                currentItem.children('p').text(data.counts.LIKE)
        }
    })
});
$(window).scroll(function () {
    if ($(window).scrollTop() + $(window).height() > $(document).height() - 100) {
        if (loading == false && isLoadMore) {
            loading = true;
            $('#posts-loader').show();
            loadMorePosts();
        }
    }
});
var loading = false;
function loadPosts() {
    $.ajax({
        url: "/Home/_PostArea",
        type: "POST",
        success: function (data) {
            $('#all-posts-container').html(data);
            //$('#post-text-area').val("");
        }
    })
}
loadPosts();
var page = 1;
var isLoadMore = true;
function loadMorePosts() {
    $('#posts-loader').show();
    $.ajax({
        url: "/Home/GetPostArea?page=" + page,
        type: "POST",
        success: function (data) {
            if (data == '') {
                $('#posts-loader').remove();
                isLoadMore = false;
                return;
            }
            page = page + 1;
            $('#all-posts-container').append(data);
            loading = false;
            //$('#post-text-area').val("");
        }
    })
}
const showToast = (id, toastMsg, toastType) => {

    d = document.createElement('div');
    $(d).addClass("my-custom-toast toast-" + id);
    h = document.createElement('p');
    $(d).addClass('toast-success');
    $(h).text(toastMsg);
    $(h).appendTo($(d));
    $(d).appendTo('.my-toast-container')
    setTimeout(() => {
        $('.toast-' + id).remove();
    }, 3000)
}

//$(document).ajaxStart(function () {
//    $('.my-loader').show();
//});
//$(document).ajaxStop(function () {
//    $('.my-loader').hide();
//});