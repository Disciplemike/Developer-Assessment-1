// Write your JavaScript code.
function SetStudentsTableContent() {
    var lastName = $('#studentLastName').val();
    $.get('/api/students/bylastname?lastname='+ lastName, function (data) {
        var tableTarget = $('#studentTable > tbody');
        $('#studentTable > tbody').html('');
        $.each(data, function (index, student) {
            $(tableTarget).append('<tr><td>' + student.firstname + '</td><td>' + student.lastname + '</td></tr>');
        });
    });
}

function SetStudentsTableContentById() {
    var studentId = $('#studentId').val();
    $.get('/api/students/Find?id=' + studentId, function (data) {
        var tableTarget = $('#studentTableById > tbody');
        $(tableTarget).html('');
        $.each(data, function (index, student) {
            $(tableTarget).append('<tr><td>' + student.firstname + '</td><td>' + student.lastname + '</td></tr>');
        });
    });
}