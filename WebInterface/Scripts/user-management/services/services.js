
app.service('userManagementService', ['$http', '$q', function ($http, $q) {

	function handleError(response) {

		if (!angular.isObject(response.data) || !response.data.ErrorCollection.Errors.length == 0) {
			return ($q.reject("An unknown error occurred."));

		}

		return ($q.reject(response.data.ErrorCollection.Errors));

	}

	function handleSuccess(response) {
		return (response.data);
	}

	this.GetUserDetail = function() {
		return $http.get("/api/user-management/user").then(handleSuccess, handleError);
	};

	this.UpdateUserDetail = function(data) {
		return $http.post("/api/user-management/user", data).then(handleSuccess, handleError);
	}
	
}]);

