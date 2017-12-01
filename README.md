# PikaSmart
Smart House Web Application

## Short Description

PikaSmart provides the user a complete experience in knowing exactly what's happening in his own house. You have the option to add new sensors as you please, get push notifications and provide rules for the sensors that are in place. All to make you feel better and safer in your own home.

Some key features:

* know when your front door was opened and how many people got inside
* know the temperature inside and set it remotely
* create rules such as : alert me when door opens between 9am and 5pm, alert me when temperature drops suddenly
* gas detection service


## Team
* Vlad Cazacu
* Marius Ilau
* Ciprian Mutescu
* Alexandru Antochi
* Bogdan Matei
* Ionut Arhire

# Architecture

The application will be a default MVC type, using Angular. The rendering will be done on the client's side and the comomands from the client will be processed by the server and sent to the arduino board remotely. 

The database layer will use SQL Server. 

Technologies that will be used:

## Back-end:

- Autofac(better dependency injection than the default one for .net core)
- Automapper (easy and clean translation from DTO to entity and vice versa)
- Fluent Assertions (for clean code in tests)
- Ensure.That (for checks like: !null -> ensures cleaner code)
- Moq (mocking library, i worked with it and it’s all you need really)
- Fluent Validation? (only if we want to validate on the back-end, like in case of a form)
- Stylecop? (we could use stylecop to minimize the amount of refactoring we have to do because of style violation concerns. It’s really not mandatory in my opinion tho)

## Front-end:

- Angular 2 + Typescript ??? (just an idea, tho it would be nice in my opinion)
- Grid Layout ??? (i don’t know how compatible is with every browser of interest; it would be way easier to work with it tho than conventional html + css positioning)
- Sass or less (css preprocessing: having variables in css code + cleaner organization of classes)




