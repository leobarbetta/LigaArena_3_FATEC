$(document).ready(function () {
    var hDiv = 0;
    $.ajax({
        dataType: 'html',
        type: 'POST',
        success: function (data, textStatus) {
            $('#mainDiv').html(data);        //recebendo o conteudo via ajax na div  
            hDiv = $('.conteudo-site').height();   // obtem a altura  
            $('.menu-departamentos').height(hDiv);      // configura a nova altura  
        }
    })
});