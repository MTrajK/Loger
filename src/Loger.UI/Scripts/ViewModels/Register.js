
viewmodel.ShowError = ko.observable(false);
viewmodel.ErrorText = ko.observable("");

viewmodel.Register = function () {

    viewmodel.ShowError(false);

    if (viewmodel.Email() == "" || viewmodel.Email() == "" || viewmodel.Password() == "" || viewmodel.ConfirmPassword() == "") {
        viewmodel.ErrorText("Fields must not be empty!");
        viewmodel.ShowError(true);
        return;
    }

    // Regex for valid email
    var emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    // "string".match("regex") return array with occurrences if exist some equal match in string
    if (!viewmodel.Email().match(emailRegex)) {
        viewmodel.ErrorText("Email is not valid!");
        viewmodel.ShowError(true);
        return;
    }

    // Usernames can contain letters, digit, period, underscore
    var usernameRegex = /^\w[\w\.]+\w$/;

    if (!viewmodel.Username().match(usernameRegex)) {
        viewmodel.ErrorText("Username can contain letter, digit, period and underscore!");
        viewmodel.ShowError(true);
        return;
    }

    if (viewmodel.Username().length < 3) {
        viewmodel.ErrorText("Username must contains at least 3 characters!");
        viewmodel.ShowError(true);
        return;
    }

    if (viewmodel.Username().length > 20) {
        viewmodel.ErrorText("Username must contains lest than 20 characters!");
        viewmodel.ShowError(true);
        return;
    }

    if (viewmodel.Password().length < 8) {
        viewmodel.ErrorText("Password must contains at least 8 characters!");
        viewmodel.ShowError(true);
        return;
    }

    // Password regex: must contain 1 upper, 1 lower leter, 1 number, 1 character and length 8
    var passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/;

    if (!viewmodel.Password().match(passwordRegex)) {
        viewmodel.ErrorText("Password must contains uppercase letter, lowercase letter, number and special character!");
        viewmodel.ShowError(true);
        return;
    }

    if (viewmodel.Password() != viewmodel.ConfirmPassword()) {
        viewmodel.ErrorText("Passwords are not equal!");
        viewmodel.ShowError(true);
        return;
    }

    var action = "/Account/UserRegister";
    var data = {
        Email: viewmodel.Email(),
        Username: viewmodel.Username(),
        Password: viewmodel.Password(),
        ConfirmPassword: viewmodel.ConfirmPassword()
    };

    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {
            if (response == "success") {
                window.location = "/Home/Index";
            } else if (response == "email exist") {
                viewmodel.ErrorText("Exist user with that email!");
                viewmodel.ShowError(true);
            } else if (response == "username exist") {
                viewmodel.ErrorText("Exist user with that username!");
                viewmodel.ShowError(true);
            }
        }
    });

};