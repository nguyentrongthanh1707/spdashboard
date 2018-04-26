//Load peronnel tabs
$(document).ready(function () {
    //preload student partial
    console.log("ready");
    var studentId, staffId, businessId;
    $.ajax({
        url: '/Personnel/Student',
        type: "get",
        dataType: "html",
        success: function (data) {
            //success
            $('#StudentPartial').html(data); //populate the tab content.
        },

    }).then(function () {
           
            deleteStudent();
        });
    //function to reset bootstrap modal popups
    $("#myModal").on("hidden.bs.modal", function () {
        $(".modal-header").removeClass(' ').addClass('alert-danger');
        $('.delete-confirmStudent').css('display', 'inline-block');
        $('.delete-confirmStaff').css('display', 'inline-block');
        $('.delete-confirmBusiness').css('display', 'inline-block');
        $('.success-message').html('').html('Are you sure you wish to delete this record ?');
    });
    deleteAccount();
    //check the confirm password field
    $("#txtNewPassword, #txtConfirmPassword").keyup(checkPasswordMatch);
    //end of the document ready function
});
//Ajax load list projects by selecting dropdownlist
$('#DashboardList').change(function () {

    /* Get the selected value of dropdownlist */
    var selectedID = $(this).val();

    /* Request the partial view with .get request. */
    if (selectedID == 1) {
        $.get('/Project/LoadPartialConsultancy/', function(data) {
            /* data is the pure html returned from action method */
            $('#partialPlaceHolder').html(data);
            $('#partialPlaceHolder').fadeIn('fast');
        });
    }
    else if (selectedID == 2) {
        $.get('/Project/LoadPartialInternship/', function(data) {
            /* data is the pure html returned from action method */
            $('#partialPlaceHolder').html(data);
            $('#partialPlaceHolder').fadeIn('fast');
        });
    }
    else {
        $.get('/Project/LoadPartialInternshipOverseas/', function(data) {
            /* data is the pure html returned from action method */
            $('#partialPlaceHolder').html(data);
            $('#partialPlaceHolder').fadeIn('fast');
        });
    }
});

//Date picker
$('.datepicker').datepicker({
    format: 'dd/mm/yyyy', //choose the date format you prefer
    orientation: 'left bottom'
});




$(".nav_link").click(function () {
    //Custom attribute data_id is used to store the ID
    //Get the ID
    var id = $(this).attr("data_id");
    if (id == 1) {
        $.ajax({
            url: '/Personnel/Student',
            type: "get",
            dataType: "html",
            success: function (data) {
                //success
                $('#StudentPartial').html(data); //populate the tab content.
            },
            error: function () {
                alert("Error loading");
            }
        }).then(function () {

            //Delete student
            deleteStudent();
        });
       
    }
    else if (id == 2) {
        $.ajax({
            url: '/Personnel/Staff',
            type: "get",
            dataType: "html",
            success: function (data) {
                //success
                $('#StaffPartial').html(data); //populate the tab content.
            },
            error: function () {
                alert("Error loading");
            }
        }).then(function () {
                deleteStaff();
            });
        
    }
    else {
        $.ajax({
            url: '/Personnel/Business',
            type: "get",
            dataType: "html",
            success: function (data) {
                //success
                $('#BusinessPartial').html(data); //populate the tab content.
            },
            error: function () {
                alert("Error loading");
            }
        }).then(function () {
                deleteBusiness();
            });
    }
   
});
//Delete account
function deleteAccount() {
    var accId = '';
    $('.deleteAcc').on('click', function() {
        accId = $(this).data('id');
        $('#accountModal').modal('show');
    });
    $('.delete-confirmAccount').click(function () {
        if (accId != '') {
            $.ajax({
                url: '/Account/Delete/' + accId,
                type: 'get',
                success: function (data) {
                    if (data) {
                        //now re-using the boostrap modal popup to show success message.
                        //dynamically we will change background colour 
                        if ($('.modal-header').hasClass('alert-danger')) {
                            $('.modal-header').removeClass('alert-danger').addClass('alert-success');
                            //hide ok button as it is not necessary
                            $('.delete-confirmStudent').css('display', 'none');
                        }
                        $('.success-message').html('Record deleted successfully');
                        window.location.reload();
                    }
                },
                error: function (err) {
                    if (!$('.modal-header').hasClass('alert-danger')) {
                        $('.modal-header').removeClass('alert-success').addClass('alert-danger');
                        $('.delete-confirmStudent').css('display', 'none');
                    }
                    $('.success-message').html(err.statusText);
                }
            });
        }
    });
}

