$(function () {
    // za upload na logo

    $(document).on('change', '#upload-logo', function() {

        var input = $(this).get(0);

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#uploaded-logo')
                    .attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
        }
    });

    // za upload na user picture

    $(document).on('change', '#upload-user-picture', function() {

        var input = $(this).get(0);

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#uploaded-user-picture')
                    .attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
        }
    });

});