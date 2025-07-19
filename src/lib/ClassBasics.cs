using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src
{
	public record Persona
	{
		public int Age { get; set; }
		public string Name { get; set; }
	}

	public interface IObserver
	{
		public enum ObserverType
		{
			Created,
			Updated,
			Deleted
		}

		void Attatch<TClass, TObserver>(IObserver.ObserverType type, Action<TObserver> action);
		void Detach<TClass, TObserver>(ObserverType type);
		void Notify<TObserver>(IObserver.ObserverType type, TObserver obj);
	}

	public class Observer : IObserver
	{
		record ObserverItem
		{
			public Type Class { get; set; }
			public Type Observer { get; set; }
			public IObserver.ObserverType Type { get; set; }
		}

		record ObserverItemAction<T> : ObserverItem
		{
			public Action<T> Action { get; set; }
		}

		private readonly List<ObserverItem> _observers = new List<ObserverItem>();

		public void Attatch<TClass, TObserver>(IObserver.ObserverType type, Action<TObserver> action)
		{
			_observers.Add(new ObserverItemAction<TObserver> { Class = typeof(TClass), Observer = typeof(TObserver), Type = type, Action = action });
		}

		public void Detach<TClass, TObserver>(IObserver.ObserverType type)
		{
			_observers.RemoveAll(observer => observer.Class == typeof(TClass) && observer.Observer == typeof(TObserver) && observer.Type == type);
		}

		public void Notify<TObserver>(IObserver.ObserverType type, TObserver obj)
		{
			_observers.ForEach(observer =>
			{
				if(observer.Type == type && observer.Observer == typeof(TObserver))
				{
					var actionmObserver = observer as ObserverItemAction<TObserver>;

					actionmObserver.Action(obj);
				}
			});
		}
	}

	public record PhisicalPersona : Persona
	{
		public long Cpf { get; set; }
	}

	public interface IPersonaFactory
	{
		PhisicalPersona CreatePPhisicalPersona(int age, string name);
		Persona CreateOrGetSingletonPersona();
	}

	public class PersonaFactory : IPersonaFactory
	{
		public PhisicalPersona CreatePPhisicalPersona(int age, string name)
		{
			return new PhisicalPersona { Age = age, Name = name, Cpf = 11111111111 };
		}

		public Persona CreateOrGetSingletonPersona()
		{
			return Singleton<Persona>.GetObj();
		}
	}

	public sealed class Singleton<T> where T : class, new()
	{
		private Singleton() { }

		private static T obj;

		public static T GetObj()
		{
			if(obj == null)
			{
				obj = new T();
			}

			return obj;
		}
	}

	public interface IPersonaRepository
	{
		void CreatePersona(Persona persona);
	}

	public class PersonaRepository : IPersonaRepository
	{
		private readonly static List<Persona> Personas = new List<Persona>();

		public void CreatePersona(Persona persona)
		{
			Personas.Add(persona);
		}
	}

	public interface ICreatePersonaComponent
	{
		void Operation(int age, string name);
	}

	public class CreatePersonaComponent : ICreatePersonaComponent
	{
		private readonly IPersonaFactory _factory;
		private readonly IPersonaRepository _repository;
		private readonly IObserver _observer;

		public CreatePersonaComponent(IPersonaFactory factory, IPersonaRepository repository, IObserver observer)
		{
			_factory = factory;
			_repository = repository;
			_observer = observer;
		}

		public void Operation(int age, string name)
		{
			var persona = _factory.CreatePPhisicalPersona(age, name);

			_repository.CreatePersona(persona);
			_observer.Notify<Persona>(IObserver.ObserverType.Created, persona);
		}
	}

	public class CreatePersonaDecorator : ICreatePersonaComponent
	{
		private readonly ICreatePersonaComponent _component;

		public CreatePersonaDecorator(ICreatePersonaComponent component)
		{
			_component = component;
		}

		public void Operation(int age, string name)
		{
			if(age <= 0 || string.IsNullOrEmpty(name))
				return;

			_component.Operation(age, name);
		}
	}
}