﻿$(document).ready(function () {
    //document ready
    $("#datatable").dataTable();

    //tinymce.init({
    //    selector: '.tinymce',
    //    height: 500,
    //    menubar: false,

    //    toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
    //    content_css: [
    //      '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
    //      '//www.tinymce.com/css/codepen.min.css'
    //    ]
    //});


    //$('.datetimepicker').datetimepicker();

    ////console.log("HEHE " + $ssc);
    //var $historyPage = $("#past-history-controller");
    //console.log($historyPage);
    //if ($historyPage.length > 0) {

    //    $("#save-btn").on("click", function (e) {
    //        var $table = $historyPage.find("table");
    //        var $message = "Messages will be sent to:<br/>";
    //        var $header = "Beverage Payment Confirmation";
    //        var $numberOfSelectedEmployee = 0;
    //        var $tr = $table.find("tr");
    //        var $ids = "";
    //        var $checkBoxes = $tr.find(".employee-select");
    //        for (var i = 0; i < $checkBoxes.length; i++) {
    //            var $checkbox = $($checkBoxes[i]);
    //            if ($checkbox.is(":checked")) {
    //                $message = $message + "<li>" + $checkbox.attr("data-employeeName") + "</li>";
    //                $numberOfSelectedEmployee++;
    //                if ($ids == "") {
    //                    $ids = $checkbox.attr("data-id");
    //                } else {
    //                    $ids = $ids + "," + $checkbox.attr("data-id");
    //                }
    //            }
    //        }
    //        if ($numberOfSelectedEmployee === 0) {
    //            $message = "No employees has been selected";
    //            $header = "Attention";
    //        }
    //        var dated = $(".datetimepicker").find("input").val();
    //        $("#dated").attr("value", dated);
    //        $(".modal-title").html($header);
    //        $("#employee-display-list").html($message);
    //        console.log($message);
    //        $("#employeeIds").attr("value", $ids);

    //        e.preventDefault();
    //    });
    //}

    //var $historyByDate = $("#history-filtered-by-date");
    //if ($historyByDate.length > 0) {
    //    var $totalChange = 0;
    //    $("#datetimepicker1")
    //        .on("dp.change",
    //            function () {
    //                console.log($totalChange);
    //                if ($totalChange != 0) {
    //                    var dated = $("#datetimepicker1").find("input").val();
    //                    var location = window.location;
    //                    var hostName = location.host;
    //                    var path = location.pathname;
    //                    var url = "http://" + hostName + path;

    //                    $totalChange = $totalChange + 1;
    //                    location.href = url + "?dated=" + dated;
    //                } else {
    //                    $totalChange++;
    //                }
    //            });
    //}
});


