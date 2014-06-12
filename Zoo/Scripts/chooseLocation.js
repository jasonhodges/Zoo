$(function () {
    $('#locationDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Add Location',
        buttons: {
            'Save': function () {
                var createLocationForm = $('#createLocationForm');
                if (createLocationForm.valid()) {
                    $.post(createLocationForm.attr('action'), createLocationForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new location to the dropdown list and select it 
                            $('#Id').append(
                                    $('<option></option>')
                                        .val(data.Location.Id)
                                        .html(data.Location.City)
                                        .prop('selected', true)  // Selects the new Location in the DropDown LB 
                                );
                            $('#locationDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancel': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#locationAddLink').click(function () {
        var createFormUrl = $(this).attr('href');
        $('#locationDialog').html('')
        .load(createFormUrl, function () {
            // The createLocationForm is loaded on the fly using jQuery load.  
            // In order to have client validation working it is necessary to tell the  
            // jQuery.validator to parse the newly added content 
            jQuery.validator.unobtrusive.parse('#createLocationForm');
            $('#locationDialog').dialog('open');
        });

        return false;
    });
});