
$(document).ready(function () {
    $("#btnSend").click(function () {

        $.ajax({
            url: '/User/GetJsonMail',
            data: {
                'To': $("#To").val(),
                'Subject': $("#Subject").val(),
                'Body': $("#Body").val()
            },

            type: "POST",
            cache: false,

        });

        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Mail Gönderildi',
            showConfirmButton: false,
            timer: 3500
        });


    });
});

$(document).ready(function () {
    $(function () {
        $("#Body").html("ANKARA BÜYÜKŞEHİR BELEDİYESİ tarafından yapılan başvurunuz onaylanmıştır...");
    });

});

/*Deneme-1*/
//$(document).ready(function () {
//    $('#btnSend').click(function () {
//        $.ajax({
//            url: "/User/GetJsonMail",
//            data: JSON.stringify(),
//            contentType: "application/json; charset=utf-8",
//            type: "POST",
//            datatype: "json",
//        });

//    });

//});



//Deneme-2
//$(document).ready(function () {
//    $("#btnSend").click(function () {
//        $.post("@Url.Action("GetJsonMail", "User")", function () {
//            alert(data);
//        });
//    });
//});





//Deneme-3

//$("#btnSend").click(function () {
//    $("#btnSend").attr("disabled", "true");




//    $.ajax({
//        type: "POST",
//        url: "/User/GetJsonMail",
//        contentType: "application/json; charset=utf-8",


//        dataType: "json",
//        success: function () {
//            $("#btnSend").removeAttr("disabled");
//            alert("işlem tamam asdklfj")

//        },
//        error: function () {
//            $("#btnSend").removeAttr("disabled");
//        }

//    });
//});