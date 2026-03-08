
$("#loginForm").submit(function (e) {
    e.preventDefault();

    var data = {
        Email: $("#Email").val(),
        Password: $("#PasswordHash").val()
    };

    $.ajax({
        url: "/Login/Index",   // tu controlador MVC
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (response) {
            // Si el backend devuelve el token y todo está bien
            window.location.href = "/Home/Index";
        },
        error: function (xhr) {
            if (xhr.status === 400) {
                alert("Email o contraseña incorrectos");
            } else {
                alert("Error inesperado: " + xhr.status);
            }
        }
    });
});


