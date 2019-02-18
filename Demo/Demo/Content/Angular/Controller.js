app.controller("myCntrl", function ($scope, angularService) {
    $scope.calculations = [];
    $scope.calculation = { StartDate1: new Date(), StartDate2: new Date(), EndDate1: new Date(), EndDate2: new Date() };

    //To Get Data  
    $scope.getAllData = function GetCalculation() {
        var getData = angularService.getData();
        getData.then(function (calc) {
            $scope.calculations = calc.data;

            $scope.calculations.forEach((c) => {
                c.StartDate1 = c.StartDate1 ? new Date(parseInt(c.StartDate1.substr(6))) : '';
                c.EndDate1 = c.EndDate1 ? new Date(parseInt(c.EndDate1.substr(6))) : '';
                c.StartDate2 = c.StartDate2 ? new Date(parseInt(c.StartDate2.substr(6))) : '';
                c.EndDate2 = c.EndDate2 ? new Date(parseInt(c.EndDate2.substr(6))) : '';
                c.Overlap_StartDate = c.Overlap_StartDate ? new Date(parseInt(c.Overlap_StartDate.substr(6))) : '';
                c.Overlap_EndDate = c.Overlap_EndDate ? new Date(parseInt(c.Overlap_EndDate.substr(6))) : '';
                c.CreateDate = c.CreateDate ? new Date(parseInt(c.CreateDate.substr(6))) : '';
            });
        }, function () {
            alert('Error in getting data');
        });
    }

    $scope.save = function () {
        if ($scope.calculation.StartDate1 && $scope.calculation.StartDate2 && $scope.calculation.EndDate1 && $scope.calculation.EndDate2) {
            var saveData = angularService.Save($scope.calculation);
            saveData.then(function (calc) {
                alert('Data saved successfully.');
                $scope.calculation = {};
            }, function () {
                alert('Error in getting records');
            });
        }
        else {
            alert('Please fill all dates.');
        }
    }

    $scope.calculateOverlap = function () {
        if ($scope.calculation.StartDate1 && $scope.calculation.StartDate2 && $scope.calculation.EndDate1 && $scope.calculation.EndDate2) {
            var getData = angularService.Calculate($scope.calculation);
            getData.then(function (res) {
                $scope.calculation.Overlap_StartDate = res.data.Overlap_StartDate ? new Date(res.data.Overlap_StartDate) : '';
                $scope.calculation.Overlap_EndDate = res.data.Overlap_EndDate ? new Date(res.data.Overlap_EndDate) : '';
                $scope.calculation.IsOverlap = res.data.IsOverlap;
            }, function () {
                alert('Error in Calculation');
            });
        }
        else {
            alert('Please fill all dates.');
        }
    }
});