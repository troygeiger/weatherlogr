(function () {
    var canvas = document.getElementById("TempChart");
    /**
     * @typedef {object} Observation
     * @property {Date} entryDate
     * @property {string} stationID
     * @property {number} temperature
     * @property {number} temperatureUOM
     */
    var chart = new Chart(canvas, {
        type: 'line',
        data: {},
        options: {

            scales: {
                yAxes: {

                },
                xAxes: {

                }
            },

        }
    });

    var station = $("#station").on("change", datesChanged);
    var startDate = $("#startDate").on("change", datesChanged);
    var endDate = $("#endDate").on("change", datesChanged);

    if (!startDate.val()) {
        startDate.val(new Date().addDays(-7).toShortDate());
    }
    if (!endDate.val()) {
        endDate.val(new Date().addDays(1).toShortDate());
    }

    datesChanged();
    function datesChanged() {
        chart.clear();
        var stationID = station.val();
        if (!stationID) return;
        var start = startDate.val();
        if (!start) return;
        var end = endDate.val();
        if (!end) return;

        $.getJSON("/Observations/GetStationObservations", { stationIdentifier: stationID, start: start, end: end },

            /**
             * 
             * @param {Observation[]} data 
             */
            function (data) {
                var final = [];
                var labels = [];
                for (let i = 0; i < data.length; i++) {
                    if (data[i].temperature === null)
                        continue;
                    //(Temperature * 9/5) + 32
                    final.push((data[i].temperature * 9 / 5) + 32);
                    //final.push(data[i].temperature);
                    labels.push(new Date(data[i].entryDate).toLocaleString());
                }
                chart.data = {
                    labels: labels,
                    datasets: [
                        {
                            label: "Temperature",
                            data: final,
                            xAxisID: 'xAxes',
                            yAxisID: 'yAxes'
                        }
                    ]
                };
                chart.update();
            });

    }



})();