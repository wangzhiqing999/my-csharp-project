

$(document).ready(function () {

    $(".PageInfo").click(function () {
        var vPageNo = $(this).attr("title");
        $("#pageNo").val(vPageNo);
        document.forms[0].submit();

        return false;
    });


    $("#ddlPageSize").change(function () {
        var vPageSize = $(this).val();
        $("#pageSize").val(vPageSize);
        document.forms[0].submit();
    });


    $("#btnQuery").click(function () {
        $("#pageNo").val("1");
    });

});
