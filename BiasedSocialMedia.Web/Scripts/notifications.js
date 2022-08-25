var page = 0;
var loading = true;
var isLoadMore = true;

$(window).scroll(function () {
    if ($(window).scrollTop() + $(window).height() > $(document).height() - 100) {
        if (loading == false && isLoadMore == true) {
            loading = true;
            loadNotifications();
        }
    }
});
function loadNotifications() {
    $('#notification-loader').show();
    $.ajax({
        url: "/Home/GetNotifications?page="+page,
        type: "GET",
        success: function (data) {
            if (data == '') {
                $('#notification-loader').remove();
                isLoadMore = false;
                return;
            }
            if (page == 0) {
                $('#all-notification-cards').html(data);
                page = page + 1;
                loading = false;
            } else {
                page = page + 1;
                $('#all-notification-cards').append(data)
                loading = false;
            }
        }
    })
}
loadNotifications();

//function loadMorePosts() {
//    $.ajax({
//        url: "/Home/GetPostArea?page=" + page,
//        type: "POST",
//        success: function (data) {
//            if (data == '') {
//                $('#posts-loader').remove();
//                isLoadMore = false;
//                return;
//            }
//            page = page + 1;
//            $('#all-posts-container').append(data);
//            loading = false;
//            //$('#post-text-area').val("");
//        }
//    })
//}