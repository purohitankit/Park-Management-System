ParkingMang = window.ParkingMang || {};

(function (namespace) {
    namespace.ParkingManagement = ParkingManagement;
    var proto = ParkingManagement.prototype;
    var options;
    function ParkingManagement(para) {
        options = para;
    };

    proto.BindDataAndEvents = function () {
        $("#VechicleType").change(function () {

            if ($("#VechicleType").val() === "0") {
                $("#txtOccpCount").val("");
                $("#txtAvailCount").val("");
            }
            $.ajax({
                url: options.GetVechileNamesURL + "?VechicleId=" + $("#VechicleType").val(),
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (res, status) {
                    if (status === "success") {
                        var obj = JSON.parse(res);
                        $("#VechicleName option").remove();
                        $("#VechicleName").append($("<option></option>").val("0").html("--Select--"));
                        $.each(obj.Table1, function (index, value) {
                            $("#VechicleName").append($("<option></option>").val(value.VId).html(value.VechicleName));
                        });
                        if (obj.Table2.length > 0) {
                            $("#txtOccpCount").val(obj.Table2[0].OccupiedCount);
                            $("#txtAvailCount").val(obj.Table2[0].AvailableCount);
                        }
                        $("#VechicleName").css('border-color', 'red');
                        $("#txtOccpCount").css('border-color', 'red');
                        $("#txtAvailCount").css('border-color', 'red');
                    }
                },
                error: function (res) {
                    alert("Error Occured");
                }
            });

        });

        $("#btnAddVechicle").click(function () {

            if ($("#VechicleType :selected").val() !== "0" && $("#VechicleName :selected").val() !== "0") {

                $.ajax({
                    url: options.AddRemoveVechiclesURL + "?VechicleId=" + $("#VechicleType :selected").val() + "&VechicleType="+$("#VechicleType :selected").text()+"&ActionName=Add",
                    type: "POST",
                    dataType: "JSON",
                    contentType: "application/json;charset=utf-8",
                    success: function (res, status) {                                                                                                               
                        if (res.res === "1") {
                            alert("Vechicle Added To " + $("#VechicleType :selected").text() + " Parking Slot");

                            $("#txtOccpCount").val(res.OccupCnt);
                            $("#txtAvailCount").val(res.AvailCnt);

                            $("#txtOccpCount").css('border-color', 'red');
                            $("#txtAvailCount").css('border-color', 'red');
                        }
                    },
                    error: function (res) {
                        alert("Error Occured");
                    }
                });

            }
            else {
                alert("Please Select Vechicle Type And Vechicle Name");
            }

        });

        $("#btnAddVechicle").click(function () { });
    };

})(ParkingMang);



