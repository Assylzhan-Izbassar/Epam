$(document).ready(function () {

    CallTagList();
    CallCategoryList();

    $('#tags_selecter').multiselect();

    //event when press to "Add Tag" button
    $("#saveData").click(function () {
        let data = $("#submit_form").serializeArray();
        $.ajax({
            type: "post",
            url: "/Tag/SaveTag",
            data: data,
            success: function (request) {
                $("#tag_model").modal("hide");
                $("#tags_selecter").empty();
                CallTagList();
            }
        });
    });

    //event when press to "Add Category" button
    $("#saveCategoryData").click(function () {
        let data = $("#submit_category_form").serializeArray();
        $.ajax({
            type: "post",
            url: "/Category/SaveCategory",
            data: data,
            success: function (request) {
                $("#category_model").modal("hide");
                $("#categories_selecter").empty();
                CallCategoryList();
            }
        });
    });

    //For calling category list using ajax
    function CallCategoryList() {
        $.ajax({
            type: "post",
            contentType: "application/json; charset=utf-8",
            url: "/Category/CategoryList",
            data: "{}",
            dataType: "json",
            success: function (result) {
                $.each(result, function (key, value) {
                    $("#categories_selecter").append($("<option></option>")
                        .val(value.categoryId).html(value.name));
                });
            },
            error: function (result) {
                alert("Error");
            }
        });
    }

    //For calling tag list using ajax
    function CallTagList() {
        $.ajax({
            type: "post",
            contentType: "application/json; charset=utf-8",
            url: "/Tag/TagList",
            data: "{}",
            dataType: "json",
            success: function (result) {
                $.each(result, function (key, value) {
                    $("#tags_selecter").append($("<option></option>")
                        .val(value.tagId).html(value.name));
                });
            },
            error: function (result) {
                alert("Error");
            }
        });
    }
});