function deleteStudent() {
    $(".deleteStudent").click(function (e) {
        studentId = $(this).data('id');
        $('#studentModal').modal('show');
    });
    $('.delete-confirmStudent').click(function () {
        if (studentId != '') {
            $.ajax({
                url: '/Personnel/DeleteStudent/'+studentId,
                type: 'get',
                success: function (data) {
                    if (data) {
                        //now re-using the boostrap modal popup to show success message.
                        //dynamically we will change background colour 
                        if ($('.modal-header').hasClass('alert-danger')) {
                            $('.modal-header').removeClass('alert-danger').addClass('alert-success');
                            //hide ok button as it is not necessary
                            $('.delete-confirmStudent').css('display', 'none');
                        }
                        $('.success-message').html('Record deleted successfully');
                        window.location.reload();
                    }
                },
                error: function (err) {
                    if (!$('.modal-header').hasClass('alert-danger')) {
                        $('.modal-header').removeClass('alert-success').addClass('alert-danger');
                        $('.delete-confirmStudent').css('display', 'none');
                    }
                    $('.success-message').html(err.statusText);
                }
            });
        }
    });
}


function deleteStaff() {
    //Delete staff
    $(".deleteStaff").click(function () {
        staffId = $(this).data('id');
        $('#staffModal').modal('show');
    });
    $('.delete-confirmStaff').click(function () {
        if (staffId != '') {
            $.ajax({
                url: '/Personnel/DeleteStaff/'+staffId,
                type: 'get',
                success: function (data) {
                    if (data) {
                        //now re-using the boostrap modal popup to show success message.
                        //dynamically we will change background colour 
                        if ($('.modal-header').hasClass('alert-danger')) {
                            $('.modal-header').removeClass('alert-danger').addClass('alert-success');
                            //hide ok button as it is not necessary
                            $('.delete-confirmStudent').css('display', 'none');
                        }
                        $('.success-message').html('Record deleted successfully');
                        window.location.reload();
                    }
                },
                error: function (err) {
                    if (!$('.modal-header').hasClass('alert-danger')) {
                        $('.modal-header').removeClass('alert-success').addClass('alert-danger');
                        $('.delete-confirmStudent').css('display', 'none');
                    }
                    $('.success-message').html(err.statusText);
                }
            });
        }
    });
}

function deleteBusiness() {
    //Delete Business
    $(".deleteBusiness").click(function () {
        businessId = $(this).data('id');
        $('#businessModal').modal('show');
    });
    $('.delete-confirmBusiness').click(function () {
        if (businessId != '') {
            $.ajax({
                url: '/Personnel/DeleteBusiness/'+businessId,
                type: 'get',
                success: function (data) {
                    if (data) {
                        //now re-using the boostrap modal popup to show success message.
                        //dynamically we will change background colour 
                        if ($('.modal-header').hasClass('alert-danger')) {
                            $('.modal-header').removeClass('alert-danger').addClass('alert-success');
                            //hide ok button as it is not necessary
                            $('.delete-confirmStudent').css('display', 'none');
                        }
                        $('.success-message').html('Record deleted successfully');
                        window.location.reload();
                    }
                },
                error: function (err) {
                    if (!$('.modal-header').hasClass('alert-danger')) {
                        $('.modal-header').removeClass('alert-success').addClass('alert-danger');
                        $('.delete-confirmStudent').css('display', 'none');
                    }
                    $('.success-message').html(err.statusText);
                }
            });
        }
    });
}

//Check confirm password function
function checkPasswordMatch() {
    var password = $("#txtPassword").val();
    var confirmPassword = $("#txtConfirmPassword").val();

    if (password != confirmPassword)
        $("#divCheckPasswordMatch").html("Passwords do not match!");
    else
        $("#divCheckPasswordMatch").html("Passwords match.");
}