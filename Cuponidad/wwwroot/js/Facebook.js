$(document).ready(function () {
    if ($('#FacebookLogin').length == 0) return;
    $('#FacebookLogin').on('click', function () {
        debugger
        LoginToFacebook($(this).attr("data-ServerBaseUrl"), $(this).attr("data-RedirectUrl"));
    })
})

window.fbAsyncInit = function () {
    FB.init({
        appId: '270414329977930',
        cookie: true,
        xfbml: true,
        version: 'v2.8'
    });
};

// Load the SDK asynchronously
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.12&appId=771542012920815&autoLogAppEvents=1";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

function Facebook(callback) {
    debugger
    FB.getLoginStatus(function (response) {
        debugger
        if (response.status === 'connected') {
            callback(response);
            return;
        }
        else {
            FB.login(function (response) {
                callback(response);
                return;
            }, { scope: 'email,user_likes' });
        }
    });
}

function LoginToFacebook(ServerBaseUrl, RedirectUrl) {
    debugger
    Facebook(function (Response) {
        debugger
        if (Response.status == 'connected') {
            $.ajax(ServerBaseUrl + 'FacebookLogin?pFBID=' + Response.authResponse.userID + '&pAccessToken=' + Response.authResponse.accessToken)
                .done(function (json) {
                    window.location.href = RedirectUrl;
                })
                .fail(function (json) {
                    if (json.responseText != null && json.responseText.length > 0) {
                        alert(json.responseText);
                    }
                    else {
                        alert("operation failed.");
                    }
                })
        }
        else {
            alert("User does not successfully logged In");
        }
    });

}


