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

                        if ($("#txtOccpCount").val() === "50" || $("#txtOccpCount").val() === "30" || $("#txtOccpCount").val() === "20") {
                            $("#lblStatus").show();
                        }
                        else {
                            $("#lblStatus").hide();
                        }   
                    }
                },
                error: function (res) {
                    alert("Error Occured");
                }
            });

        });

        $("#btnAddVechicle").click(function () {

            if ($("#VechicleType :selected").val() !== "0" && $("#VechicleName :selected").val() !== "0") {

                AddRemoveVechiles("Add");

            }
            else {
                alert("Please Select Vechicle Type And Vechicle Name");
            }
        });

        $("#btnRemoveVechicle").click(function () {

            if ($("#VechicleType :selected").val() !== "0" && $("#VechicleName :selected").val() !== "0") {

                AddRemoveVechiles("Remove");

            }
            else {
                alert("Please Select Vechicle Type And Vechicle Name");
            }
        });

        $("#tdCat").click(function () {

            $("#td1").show();
            $("#td2").show();
            $("#td3").show();
            $("#td4").show();

        });

        $("#btnAddVCat").click(function () {

            $.ajax({
                url: options.AddVechiclesCategoryURL + "?VechicleType=" + $("#txtVCat").val() + "&VechicleName=" + $("#txtVName").val() + "&SlotSize=" + $("#txtSlot").val(),
                type: "POST",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (res, status) {
                    if (status === "success") {
                        alert("Categoty Added Sucessfuly");
                        $("#td1").hide();
                        $("#td2").hide();
                        $("#td3").hide();
                        $("#td4").hide();

                        window.location.href = options.VechicleURL;
                    }
                },
                error: function (res) {
                    alert("Error Occured");
                }
            });

        });
    };

    function AddRemoveVechiles(ActionName) {

        $.ajax({
            url: options.AddRemoveVechiclesURL + "?VechicleId=" + $("#VechicleType :selected").val() + "&VechicleType=" + $("#VechicleType :selected").text() + "&ActionName=" + ActionName,
            type: "POST",
            dataType: "JSON",
            contentType: "application/json;charset=utf-8",
            success: function (res, status) {
                if (status === "success") {
                    
                    var VId = $("#txtOccpCount").val() === "50" ? 2 : $("#txtOccpCount").val() === "30" ? 3 : 1;                    
                    alert("Vechicle " + ActionName + "ed To Parking Slot");

                    $("#txtOccpCount").val(res.OccupCnt);
                    $("#txtAvailCount").val(res.AvailCnt);

                   

                    //if (ActionName === "Add" ) {
                    //    $("#VechicleType option[value=" + VId + "]").prop('selected', true);

                    //    $("#VechicleType").trigger("change");
                    //}                   
                    $("#txtOccpCount").css('border-color', 'red');
                    $("#txtAvailCount").css('border-color', 'red');

                    if ($("#txtOccpCount").val() === "50" || $("#txtOccpCount").val() === "30" || $("#txtOccpCount").val() === "20") {
                        $("#lblStatus").show();
                    }
                    else {
                        $("#lblStatus").hide();
                    }
                }
            },
            error: function (res) {
                alert("Error Occured");
            }
        });

    }

})(ParkingMang);



