
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

        });

    }
}

var chart = new Chart();