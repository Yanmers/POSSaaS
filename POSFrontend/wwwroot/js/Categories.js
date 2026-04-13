
$("#categoryForm").submit(function (e) {
    e.preventDefault();

    var data = {
        Name: $("#Name").val(),
        Description: $("#Description").val()
    };

    $.ajax({
        url: "/Categories/Index",   // tu controlador MVC
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (response) {
            window.location.href = "/Home/Index";
        },
        error: function (xhr) {
            if (xhr.status === 400) {
                alert("Name o Description incorrectos");
            } else {
                alert("Error inesperado: " + xhr.status);
            }
        }
    });
});




