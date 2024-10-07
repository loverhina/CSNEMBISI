$(document).ready(function () {
    let childCount = 1; // Initialize a counter for the number of child entries

    // Function to handle adding new child entries
    $('#add-child').on('click', function () {
        const childrenInfo = $('#children-info');
        const newChildEntry = $(`
            <div class="child-entry">
                <div class="form-row mb-3">
                    <div class="col-md-12">
                        <label for="child-name-${childCount}">Name of Child:</label>
                        <input type="text" class="form-control" id="child-name-${childCount}" name="child-name-${childCount}" placeholder="Enter child's name" required>
                    </div>
                </div>
                <div class="form-row mb-3">
                    <div class="col-md-4">
                        <label for="child-age-${childCount}">Age:</label>
                        <input type="number" class="form-control" id="child-age-${childCount}" name="child-age-${childCount}" min="0" placeholder="Enter child's age" required>
                    </div>
                    <div class="col-md-4">
                        <label for="sex-${childCount}">Sex</label>
                        <div class="form-control">
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" id="child-sex-male-${childCount}" name="child-sex-${childCount}" value="Male" required>
                                <label class="form-check-label" for="child-sex-male-${childCount}">Male</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" id="child-sex-female-${childCount}" name="child-sex-${childCount}" value="Female" required>
                                <label class="form-check-label" for="child-sex-female-${childCount}">Female</label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label for="educational-attainment-${childCount}">Educational Attainment:</label>
                        <input type="text" class="form-control" id="educational-attainment-${childCount}" name="educational-attainment-${childCount}" placeholder="Enter educational attainment" required>
                    </div>
                </div>
            </div>
        `);

        childrenInfo.append(newChildEntry);
        childCount++; // Increment the counter for the next child entry
    });

    // Back button navigation
    $('#back-button').on('click', function () {
        window.history.back(); // Navigate to the previous page
    });

    // Next button navigation
    $('#next-button').on('click', function () {
        // You can add validation logic here if necessary

        // Navigate to Prereg3 action
        const nextStepUrl = '@Url.Action("Prereg3", "Prereg")'; // Ensure this is correctly set
        window.location.href = nextStepUrl; // Use the variable to store the next step's URL
    });
});

