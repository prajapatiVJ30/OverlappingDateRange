app.service("angularService", function ($http) {

    //get Data
    this.getData = function () {
        return $http.get("Home/GetData");
    };

    // Save calculation
    this.Save = function (calculation) {
        var response = $http({
            method: "post",
            url: "Home/save",
            data: JSON.stringify(calculation),
            dataType: "json"
        });
        return response;
    }

    // Calculate
    this.Calculate = function (calculation) {
        var response = $http({
            method: "post",
            url: "Home/CalculateOverlap",
            data: JSON.stringify(calculation),
            dataType: "json"
        });
        return response;
    }
});