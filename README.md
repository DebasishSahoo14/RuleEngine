# RuleEngine
The project is developed in .net core and is a console application.So that it can be tested on both Linux and Windows environment.
When application starts:-
It will ask to enter Signal,
Signal related to datatype will be returned.
Then it will ask for Rule and we can set the rule.
The data violating the rule will be returned.


The rules validation class does all the work.After entering Signal it finds out the dataType and based on our input rule, it filtes data which violates the rule.

More improvement could have been done on structuring of Project.I could have developed using Service/Repository patterns.
