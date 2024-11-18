function AddToCart(id) {
    $.ajax({
        type: 'post',
        url: '/Cart/AddToCart',
        dataType: 'json',
        data: { movieId: id },
        success: function (resp) {
            $('#cartCount').html(resp.count);
            console.log(resp.msg);
        },
        error: function (xhr, status, error) {
            console.error("Error adding to cart:", error);
        }
    })
}

function Plus1(id) {
    $.ajax({
        type: 'post',
        url: '/Cart/Plus1',
        dataType: 'json',
        data: { movieId: id },
        success: function (resp) {
            $('#cartCount').html(resp.count);
            $('#' + id + 'Quantity').html(resp.countId);
            let qup = resp.countId * $('#' + id + 'Price').html();
            $('#' + id + 'Qup').html(qup.toFixed(2));
            let amount = Number($('#totalAmount').html()) + 1;
            $('#totalAmount').html(amount);
            let cost = Number($('#totalCost').html()) + Number($('#' + id + 'Price').html());
            $('#totalCost').html(cost.toFixed(2));
            console.log(resp.msg);
        },
        error: function (xhr, status, error) {
            console.error("Error adding to cart:", error);
        }
    })
}
6
function Minus1(id) {
    $.ajax({
        type: 'post',
        url: '/Cart/Minus1',
        dataType: 'json',
        data: { movieId: id },
        success: function (resp) {
            $('#cartCount').html(resp.count);
            $('#' + id + 'Quantity').html(resp.countId);
            let qup = resp.countId * $('#' + id + 'Price').html();
            $('#' + id + 'Qup').html(qup.toFixed(2));
            let amount = Number($('#totalAmount').html()) - 1;
            $('#totalAmount').html(amount);
            let cost = Number($('#totalCost').html()) - Number($('#' + id + 'Price').html());
            $('#totalCost').html(cost.toFixed(2));
            if (resp.countId == 0) {
                $('#' + id + 'Row').hide();
            }
            console.log(resp.msg);
        },
        error: function (xhr, status, error) {
            console.error("Error adding to cart:", error);
        }
    })
}


