$(document).ready(function () {

    var objLogin = {

        Initialize: function () {
            var Self = this;

            Self.InputValidation();
            Self.BindEvent();
        },

        BindEvent: function () {

            $('#btnLogin').click(function () {

                if ($('#formLogin').valid()) {

                    var params = {
                        Username: $('#inputUsername').val(),
                        Password: $('#inputPassword').val()
                    };

                    console.log(params); // test lang to kung papasok ba yung username and password kapag valid

                     //pang redirect muna from login to dashboard

                    $.ajax({
                        type: 'GET',
                        url: '/Home/GetUserCredentials', // format nito ay /ControllerName/MethodName
                        dataType: 'json',
                        contentType: 'application/json; charset=utf-8',
                        data: params,
                        success: function (data) {
                            window.location.href = "/Home/Index";
                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText);
                        }

                    });

                }

            });
        },

        InputValidation: function () {
            var ctr = 0;
            var errorCount = 0;
            var requiredErrors = [];
            var otherErrors = [];

            validator = $('#formLogin').validate({
                errorElement: 'label',
                errorClass: 'text-danger',
                onfocusout: false,
                onkeyup: false,
                onclick: false,
                rules: {
                    inputUsername: {
                        required: true
                    },
                    inputPassword: {
                        required: true                 
                    }
                },
                messages: {
                    inputUsername: {
                        required: "Username is required."
                    },
                    inputPassword: {
                        required: "Password is required."
                    }
                },
                invalidHandler: function () {
                    errorCount = validator.numberOfInvalids();
                },
                errorPlacement: function (error, element) {
                    ctr++;
                    if ($(error).text().indexOf('required') < 0) {
                        otherErrors.push('<label class=\"text-danger\">' + $(error).text() + '</label>');
                    } else {
                        requiredErrors.push('<label class=\"text-danger\">' + $(error).text() + '</label>');
                    }

                    if (ctr == errorCount) {
                        if (requiredErrors.length > 1) {
                            requiredErrors = [];
                            requiredErrors.push('<label class=\"text-danger\">Highlighted fields are required.</label>');
                        }

                        if (otherErrors.length != 0) {
                            $('#divErrorMsg').append(otherErrors);
                        }
                        if (requiredErrors.length != 0) {
                            $('#divErrorMsg').append(requiredErrors);
                        }
                        requiredErrors = [];
                        otherErrors = [];
                        ctr = 0;
                    }
                }
            });
        }
    };

    var Login = Object.create(objLogin);
    Login.Initialize();

});