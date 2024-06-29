

//document.ready() for userlogin
$(function () {
    $("#userName").trigger("focus");
    setUserTabFormat();
    setUserSubmitButtonValue();
    setSwitchStatusLabel();
    login();
});

function login() {
    //https://www.youtube.com/watch?v=7NKuUsBslBw
    var userName = $("#userName").val();
    var password = $("#signInPassword").val();
    var rememberMe = $("#rememberMeChecked").val();


    //alert("User name is : " + userName + " and password is :" + password);

    //making ajax call
    $.ajax({
        //define all the properties of this request to pass the data.
        url: '@Url.Action("LoginUser", "Home")',
        type: 'POST',
        dataType: 'json',
        data: {
            //pass the value to the property defined inside Model or ViewModel.
            Email: userName,
            Password: password

            //RememberMe: rememberMe
        },
        success: function (response) {
            console.log("Login is successful");
            console.log("From Success " + rememberMe);
        },
        error: function (xhr, status, error) {
            console.log("Login failed");
            console.log("From error " + rememberMe);
        }

    });
}
 
//function loginUser() {
//    $.ajax({
//        type: "post",
//        url: "Home/index",
//        data: data,
//        success: function (result) {
//            console.log(result);
//        }
//    });
//}

function setSwitchStatusLabel() {
    $("#rememberMeChecked").on('change', function () {
        var remember = $(this).is(':checked');

        if (remember === true) {
            //console.log("Yes, remember me!!");
            $('#isChekedOrNot').text("Yes, thats good..");
        }
        else {
            //console.log("No, its Ok!!");
            $('#isChekedOrNot').text("No, its ok..");
        }
    })
}
function setUserTabFormat() {
    $('ul.nav-tabs').on('click', function (event) {
        var activeTab = event.target.id;
        //alert("Clicked on  tab id " + activeTab);
    });

    $("#userLoginNavLink").on("click", function (event) {
        $('#userImage').attr("src", "../assets/images/svg/user_white.svg");
        $('#userRegistrationImage').attr("src", "../assets/images/svg/addUser.svg");
        $('#userForgotPwdImage').attr("src", "../assets/images/svg/pwdReset.svg");

        //$('#userLoginNavLink').removeClass("normalLink");
        //$('#userLoginNavLink').addClass("activeLink");
        //$('#userRegistrationNavLink').addClass("normalLink");
        //$('#userForgotPwdNavLink').addClass("normalLink");
    });

    $("#userRegistrationNavLink").on("click", function (event) {
        $('#userImage').attr('src', "../assets/images/svg/user.svg");
        $('#userRegistrationImage').attr("src", "../assets/images/svg/addUser_white.svg");
        $('#userForgotPwdImage').attr("src", "../assets/images/svg/pwdReset.svg");

        //$('#userLoginNavLink').addClass("normalLink");
        //$('#userRegistrationNavLink').removeClass("normalLink");
        //$('#userRegistrationNavLink').addClass("activeLink");
        //$('#userForgotPwdNavLink').addClass("normalLink");
    });

    $("#userForgotPwdNavLink").on("click", function (event) {
        $('#userImage').attr('src', "../assets/images/svg/user.svg");
        $('#userRegistrationImage').attr("src", "../assets/images/svg/addUser.svg");
        $('#userForgotPwdImage').attr("src", "../assets/images/svg/pwdReset_white.svg");

        //$('#userLoginNavLink').addClass("normalLink");
        //$('#userRegistrationNavLink').addClass("normalLink");
        //$('#userForgotPwdNavLink').removeClass("normalLink");
        //$('#userForgotPwdNavLink').addClass("activeLink");
    });
}


function setUserSubmitButtonValue() {

    //
    //$('.nav-tabs a').on('shown.bs.tab', function (e) {
    //    var clickedOn = e.target.id;

    //    $('#cardTitle').text(e.target.name);
    //    if (e.target.id == 'userLoginNavLink') {
    //        //alert($(this).attr('id'));
    //        $('#userSubmitButton').html('Login');
    //    }
    //    else if (e.target.id == 'userRegistrationNavLink') {
    //        $('#userSubmitButton').html('Register');
    //    } else if (e.target.id == 'userForgotPwdNavLink') {
    //        $('#userSubmitButton').html('Submit');
    //    }
    //});

    //OR better use below which is more generic.

    $('.nav-tabs a').on('shown.bs.tab', function () {
        var clickedOn = $(this).attr('data-tab-type');
        //alert("From data attri: " + clickedOn);

        // $('#cardTitle').text(e.target.name);
        if (clickedOn == 'login') {
            //alert($(this).attr('id'));
            $('#userSubmitButton').html('Login');
        }
        else if (clickedOn == 'register') {
            $('#userSubmitButton').html('Register');
        } else if (clickedOn == 'forgotPassword') {
            $('#userSubmitButton').html('Submit');
        }
    });
}





