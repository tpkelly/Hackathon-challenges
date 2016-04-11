(function() {
  angular
    .module('quiz', [])
    .controller('QuizController', QuizController);
  
  var socketHost = 'ws://additional-funds.herokuapp.com';
  //var socketHost = 'ws://localhost:5000';
  QuizController.$inject = ['$scope'];
  
  function QuizController($scope) {
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
    
    var ws = new WebSocket(socketHost);
    ws.onopen = function() {
        var data = dataFuncs.dataToString($scope.formData);
        ws.send(data);
      ws.close();
    }
  };
  }
})();
