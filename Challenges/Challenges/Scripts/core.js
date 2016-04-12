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

        $scope.$watch($scope.formData, function() {
            $scope.submitDisabled = ($scope.storedData == $scope.formData);
        }, true);

        $scope.onSubmit = function() {
            $scope.storedData = $scope.formData;
            dataFuncs.saveFormData($scope.formData);
            $scope.formData = dataFuncs.loadFormData();

            return $http({
                method: 'POST',
                url: '/api/submission',
                headers: { 'Content-Type': 'application/json' },
                data: $scope.formData
            });
        };
    }
})();
