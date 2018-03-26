// Write your JavaScript code.
function SetStudentsTableContent() {
    var lastName = $('#studentLastName').val();
    $.get('/api/students/bylastname?lastName='+ lastName, function (data) {
        var tableTarget = $('#studentTable > tbody');
        $('#studentTable > tbody').html('');
        $.each(data, function (index, student) {
            $(tableTarget).append('<tr><td>' + student.firstName + '</td><td>' + student.lastName + '</td></tr>');
        });
    });
}
