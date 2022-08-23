$('#btn-submit-post').click(function (e) {
    e.preventDefault();
    var postContent = $('#post-text-area').val();
    console.log(postContent)
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

