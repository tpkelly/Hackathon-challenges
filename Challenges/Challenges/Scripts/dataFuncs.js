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
        'TeamName': data.teamName,
        'Answers': [
            { QuestionId: 1, Value: data.q1a },
            { QuestionId: 2, Value: joinedAnswer(data.q1b) },
            { QuestionId: 3, Value: joinedAnswer(data.q1c) },
            { QuestionId: 4, Value: joinedAnswer(data.q1d) },
            { QuestionId: 5, Value: data.q2 },
            { QuestionId: 6, Value: data.q3 },
            { QuestionId: 7, Value: data.q4 },
            { QuestionId: 8, Value: data.q5 },
            { QuestionId: 9, Value: data.q6a },
            { QuestionId: 10, Value: data.q6b },
            { QuestionId: 11, Value: data.q7a },
            { QuestionId: 12, Value: data.q7b }
        ]
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
    localStorage.setItem("formData", JSON.stringify(data));
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
