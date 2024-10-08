$(document).ready(function () {

    var objLogin = {

        Initialize: function () {
            var Self = this;

            Self.InputValidation();
            Self.BindEvent();
        },

        BindEvent: function () {
            var Self = this; // Store reference to the object

            $('#btnLogin').click(function () {
                // Check if the form is valid before proceeding
                if ($('#formLogin').valid()) {
                    var params = {
                        Username: $('#inputUsername').val(),
                        Password: $('#inputPassword').val()
                    };

                    console.log(params); // Check if params are correct

                    $.ajax({
                        type: 'GET',
                        url: '/Home/GetUserCredentials',
                        dataType: 'json',
                        contentType: 'application/json; charset=utf-8',
                        data: params,
                        success: function (data) {
                            if (data.success) {
                                window.location.href = data.redirectUrl; // Redirect based on server response
                            } else {
                                $('#divErrorMsg').text(data.message); // Show error message
                            }
                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText);
                        }
                    });
                } else {
                    $('#divErrorMsg').text("Please fill in the required fields."); // Show a message for validation errors
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


/*
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

                    console.log(params); // Check if the username and password are valid

                    // Redirect from login to the appropriate dashboard
                    $.ajax({
                        type: 'GET',
                        url: '/Home/GetUserCredentials', // This should match your controller and method
                        dataType: 'json',
                        contentType: 'application/json; charset=utf-8',
                        data: params,
                        success: function (data) {
                            if (data.success) {
                                window.location.href = data.redirectUrl; // Redirect to the appropriate dashboard
                            } else {
                                alert(data.message); // Show error message if credentials are invalid
                            }
                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText); // Handle AJAX errors
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
*/ 

