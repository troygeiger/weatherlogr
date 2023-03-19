(function () {
    $(".delete-station").on("click", function () {
        var val = $(this).attr("data-val");
        if (!val) return;
        if (!confirm("Are you sure you want to delete?")) return;

        $.post("/StationCollectors/DeleteStation", {stationIdentifier: val}, function(){
            window.location.reload();
        }).fail(function(e){
            alert("Delete failed! " + e.responseText);
        });
            
    });
})();