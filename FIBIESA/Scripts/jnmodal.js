$(document).ready(function () {
    $("a[rel=modal]").click(function (ev) {
        ev.preventDefault();

        var id = $(this).attr("href");

        var alturaTela = $(document).height();
        var larguraTela = $(window).width();

        //colocando o fundo preto
        $('#mascara').css({ 'width': larguraTela, 'height': alturaTela });
        $('#mascara').fadeIn(1000);
        $('#mascara').fadeTo("slow", 0.8);

        var left = ($(window).width() / 2) - ($(id).width() / 2);
        var top = ($(window).height() / 2) - ($(id).height() / 2);

        $(id).css({ 'top': top, 'left': left });
        $(id).show();
    });

    $("#mascara").click(function () {
        $(this).hide();
        $(".window").hide();
    });

    $('.fechar').click(function (ev) {
        ev.preventDefault();
        $("#mascara").hide();
        $(".window").hide();
    });
});


// $(function(){
//             
//    // Dialog
//    $('#dialog').dialog({
//        autoOpen: false,
//        width: 600,
//        buttons: {
//            "Ok": function() {
//                $(this).dialog("close");
//            },
//            "Cancel": function() {
//                $(this).dialog("close");
//            }
//        }
//    });
//    // Dialog Link
//    $('#dialog_link').click(function(){
//        $('#dialog').dialog('open');
//        return false;
//    });        
// 
//    //hover states on the static widgets
//    $('#dialog_link, ul#icons li').hover(
//        function() { $(this).addClass('ui-state-hover'); },
//        function() { $(this).removeClass('ui-state-hover'); }
//    );

//});

function success() {
    $("#msg").dialog({
        title: 'Alerta!',
        width: 600,
        autoResize: true,
        dialogClass: 'no-close',
        modal: true,
        resizable: false,
        draggable: false,
        buttons: { 'Fechar': function () { $('#msg').dialog('close'); } },
        close: function () { window.location = "./index.php"; }
    });
}

function unsuccess() {
    $("#msg").dialog({
        title: 'Alerta!',
        width: 500,
        height: 200,
        dialogClass: 'no-close',
        modal: true,
        resizable: false,
        draggable: false,
        buttons: { "Fechar": function () { $('#msg').dialog('close'); } }
    });
}

$(document).ready(function () {
    $("input.submit").click(function () {
        $.post(
            "cadastro.php",
            { nome: $("#nome").val(), sobrenome: $("#sobrenome").val(), action: $("#action").val() },
            function (responseText) {
                $("#msg").html(responseText);
            },
            "html"
        );
    });
});
        



