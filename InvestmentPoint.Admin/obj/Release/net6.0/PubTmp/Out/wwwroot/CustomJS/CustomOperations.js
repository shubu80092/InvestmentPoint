///calculate the amounts Daily,Weekly,Monthly Basic
$(document).ready(function () {
    $("#TypeOfI").change(function () {
        var TypeId = $(this).val();
        var Amount = parseInt($('#MonthlyA').val());
        if (TypeId == 1) {
            var total1 = Amount / 365;
            $("#CollectionAmo").val(parseFloat(total1).toFixed(2));
        }
        if (TypeId == 2) {
            var ta1 = Amount / 52.15;
            //var total2 = ta1 * 7;
            $("#CollectionAmo").val(parseFloat(ta1).toFixed(2));
        }
        if (TypeId == 3) {

            var ta2 = Amount / 12;
            //var total2 = ta2 * 30;
            $("#CollectionAmo").val(parseFloat(ta2).toFixed(2));
        }
        if (TypeId == 4) {

            var ta3 = Amount;
            //var total2 = ta2 * 30;
            $("#CollectionAmo").val(parseFloat(ta3).toFixed(2));
        }
    })
})
