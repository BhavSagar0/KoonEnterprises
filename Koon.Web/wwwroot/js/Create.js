$(document).ready(function () {

    const urlParams = new URLSearchParams(window.location.search);

    if (!$('#radioMaritalStatus input[type=radio]').prop('checked') && $("#hdnMaritalStatus").length == 0)
        $("#UnmarriedRadio").prop('checked', true);

    if ($("#hdnSuccess").length)
        $("#submitBtn").prop('disabled', true);

    if (urlParams.get('isSuccess') == "True") {

        const url = new URL(window.location.href);
        url.searchParams.set('isSuccess', 'false');
        var counter = 5;
        setInterval(function () {
            counter--;
            if (counter >= 0) {
                span = document.getElementById("count");
                span.innerHTML = counter;
            }
            // Display 'counter' wherever you want to display it.
            if (counter === 0) {
                //    alert('this is where it happens');
                clearInterval(counter);
                window.location.href = window.location.origin;
            }
        }, 1000);
    }

    if (!$("#marriedCheck").prop('checked') && !$("#unmarriedCheck").prop('checked'))
        $("#unmarriedCheck").prop('checked', true);

    if ($("#StateSelector").val() != -1)
        loadCities();

    if ($("#hdnImgSrc").val() != "")
        loadImage();

    $("#getFile").change(function (event) {
        var ext = this.value.match(/\.(.+)$/)[1];
        switch (ext) {
            case 'jpg':
            case 'jpeg':
            case 'png':
            case 'gif':
                $('#submitBtn').attr('disabled', false);
                $("#hdnImgSrc").val(URL.createObjectURL(event.target.files[0]));
                loadImage();
                break;
            default:
                alert('This is not an allowed file type.');
                this.value = '';
        }
    });
    

    $("#StateSelector").change
        (
            function () { loadCities(); }
        );

    var form = document.getElementById('CreateUpdateForm');
    var submitButton = document.getElementById('submitBtn');

    form.addEventListener('submit', function () {

        // Disable the submit button
        submitButton.setAttribute('disabled', 'disabled');

        // Change the "Submit" text
        submitButton.value = 'Please wait...';

    }, false);

    function loadImage()
    {
        $("#imageHolder").prop("src", $("#hdnImgSrc").val());
    }

    function loadCities() {
        var CitiesURL = $('#GetCitiesOfStates').data('url');
        $("#CitySelector").empty();
        $.ajax(
            {
                type: "POST",
                url: CitiesURL,
                data: { stateId: $("#StateSelector").val() },
                dataType: "json",
                success: function (msg) {
                    $("#CitySelector").append('<option value=-1 selected>---Select City---</option>');
                    $.each(msg, function (index, value) {

                        if (value.cityId == $("#hdnCityId").val())
                            $("#CitySelector").append('<option selected value=' + value.cityId + '>' + value.cityName + '</option>')
                        else
                            $("#CitySelector").append('<option value=' + value.cityId + '>' + value.cityName + '</option>')
                    });
                    
                    console.log(msg);
                },
                error: function (req, status, error) {
                    alert(error);
                }
            }
        );
    }
});