$(document).ready(function(){
    /*$('.sold-item').submit(function(event) {
    console.log('hdfhsdklf');
        event.preventDefault();
        console.log($(this).serialize());
        $.ajax({
            url:'/Associates/SoldItem',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function(result) {
                console.log(result);
                $('.sold-output').html("your item id: " + result.associateId);
            },
            error: function(result) {
            console.log("error" + result);
            }
        });
    });*/

 /*   $('.sold-item').on('submit', function(event) {
        event.preventDefault();
        var dataToPost = $(this).serialize();
        $.post("/Associates/SoldItem", dataToPost)
            .done(function(response, status, jqxhr) {
                $('.sold-output').html("your item id: " + response.associateId);
            })
            .fail(function(jqxhr,status,error){
                console.log("failure :( :'( ")
            });
    });*/

    $('.new-product').submit(function(event){
        event.preventDefault();
        console.log($(this).serialize());
        
        $.ajax({
            url: '/Products/NewProduct',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function(result) {
            console.log(result);
                var resultMessage = result.name + ' has been added. <br>Product Cost: $' + result.cost + '<br>Retail Price: $' + result.retailPrice;
                $('#output').html(resultMessage);
                $('.inputField').val('');
            }
       });
    });



});
