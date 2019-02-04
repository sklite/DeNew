$(document).ready(function () {


    this.RemoveArticle = function(articleId) {
        console.log("RemoveArticle button clicked " + articleId);

        var serializedData = {
            pageId: articleId
        };
        request = $.ajax({
            url: "/admin/delete",
            type: "post",
            data: serializedData,
            success: function (response) {
                alert(response.message);
                if (response.deleted) {
                    location.reload();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }

    //А можно ещё вот так:
    /*
    $(function() {
      $("#button").click( function()
           {
             alert('button clicked');
           }
      );
    });

    */

    $("#clickMe").click(function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        $("#Content").load(url);
    });


    var catSelector = $("#categorySelector");
    catSelector.append("<option value=\"" + GLOBAL_SETTINGS.ADD_NEW_IND + "\">Добавить новую категорию</option>");

    var subcatSelector = $("#subCategorySelector");


    var loadArticle = function() {
        if (catSelector.val() < 0 && subcatSelector.val() < 0) {
            return;
        }

        var loadAddress = window.location.protocol + "//" + window.location.host + "/administrator/loadarticle/?catId=" + catSelector.val() + "&subcatId=" + subcatSelector.val();

        var articleNameTextbox = $("#articleName");
        var articleTextArea = $("#articleText");
        var articleDescription = $("#descriptionEditor");
        var articleDeleted = $('#deleteArticle');
        var articleMetaDesc = $('#metaDesc');
        var articleMetaKeywords = $('#metaKeywords');

        $.getJSON(loadAddress, {},
            function(resultData) {
                articleNameTextbox.val(resultData.Name);
                articleDescription.val(resultData.Description);
                articleTextArea.data("kendoEditor").value(resultData.Content);
                articleDeleted.prop('checked', resultData.IsDeleted);
                $('#imgPreview').attr("src", "/Images/Preview/" + resultData.ImageName);
                $('#imageName').val(resultData.ImageName);
                articleMetaDesc.val(resultData.MetaDescription);
                articleMetaKeywords.val(resultData.Keywords);

                if (articleDeleted === true) {
                    articleNameTextbox.prop('disabled', true);
                    articleTextArea.prop('disabled', true);
                    articleDescription.prop('disabled', true);
                    articleDescription.val('Статья скоро будет удалена');
                    articleMetaDesc.prop('disabled', true);
                    articleMetaKeywords.prop('disabled', true);
                } else {
                    articleNameTextbox.prop('disabled', false);
                    articleTextArea.prop('disabled', false);
                    articleDescription.prop('disabled', false);
                    articleMetaDesc.prop('disabled', false);
                    articleMetaKeywords.prop('disabled', false);
                }
            }
        );
    }


    this.catChanged = function () {


        if (catSelector.val() == GLOBAL_SETTINGS.ADD_NEW_IND) {
            subcatSelector.val(GLOBAL_SETTINGS.SELECT_IND);
            subcatSelector.prop("disabled", true);
            $("#articleName").val("");
            $('#descriptionEditor').val("");
            $('#imgPreview').attr("src", "/Images/Preview/AddImage.jpg");
            $('#imageName').val("AddImage.jpg");


            return;
        }


        subcatSelector.prop("disabled", false);
        $.getJSON(window.location.protocol + "//" + window.location.host + "/administrator/subcategories/?categoryId=" + catSelector.val(), {},
            function (adminViewModel) {
                subcatSelector.empty();
                subcatSelector.append("<option value=\"" + GLOBAL_SETTINGS.SELECT_IND + "\">Выбери раздел</option>");
                for (var i = 0; i < adminViewModel.SubcatId.length; i++) {
                    subcatSelector.append("<option value=\"" + adminViewModel.SubcatId[i]
                        + "\">" + adminViewModel.SubcatName[i] + "</option>");
                }
                subcatSelector.append("<option value=\"" + GLOBAL_SETTINGS.ADD_NEW_IND + "\">Добавить новый</option>");
            }
        ); 

        loadArticle();
    }

    catSelector.change(this.catChanged);
    catSelector.ready(this.catChanged);

    this.subcatChanged = function() {
        if (subcatSelector.val() == GLOBAL_SETTINGS.SELECT_IND) {
            return;
        }
        if (subcatSelector.val() == GLOBAL_SETTINGS.ADD_NEW_IND) {
            $("#articleName").val("");
            $('#descriptionEditor').val("");
            $('#imgPreview').attr("src", "/Images/Preview/AddImage.jpg");
            $('#imageName').val("AddImage.jpg");
            return;
        }

        loadArticle();
    }


    subcatSelector.change(this.subcatChanged);
    subcatSelector.ready(this.subcatChanged);


    var deleteButton = $("deleteArticleButton");


    deleteButton.click(function() {

        }
    );

});


function deleteCurrentArticle() {
    alert("delete button clicked");
}

function onSuccess(e) {

    var loadAddress = window.location.protocol + "//" + window.location.host + "/administrator/getcurimage/";

    $.getJSON(loadAddress, {},
        function (resultData) {

            $('#imgPreview').attr("src", "/Images/Preview/" + resultData.Name);
            $('#imageName').val(resultData.Name);
        }
    );

}




