(function() {
    angular
        .module('quiz', [])
        .controller('QuizController', QuizController);
    QuizController.$inject = ['$scope', '$http'];

    function QuizController($scope, $http) {
        var dataFuncs = DataFunctions();


        $scope.dayOptions = [
            'Monday',
            'Tuesday',
            'Wednesday',
            'Thursday',
            'Friday',
            'Saturday',
            'Sunday'
        ];

        $scope.storedData = {}
        $scope.formData = dataFuncs.loadFormData();

        $scope.submitDisabled = false;
        $scope.submitValue = "Submit";

        $scope.onSubmit = function () {
            $scope.submitDisabled = true;
            $scope.storedData = $scope.formData;
            dataFuncs.saveFormData($scope.formData);

            return $http({
                method: 'POST',
                url: '/api/submission',
                headers: { 'Content-Type': 'application/json' },
                data: dataFuncs.dataToString($scope.formData)
            }).then(function(response) {
                $scope.submitDisabled = false;
                $scope.submitValue = (response.status < 400) ? "Submitted" : "Submit failed";
            });
        };
    }
})();
