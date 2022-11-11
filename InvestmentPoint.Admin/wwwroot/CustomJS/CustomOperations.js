///calculate the amounts Daily,Weekly,Monthly Basic
$(document).ready(function () {
    $("#TypeOfI").change(function () {
        var TypeId = $(this).val();
        var Amount = parseInt($('#MonthlyA').val());
        if (TypeId == 1) {
            var total1 = Amount / 30;
            $("#CollectionAmo").val(parseInt(total1));
        }
        if (TypeId == 2) {
            var ta1 = Amount / 4;
            //var total2 = ta1 * 7;
            $("#CollectionAmo").val(parseInt(ta1));
        }
        if (TypeId == 3) {

            var ta2 = Amount;
            //var total2 = ta2 * 30;
            $("#CollectionAmo").val((ta2));
        }
        if (TypeId == 4) {
            var ta3 = Amount / 12;
            //var total2 = ta2 * 30;
            $("#CollectionAmo").val((ta3));
        }
        if (TypeId == 5) {
            var ta3 = Amount / 6;
            //var total2 = ta2 * 30;
            $("#CollectionAmo").val((ta3));
        }
    })
})
