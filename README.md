# Unit of Work and Unit Testing Design
This project is a clean architecture implementation of modelling the usage of repository pattern with unit of work. 
Then it shows how this pattern can be used with IoC and unit test using .NET 5.

## Resources and Libraries

- .NET 5


## Background
The drive behind this tutorial is to have a complete example on Repository and Unit of Work with IoC and Unit Testing. Adding IoC and Unit Testing will show how all these components/patterns can work together.

The idea of using the repository pattern is to create an abstract data access layer for your application. This will allow you to centralise all your data access logic in one place. Combined with generic feature you can reduce the amount of code you need for common scenarios and still have the ability to create custom repository for more specific usage.

The unit of work pattern helps to combine a set of interactions and commit them at once using a transaction. If you are creating your data source from scratch and you are using just one EF context you probably don't need the unit of work and you can depend on your data context however this is not always the case. For example you may want to use more than one EF context to complete your operations, that's where the unit of work comes in handy. Using the transaction facility in the unit of work will allow you to work with different contexts in the same scope without the fear of losing your data integrity if an exception was thrown while completing the data manipulation.

```bash
dotnet test
```  
