!function(){var a=document.getElementById("TempChart"),e=new Chart(a,{type:"line",data:{},options:{scales:{yAxes:{},xAxes:{}}}}),t=$("#station").on("change",s),n=$("#startDate").on("change",s),r=$("#endDate").on("change",s);function s(){e.clear();var a=t.val();if(a){var s=n.val();if(s){var o=r.val();o&&$.getJSON("/Observations/GetStationObservations",{stationIdentifier:a,start:s,end:o},(function(a){var t=[],n=[];for(let e=0;e<a.length;e++)null!==a[e].temperature&&(t.push(9*a[e].temperature/5+32),n.push(new Date(a[e].entryDate).toLocaleString()));e.data={labels:n,datasets:[{label:"Temperature",data:t,xAxisID:"xAxes",yAxisID:"yAxes"}]},e.update()}))}}}n.val()||n.val((new Date).addDays(-7).toShortDate()),r.val()||r.val((new Date).addDays(1).toShortDate()),s()}();