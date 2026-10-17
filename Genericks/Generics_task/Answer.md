


## StudentStore vs CourseStore

What is the same ?

Both StudentStore and CourseStore use a List to store objects They have the same basic methods

 Add() ==> to add an item
GetById() ==> to find an item using its ID
GetAll() ==> to return all items
Remove() ==> to remove an item using its ID

What is different?

StudentStore works with Student objects which have an Id and a Name but CourseStore works with Course objects, which have an Id, a Title, and a Price

Most of the code in both classes is repeated. The main difference is the type of object each class stores


##  Why did the generic Store <T> fail to compile?

When I tried to access item.Id inside Store<T>, the compiler reported an error because it did not know that the generic type T had an Id property

A generic type can represent different types, and not every type has an Id property so The solution was to create an IHasId interface and constrain the generic type => where T : IHasId

This tells the compiler that every type used with Store<T> must implement IHasId and provide an Id property


##  Why must Store<string> not compile?

Store<T> has the constraint where T : IHasId

The string type does not implement IHasId so it cannot be used with Store<T>

For example => Store<string> invalidStore = new(); 

This restriction is useful because Store<T> depends on every item having an Id The compiler prevents us from using a type that does not meet this requirement


