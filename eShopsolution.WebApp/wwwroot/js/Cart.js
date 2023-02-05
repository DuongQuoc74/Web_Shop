var CartController = function () {
    this.initialize = function () {
        loadData();
        ResgisterEvent();
    }
    function ResgisterEvent() {
        $('body').on('click', '.btn-plus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val())+1;
            UpdateCart(id, quantity);
        });

        $('body').on('click', '.btn-minus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) - 1;
            UpdateCart(id, quantity);
        });

        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            UpdateCart(id, 0);
        })

    }
    function UpdateCart(id, quantity) {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "POST",
            url: "/" + culture + '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                loadData();
                $('#lbl_number_items_header').text(res.length);
            },
            error: function (e) {
                console.log(e);
            }
        });
    }

    function loadData() {
        const culture = $('#hidCulture').val();
        const baseAddress = $('#hidConfiguration').val();
       
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListItems',
            success: function (res) {
                if (res.length == 0) {
                    $('#lbl_cart').hide();
                }
                var total = 0;
                var html = "";
                $.each(res, function (i, item) {
                    var amount = item.price * item.quantity;
                    html += "<tr>"
                        + "<td> <img width=\"60\" src=\"" + baseAddress + item.image + "\" alt=\"\" /></td>"
                        + "<td>" + item.description + "</td>"
                        + "<td><div class=\"input-append\"><input class=\"span1\" style=\"max-width: 34px\" placeholder=\"1\" id=\"txt_quantity_" + item.productId + "\" value=\"" + item.quantity + "\" size=\"16\" type=\"text\">"
                        + "<button class=\"btn btn-minus\" data-id=\"" + item.productId + "\" type =\"button\"> <i class=\"icon-minus\"></i></button>"
                        + "<button class=\"btn btn-plus\" type=\"button\" data-id=\"" + item.productId + "\"><i class=\"icon-plus\"></i></button>"
                        + "<button class=\"btn btn-danger btn-remove\" type=\"button\" data-id=\"" + item.productId + "\"><i class=\"icon-remove icon-white\"></i></button>"
                        + "</div>"
                        + "</td>"

                        + "<td>" + numberWithCommas(item.price) + "</td>"
                        + "<td>" + numberWithCommas(amount) + "</td>"
                        + "</tr>";
                    total += amount;
                });
                $('#cart_body').html(html);
                $('#lbl_total').text(numberWithCommas(total));

            }
        });
                

  
            
    }
}
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}
