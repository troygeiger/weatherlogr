(function () {
    

    var stateElement = $("#State");
    
    var stationName = $("#StationName");
    var timezone = $("#TimeZone");

    var addBtn = $("#AddButton");
    var stationLookup = $("#StationIdentifier").lookup({
        data: {
            url: "/StationCollectors/LookupStations",
            parameterAction: function () {
                return { state: stateElement.val() }
            }
        },
        onSelectionChanged: function (value, opt) {
            if (value) {
                stationName.val(value.name);
                timezone.val(value.timeZone);
                addBtn.removeAttr("disabled");
            }
            else {
                stationName.val("");
                timezone.val("");
                addBtn.attr("disabled", "");
            }
        },
        beforeLookup: function (opt) {
            return stateElement.val() !== "";
        }
    });
})();