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
                        $.each(obj, function (index, value) {
                            $("#VechicleName").append($("<option></option>").val(value.VId).html(value.VechicleName));
                        });
                    }
                },
                error: function (res) {
                    alert("Error Occured");
                }
            });

        });
    };

})(ParkingMang);



