using System;
using Microsoft.Extensions.DependencyInjection;
using src;

//configurar dependencias
var collection = new ServiceCollection();

collection.AddSingleton<IObserver, Observer>();
collection.AddTransient<IPersonaFactory, PersonaFactory>();
collection.AddTransient<IPersonaRepository, PersonaRepository>();
collection.AddTransient<ICreatePersonaComponent, CreatePersonaComponent>();
collection.AddTransient<CreatePersonaDecorator>();

var provider = collection.BuildServiceProvider();

//criar evento de criação de pessoa
var observer = provider.GetService<IObserver>();

observer.Attatch<Program, Persona>(IObserver.ObserverType.Created, persona => Console.WriteLine($"Persona - {persona.Name} created with Age - {persona.Age}"));

//criar pessoa
var decorator = provider.GetService<CreatePersonaDecorator>();

decorator.Operation(33, "Marvin");
decorator.Operation(34, "Nivram");
decorator.Operation(35, "Thomaz");
decorator.Operation(36, "Nascimento");