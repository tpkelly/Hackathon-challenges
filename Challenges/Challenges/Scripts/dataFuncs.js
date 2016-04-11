var DataFunctions = function() {
  var self = this;
  
  var joinedAnswer = function(data) { return data ? data.a + " and " + data.b : undefined; };
  var parseJoinedAnswer = function(data) {
    if (!data) return undefined;
    
    var splitData = data.split(" and ");
    
    return {a : splitData[0], b: splitData[1] };
  };
  
  var dataToString = function(data) {
    return JSON.stringify({
      'teamName': data.teamName,
      'q1a': data.q1a,
      'q1b': joinedAnswer(data.q1b),
      'q1c': joinedAnswer(data.q1c),
      'q1d': joinedAnswer(data.q1d),
      'q2': data.q2,
      'q3': data.q3,
      'q4': data.q4,
      'q5': data.q5,
      'q6a': data.q6a,
      'q6b': data.q6b,
      'q7a': data.q7a,
      'q7b': data.q7b
      });
  };
  
  var dataFromString = function(data) {
    var formData = JSON.parse(data);
    
    var parsed1B = parseJoinedAnswer(formData.q1b);
    var parsed1C = parseJoinedAnswer(formData.q1c);
    var parsed1D = parseJoinedAnswer(formData.q1d);

    if (parsed1B) formData['q1b'] = parsed1B;
    if (parsed1C) formData['q1c'] = parsed1C;
    if (parsed1D) formData['q1d'] = parsed1D;
    
    return formData;
  }

  var saveFormData = function(data) {
    localStorage.setItem("formData", dataToString(data));
  }
  
  var loadFormData = function() {
    var storedData = localStorage.getItem("formData");
    
    if (storedData === null) return {};
    
    return dataFromString(storedData);
  }
  
  return {
    dataToString: dataToString,
    dataFromString: dataFromString,
    saveFormData: saveFormData,
    loadFormData: loadFormData
  };
};
