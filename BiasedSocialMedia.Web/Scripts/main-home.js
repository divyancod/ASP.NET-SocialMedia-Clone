$('#btn-submit-post').click(function (e) {
    e.preventDefault();
    var postContent = $('#post-text-area').val();
    console.log(postContent)
    showToast(1,"Sending your post...",0)
    $.ajax({
        url: "/Home/SubmitPost",
        type: "POST",
        //dataType: "json",
        contenttype: 'application/json; charset=utf-8',
        data: { PostContent: postContent },
        success: function (data) {
            $('#all-posts-container').html(data);
            $('#post-text-area').val("");
        }
    })
})

$(window).scroll(function () {
    //if ($(window).scrollTop() >= $(document).height() - $(window).height() - 10) {
    //    console.log('end of page.. call api');
    //}
});

$.ajax({
    url: "/Home/_PostArea",
    type: "POST",
    success: function (data) {
        $('#all-posts-container').html(data);
        //$('#post-text-area').val("");
    }
})

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