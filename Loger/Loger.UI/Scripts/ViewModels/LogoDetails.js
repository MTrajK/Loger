
viewmodel.LogoDetails = {};
viewmodel.LogoDetails.LogoId = ko.observable(0);
viewmodel.LogoDetails.LogoURL = ko.observable("");
viewmodel.LogoDetails.Username = ko.observable("");
viewmodel.LogoDetails.AccountPhotoURL = ko.observable("");
viewmodel.LogoDetails.AccountURL = ko.observable("");
viewmodel.LogoDetails.Title = ko.observable("");
viewmodel.LogoDetails.Description = ko.observable("");
viewmodel.LogoDetails.UploadDate = ko.observable("");
viewmodel.LogoDetails.LikesNum = ko.observable(0);
viewmodel.LogoDetails.CommentsNum = ko.observable(0);
viewmodel.LogoDetails.Liked = ko.observable(false);
viewmodel.LogoDetails.Comments = ko.observableArray();
viewmodel.LogoDetails.ShowError = ko.observable(false);
viewmodel.LogoDetails.ErrorText = ko.observable("");
viewmodel.LogoDetails.Content = ko.observable("");
viewmodel.LogoDetails.CardLiked = ko.observable();
viewmodel.LogoDetails.CardLikesNum = ko.observable();
viewmodel.LogoDetails.CardCommentsNum = ko.observable();
viewmodel.LogoDetails.CommentLogo = function () {

    if (viewmodel.LogoDetails.Content() == "") {
        viewmodel.LogoDetails.ShowError(true);
        viewmodel.LogoDetails.ErrorText("Field can not be empty!");
        return;
    }
    viewmodel.LogoDetails.ShowError(false);

    var action = "/Home/Comment";
    var data = {
        FromUserId: viewmodel.User.Id(),
        ToLogoId: viewmodel.LogoDetails.LogoId(),
        Content: viewmodel.LogoDetails.Content()
    };

    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {
            if (response == "success") {

                viewmodel.LogoDetails.Comments.push({
                    LogoId: ko.observable(viewmodel.LogoDetails.LogoId()),
                    Username: ko.observable(viewmodel.User.Username()),
                    AccountPhotoURL: ko.observable(viewmodel.User.AccountPhotoURL()),
                    AccountURL: ko.observable(viewmodel.User.AccountURL()),
                    Content: ko.observable(viewmodel.LogoDetails.Content())
                });
                viewmodel.LogoDetails.Content("");
                // update values from logo details and card
                viewmodel.LogoDetails.CommentsNum(viewmodel.LogoDetails.CommentsNum() + 1);
                viewmodel.LogoDetails.CardCommentsNum(viewmodel.LogoDetails.CommentsNum())
            } else {
                viewmodel.LogoDetails.ShowError(true);
                viewmodel.LogoDetails.ErrorText("Comment was not posted!");
            }
        }
    });
};
viewmodel.LogoDetails.LikeLogo = function () {

    var action = "/Home/Like";
    var data = {
        FromUserId: viewmodel.User.Id(),
        ToLogoId: viewmodel.LogoDetails.LogoId(),
        Liked: !viewmodel.LogoDetails.Liked()
    };

    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {
            if (response == "success") {
                // update values from logo details and card
                viewmodel.LogoDetails.Liked(!viewmodel.LogoDetails.Liked());
                viewmodel.LogoDetails.CardLiked(viewmodel.LogoDetails.Liked());

                if (!viewmodel.LogoDetails.Liked()) {
                    viewmodel.LogoDetails.LikesNum(viewmodel.LogoDetails.LikesNum() - 1);
                } else {
                    viewmodel.LogoDetails.LikesNum(viewmodel.LogoDetails.LikesNum() + 1);
                }
                viewmodel.LogoDetails.CardLikesNum(viewmodel.LogoDetails.LikesNum());
            }
        }
    });
};

