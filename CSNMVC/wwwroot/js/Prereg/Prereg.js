$(document).ready(function () {
    let childImageBase64 = ""; // Variable to store the Base64 string

    // Function to handle file selection
    function handleFileSelect(event) {
        const file = event.target.files[0]; // Get the selected file
        const reader = new FileReader();

        reader.onloadend = function () {
            childImageBase64 = reader.result; // Store the Base64 string
        };

        if (file) {
            reader.readAsDataURL(file); // Read the file as Data URL
        } else {
            childImageBase64 = ""; // Clear the Base64 string if no file is selected
        }
    }

    // Attach the file input change event
    $('#child-pic').on('change', handleFileSelect);

    // Function for handling the next button click
    $('#next-button').on('click', function () {
        // Perform validation if necessary
        if ($("#preregForm").valid()) {
            // Collect data from the form
            const childData = {
                ChildSname: $('#surname').val(),
                ChildFname: $('#first-name').val(),
                ChildMname: $('#middle-name').val(),
                ChildSex: $('input[name="sex"]:checked').val(),
                Birthday: $('#birthday').val(),
                ChildAge: $('#age').val(),
                Address: $('#address').val(),
                Barangay: $('#barangay').val(),
                Diagnosis: $('#diagnosis').val(),
                ContactNumber: $('#contact').val(),
                Email: $('#email').val(),
                Picture: childImageBase64.split(',')[1] // Get the Base64 part only
            };

            // Save the collected data in the session via an AJAX call
            $.ajax({
                url: '@Url.Action("SaveStep1Data", "Prereg")', // Controller action to save data
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(childData),
                success: function () {
                    // On success, redirect to the next step
                    window.location.href = '@Url.Action("Prereg2", "Prereg")';
                },
                error: function () {
                    alert("Failed to save data. Please try again.");
                }
            });
        }
    });
});

