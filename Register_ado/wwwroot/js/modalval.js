$(document).ready(function () {
    $("#uname").hide();
    $("#uemail").hide();
    $("#uhobbies").hide();
    $("#udep").hide();
    $("#udes").hide();
    error_name = false;
    error_email = false;
    error_hobbies = false;
    error_department = false;
    error_designation = false;
    $("#name").keyup(function () {
        check_name();
    });
    $("#email").keyup(function () {
        check_email();
    })
    $("#hobbies1").change(function () {
        check_hobbies();
    })
    $("#department").keyup(function () {
        check_department();
    })
    $("#designation").keyup(function () {
        check_designation();
    })


    function check_name() {
        var name = $("#name").val();
        if (name != '') {
            $("#uname").hide();
        }
        else {
            $("#uname").html("Pls enter your name");
            $("#uname").show();
            $("#uname").css("color", "red");
            error_name = true;
        }
    }
    function check_email() {
        var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i
        var email = $("#email").val();
        if (pattern.test(email)) {
            $("#uemail").hide();
        }
        else {
            $("#uemail").html("Pls enter a valid Email");
            $("#uemail").show();
            $("#uemail").css("color", "red");
            error_email = true;
        }
    }
    function check_hobbies() {
        var hobbies = $("#hobbies1").val();
        if (hobbies != '') {
            $("#uhobbies").hide();
        }
        else {
            $("#uhobbies").html("Pls enter your hobbies");
            $("#uhobbies").show();
            $("#uhobbies").css("color", "red");
            error_hobbies = true;
        }
    }
    function check_department() {
        var department = $("#department").val();
        if (department != '') {
            $("#udep").hide();
        }
        else {
            $("#udep").html("Pls enter your department");
            $("#udep").show();
            $("#udep").css("color", "red");
            error_department = true;
        }
    }
    function check_designation() {
        var designation = $("#designation").val();
        if (designation != '') {
            $("#udes").hide();
        }
        else {
            $("#udes").html("Pls enter your designation");
            $("#udes").show();
            $("#udes").css("color", "red");
            error_designation = true;
        }
    }
    $('#update').click(function () {
        debugger
        error_name = false;
        error_email = false;
        error_hobbies = false;
        error_department = false;
        error_designation = false;

        check_name();
        check_email();
        check_hobbies();
        check_department();
        check_designation();
        if (error_name == false && error_email === false && error_hobbies === false && error_department === false && error_designation === false) {
            debugger
            $.ajax({

                type: 'POST',
                url: '/Home/updateuser',
                data: {
                    id: $('#id').val(),
                    Name: $('#name').val(),
                    Email: $('#email').val(),
                    Hobbies: $('#hobbies1').val().join(', '),
                    Department: $('#department').val(),
                    Designation: $('#designation').val(),

                },
                success: function () {

                    location.reload();

                },
                error: function () {

                    $('#tblData').DataTable().ajax.reload();
                }

            })

        }

        else {
            $('#editmodal').modal('show');

        }
    });
})

