# BusinessRuleEngine
Business Rule Engine
--------------------

Please set EventReceiver.csproj as Startup project if it is not set.

This rule engine is built based on Observer pattern.

Patyment Received is an event which needs to be observed by its appropriate observer to process the payment. 
Observers need to be subscribed to the publisher(PaymentReceived event) and unsubscibed after the event processed.



