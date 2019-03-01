
viewmodel.ShowError = ko.observable(false);
viewmodel.ErrorText = ko.observable("");

viewmodel.Login = function () {

    viewmodel.ShowError(false);

    if (viewmodel.Email() == "" || viewmodel.Password() == "") {
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

    var action = "/Account/UserLogin";
    var data = {
        Email: viewmodel.Email(),
        Password: viewmodel.Password()
    };

    $.ajax({
        type: "POST",
        url: action,
        data: data,
        success: function (response) {
            if (response == "success") {
                window.location = "/Home/Index";
            } else {
                viewmodel.ErrorText("Wrong email or password!");
                viewmodel.ShowError(true);
            }
        }
    });

};