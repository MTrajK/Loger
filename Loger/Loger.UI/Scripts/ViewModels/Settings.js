
viewmodel.ShowError = ko.observable(false);
viewmodel.ErrorText = ko.observable("");

viewmodel.ShowSuccess = ko.observable(false);
viewmodel.SuccessText = ko.observable("");

viewmodel.SaveChanges = function () {

    viewmodel.ShowError(false);
    viewmodel.ShowSuccess(false);

    if (viewmodel.CurrentPassword() == "" && viewmodel.NewPassword() == "" && viewmodel.ConfirmPassword() == "" && viewmodel.AccountPhotoData() == "") {
        viewmodel.ErrorText("Must change password or photo to save changes!");
        viewmodel.ShowError(true);
        return;
    }

    // If at least one field is completed
    if (!(viewmodel.CurrentPassword() == "" && viewmodel.NewPassword() == "" && viewmodel.ConfirmPassword() == "")) {

        if (viewmodel.CurrentPassword() == "" || viewmodel.NewPassword() == "" || viewmodel.ConfirmPassword() == "") {
            viewmodel.ErrorText("Must complete all fields to change password!");
            viewmodel.ShowError(true);
            return;
        }

        if (viewmodel.CurrentPassword().length < 8 || viewmodel.NewPassword().length < 8) {
            viewmodel.ErrorText("Password must contains at least 8 characters!");
            viewmodel.ShowError(true);
            return;
        }

        // Password regex: must contain 1 upper, 1 lower leter, 1 number, 1 character and length 8
        var passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/;

        if (!viewmodel.CurrentPassword().match(passwordRegex) || !viewmodel.NewPassword().match(passwordRegex)) {
            viewmodel.ErrorText("Password must contains uppercase letter, lowercase letter, number and special character!");
            viewmodel.ShowError(true);
            return;
        }

        if (viewmodel.NewPassword() != viewmodel.ConfirmPassword()) {
            viewmodel.ErrorText("Confirmed password is not same as new password!");
            viewmodel.ShowError(true);
            return;
        }

        if (viewmodel.CurrentPassword() == viewmodel.NewPassword()) {
            viewmodel.ErrorText("New password must be different from old password!");
            viewmodel.ShowError(true);
            return;
        }
    }

    var action = "/Profile/EditSettings";
    var data = {
        User: {
            Id: viewmodel.User.Id(),
            Username: viewmodel.User.Username(),
            AccountPhotoURL: viewmodel.User.AccountPhotoURL()
        },
        Username: viewmodel.Username(),
        CurrentPassword: viewmodel.CurrentPassword(),
        NewPassword: viewmodel.NewPassword(),
        ConfirmPassword: viewmodel.ConfirmPassword(),
        AccountPhotoURL: viewmodel.AccountPhotoURL(),
        AccountPhotoData: viewmodel.AccountPhotoData()
    };


    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {
            if (response == "photo and password changed") {
                viewmodel.SuccessText("Successfully changed photo and password");
                viewmodel.ShowSuccess(true);
                viewmodel.User.AccountPhotoURL(viewmodel.AccountPhotoData());
            } else if (response == "password changed") {
                viewmodel.SuccessText("Successfully changed password");
                viewmodel.ShowSuccess(true);
            } else if (response == "photo changed") {
                viewmodel.SuccessText("Successfully changed photo");
                viewmodel.ShowSuccess(true);
                viewmodel.User.AccountPhotoURL(viewmodel.AccountPhotoData());
            } else {
                viewmodel.ErrorText("Wrong password!");
                viewmodel.ShowError(true);
            }
        }
    });

};

// Getting uploaded photo
$(document).on('change', '#upload-user-picture', function () {

    var input = $(this).get(0);

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            viewmodel.AccountPhotoData(e.target.result)
        };

        reader.readAsDataURL(input.files[0]);
    }
});