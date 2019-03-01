
viewmodel.EditBtn = ko.observable(false);
viewmodel.FollowingBtn = ko.observable(false);
viewmodel.NotFollowingBtn = ko.observable(false);
viewmodel.FollowingText = ko.observable("Following");

if (viewmodel.Follow() === 0) {
    viewmodel.EditBtn(true);
} else if (viewmodel.Follow() === 1) {
    viewmodel.FollowingBtn(true);
} else if (viewmodel.Follow() === 2) {
    viewmodel.NotFollowingBtn(true);
}

viewmodel.ChangeText = function () {
    if (viewmodel.FollowingText() == "Following") {
        viewmodel.FollowingText("Unfollow");
    } else {
        viewmodel.FollowingText("Following");
    }
};
viewmodel.ClickFollowingBtn = function () {
    var action = "/Profile/Unfollow";
    var data = {
        FromUserId: viewmodel.User.Id(),
        ToUserId: viewmodel.UserProfileId(),
    };

    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {
            if (response == "success") {
                viewmodel.FollowingBtn(false);
                viewmodel.NotFollowingBtn(true);
                viewmodel.FollowersNum(viewmodel.FollowersNum() - 1);
            } else {

            }
        }
    });
};
viewmodel.ClickEditBtn = function () {
    location.href = "/Profile/Edit";
};
viewmodel.ClickNotFollowingBtn = function () {
    var action = "/Profile/Follow";
    var data = {
        FromUserId: viewmodel.User.Id(),
        ToUserId: viewmodel.UserProfileId(),
    };

    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {
            if (response == "success") {
                viewmodel.FollowingBtn(true);
                viewmodel.NotFollowingBtn(false);
                viewmodel.FollowersNum(viewmodel.FollowersNum() + 1);
            } else {

            }
        }
    });
};
