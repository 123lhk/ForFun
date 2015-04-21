app.controller('detailController', ['$scope', 'userManagementService', 'utilityService', function ($scope, userManagementService, utilityService) {
	$scope.user = {};
	$scope.dobOpened = false;
	$scope.alerts = [];

	$scope.modeEnum = {
		none: 0,
		editDetail: 1
	};

	$scope.mode = $scope.modeEnum.none;
	$scope.dateFormat = "yyyy-MM-dd"; 

	var response = userManagementService.GetUserDetail();

	response.then(
		function(data) {
			$scope.user = data;
		},
		function( errorMessage ) {
			alert(JSON.stringify(errorMessage));
        }
    );

	$scope.setNoneMode = function() {
		$scope.mode = $scope.modeEnum.none;
	}

	$scope.setEditDetailMode = function() {
		$scope.mode = $scope.modeEnum.editDetail;
	}

	$scope.open = function ($event) {
		$event.preventDefault();
		$event.stopPropagation();

		$scope.dobOpened = true;
	};

	$scope.saveUserDetail = function ($event)
	{
		$event.preventDefault();
		$event.stopPropagation();

		var response = userManagementService.UpdateUserDetail($scope.user);

		response.then(
			function (data) {
				$scope.user = data;
				var alerts = utilityService.constructAlerts(['User detail updated.'], 'info');
				utilityService.pushArray($scope.alerts, alerts);
			},
			function (errorMessages) {
				var alerts = utilityService.constructAlerts(errorMessages, 'danger');
				utilityService.pushArray($scope.alerts, alerts);
			}
		);
	}

	$scope.closeAlert = function (index) {
		$scope.alerts.splice(index, 1);
	};

}]);
