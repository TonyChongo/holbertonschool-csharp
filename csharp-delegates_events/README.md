# C# - Delegates, Events

Developers that are new to the .NET Core platform often struggle when deciding between a design based on delegates and a design based on events. The choice of delegates or events is often difficult, because the two language features are similar. Events are even built using the language support for delegates.

They both offer a late binding scenario: they enable scenarios where a component communicates by calling a method that is only known at run time. They both support single and multiple subscriber methods. You may find this referred to as singlecast and multicast support. They both support similar syntax for adding and removing handlers. Finally, raising an event and calling a delegate use exactly the same method call syntax. They even both support the same Invoke() method syntax for use with the ?. operator.

