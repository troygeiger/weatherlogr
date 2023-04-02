Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
};

Date.prototype.toShortDate = function () {
    var thisDate = new Date(this.valueOf());

    var day = ("0" + thisDate.getDate()).slice(-2);
    var month = ("0" + (thisDate.getMonth() + 1)).slice(-2);

    return thisDate.getFullYear() + "-" + (month) + "-" + (day);
};