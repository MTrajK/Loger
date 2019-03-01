
viewmodel.UploadLogo = {};
viewmodel.UploadLogo.LogoURL = ko.observable("/Images/upload-image.png");
viewmodel.UploadLogo.LogoData = ko.observable("");
viewmodel.UploadLogo.Title = ko.observable("");
viewmodel.UploadLogo.Description = ko.observable("");
viewmodel.UploadLogo.ErrorText = ko.observable("");
viewmodel.UploadLogo.ShowError = ko.observable(false);
viewmodel.UploadLogo.ShareLogo = function () {

    if (viewmodel.UploadLogo.LogoData() == "") {
        viewmodel.UploadLogo.ErrorText("Must choose some logo!");
        viewmodel.UploadLogo.ShowError(true);
        return;
    }

    if (viewmodel.UploadLogo.Title() == "") {
        viewmodel.UploadLogo.ErrorText("Logo must have a title!");
        viewmodel.UploadLogo.ShowError(true);
        return;
    }

    if (viewmodel.UploadLogo.Description() == "") {
        viewmodel.UploadLogo.ErrorText("Logo must have a description!");
        viewmodel.UploadLogo.ShowError(true);
        return;
    }

    var action = "/Home/UploadLogo";
    var data = {
        UserId: viewmodel.User.Id(),
        LogoData: viewmodel.UploadLogo.LogoData(),
        Title: viewmodel.UploadLogo.Title(),
        Description: viewmodel.UploadLogo.Description()
    };

    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {

            if (response == "success") {
                // if current view is Home/Index or profile of active user, then add logo in cards
                if (location.href.includes("/Home/Index") || location.href.includes("/Profile/Index/"+viewmodel.User.Id())) {
                    var newAction = "/Home/GetLastestUpload";

                    $.ajax({
                        type: "GET",
                        url: newAction,
                        success: function (responseCard) {
                            // adding last upload logo as first element in array
                            viewmodel.Cards.splice(0, 0, ko.mapping.fromJS(responseCard));
                            // to increase number of logos if is located on account page
                            if (location.href.includes("/Profile/Index/" + viewmodel.User.Id())) {
                                viewmodel.LogosNum(viewmodel.LogosNum() + 1);
                            }
                        }
                    });
                }

                $('#modal-add-logo').modal('hide');
            } else {
                viewmodel.UploadLogo.ErrorText("Logo was not uploaded!");
                viewmodel.UploadLogo.ShowError(true);
            }
        }
    });
};

// Getting uploaded photo
$(document).on('change', '#upload-logo', function () {

    var input = $(this).get(0);

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            viewmodel.UploadLogo.LogoData(e.target.result)
        };

        reader.readAsDataURL(input.files[0]);
    }
});