﻿
class Chart {
    clickIncrement(btn) {
        let data = this.getData(btn);
        data.Quantity++;
        this.postQTDe(data);
    }

    clickDecrement(btn) {
        let data = this.getData(btn);
        data.Quantity--;
        this.postQTDe(data);

    }

    updateQtde(input) {
        let data = this.getData(input);
        this.postQTDe(data);
    }

    getData(element) {
        var linhadoItem = $(element).parents('[item-id]');
        var itemId = $(linhadoItem).attr('item-id');
        var newQTD = $(linhadoItem).find('input').val();

        return {
            Id: itemId,
            Quantity: newQTD
        };
    }

    postQTDe() {

        $.ajax({
            url: '/pedido/UpdateQTD',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)

        }).done(function (response) {
            let itemorder = responde.itemorder;
            let itemline = $('[item-id = ' + itemorder.Id + ']')
            itemline.find('input').val(itemorder.Quantity);
            itemline.find('[subtotal]').html((itemorder.subtotal).twozeros());

            let chartViewModel = response.chartViewModel;
            $('[itens-number]').html('Total: ' + chartViewModel.itens.legth + ' itens');

            $('[total]').html((carrinhoViewModel.total).twozeros());

            if (itemorder.Quantity == 0) {
                itemline.remove();
            }
        });

    }
}

var chart = new Chart();

Number.prototype.twozeros = function () {
    return this.toFixed(2).replace('.', ',');
}