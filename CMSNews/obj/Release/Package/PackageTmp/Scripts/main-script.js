function showPreview(input) {
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function(e) {
            $('#impPrev').attr('src', e.target.result);
        }
        ImageDir.readAsDataURL(input.files[0]);
    }
}



function changeLikeState(state, newsId) {
    $.ajax({
        url: "/Newses/ChangeLikeState",
        type: "GET",
        data: { newsId: newsId, state: state },
        success: function (res) {
            $("#showLike_" + newsId).html(res);
        },
        error: function () {
            alert("Error");
        }

    });
}