using System;
using System.Threading.Tasks;
using Evento.Core.Domain;

namespace Evento.Core.Repositories
{

public interface IEventRepository
{
		Task<Event> GetAsync(Guid id);
		Task<Event> GetAsync(string name);
		Task<Enumerable<Event>> BrowseSync(string name = "");
		Task GetAsync(Event @event);
		Task UpdateAsync((Event @event);
		Task DeleteAsync(Event @event);

	}
}
