
viewmodel.onLike = function (LogoId, Liked, LikesNum) {

    Liked(!Liked());

    // ajax for like
    var action = "/Home/Like";
    var data = {
        FromUserId: viewmodel.User.Id(),
        ToLogoId: LogoId(),
        Liked: Liked()
    };
    
    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {
            if (response == "success") {
                if (!Liked()) {
                    LikesNum(LikesNum() - 1);
                } else {
                    LikesNum(LikesNum() + 1);
                }
            } else {
                Liked(!Liked());
            }
        }
    });
};

viewmodel.onLogoClick = function (LogoId, Liked, LikesNum, CommentsNum) {
 
    // ajax for logo details
    var action = "/Home/LogoDetails";
    var data = "logoId=" + LogoId();

    $.ajax({
        type: "GET",
        url: action,
        data: data,
        success: function (data) {

            viewmodel.LogoDetails.LogoId(data.LogoId);
            viewmodel.LogoDetails.LogoURL(data.LogoURL);
            viewmodel.LogoDetails.Username(data.Username);
            viewmodel.LogoDetails.AccountPhotoURL(data.AccountPhotoURL);
            viewmodel.LogoDetails.AccountURL(data.AccountURL);
            viewmodel.LogoDetails.Title(data.Title);
            viewmodel.LogoDetails.Description(data.Description);
            viewmodel.LogoDetails.UploadDate(data.UploadDate);
            viewmodel.LogoDetails.LikesNum(data.LikesNum);
            viewmodel.LogoDetails.CommentsNum(data.CommentsNum);
            viewmodel.LogoDetails.Liked(data.Liked);
            viewmodel.LogoDetails.Comments(ko.mapping.fromJS(data.Comments)());
            viewmodel.LogoDetails.ErrorText("");
            viewmodel.LogoDetails.ShowError(false);
            viewmodel.LogoDetails.Content("");

            // don't update values from cards with ko.observable.subscribe method, 
            // because for one observable you can have more differents subscribe functions in same time
            Liked(data.Liked);
            LikesNum(data.LikesNum);
            CommentsNum(data.CommentsNum);
            viewmodel.LogoDetails.CardLiked = Liked;
            viewmodel.LogoDetails.CardLikesNum = LikesNum;
            viewmodel.LogoDetails.CardCommentsNum = CommentsNum;

            $('#modal-show-logo').modal('show');

        }
    });

};

viewmodel.onFlatBtnClick = function () {
    
    viewmodel.UploadLogo.LogoData("");
    viewmodel.UploadLogo.Title("");
    viewmodel.UploadLogo.Description("");
    viewmodel.UploadLogo.ShowError(false);
    viewmodel.UploadLogo.ErrorText("");

    $('#upload-logo').get(0).value = "";
    $('#uploaded-logo').attr('src', '/Images/upload-image.png')

    $('#modal-add-logo').modal('show');
};