﻿var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/GetListProductByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<a>" + item.label + "</a>")
                .appendTo(ul);
        };

        //$("#txtKeyword").autocomplete({
        //    minLength: 0,
        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/Product/GetListProductByName",
        //            dataType: "json",
        //            data: {
        //                keyword: request.term
        //            },
        //            success: function (res) {
        //                response(res.data);
        //            }
        //        });
        //    },
        //    minLength: 1,
        //    select: function (event, ui) {
        //        log(ui.item ? "Selected: " + ui.item.label : "Nothing selected, input was: " + this.value)
        //    },
        //    open: function () {
        //        $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        //    },
        //    close: function () {
        //        $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        //    }
        //});
    }
}

common.init();