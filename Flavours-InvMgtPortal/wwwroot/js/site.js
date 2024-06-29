function confirmDelete(isDeleteClicked) {
    var deleteSpan = 'deleteSpan';
    var confirmDeleteSpan = 'confirmDeleteSpan';

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }
    else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }

}

//$("#userName").focus();
//$(document).ready(function () {

//    $("#userLoginNavLink").click(function () {
//        $('#userImage').attr("src", "../assets/images/svg/user.svg");
//        $('#userRegistrationImage').attr("src", "../assets/images/svg/addUser_white.svg");
//        $('#userForgotPwdImage').attr("src", "../assets/images/svg/pwdReset_white.svg");
//    });

//    $("#userRegistrationNavLink").click(function () {
//        $('#userImage').attr('src', "../assets/images/svg/user_white.svg");
//        $('#userRegistrationImage').attr("src", "../assets/images/svg/addUser.svg");
//        $('#userForgotPwdImage').attr("src", "../assets/images/svg/pwdReset_white.svg");
//    });

//    $("#userForgotPwdNavLink").click(function () {
//        $('#userImage').attr('src', "../assets/images/svg/user_white.svg");
//        $('#userRegistrationImage').attr("src", "../assets/images/svg/addUser_white.svg");
//        $('#userForgotPwdImage').attr("src", "../assets/images/svg/pwdReset.svg");
//    });
//});


/*var activeTab = $('ul#userProcessTab li').has('a.active').attr('id');*/
$(function () {

    // Handling data-toggle manually
    //$('.nav-tabs a').on("click", function () {
    //    (this).tab('show');

    //});
    // The on tab shown event
    //$('.nav-tabs a').on('shown.bs.tab', function (e) {
    //    //var clickedOn = e.target.id;
    //    //alert(clickedOn);
    //    $('#cardTitle').text(e.target.name);
    //});

    //login();
});

//function login() {
//    //https://www.youtube.com/watch?v=7NKuUsBslBw
//    var userName = $("#userName").val();
//    var password = $("#signInPassword").val();

//    //alert("User name is : " + userName + " and password is :" + password);

//    //making ajax call
//    $.ajax({
//        //define all the properties of this request to pass the data.
//        url: '@Url.Action("actionName", "coontrollerName)',
//        type: 'POST',
//        dataType: 'json',
//        data: {
//            //pass the value to the property defined inside Model or ViewModel.
//            //PropertyName: userName,
//            //PropertyName: password
//        },
//        success: function (response) {
//            console.log("Login is successful");
//        },
//        error: function (xhr, status, error) {
//            console.log("Login failed")
//        }

//    });
//}