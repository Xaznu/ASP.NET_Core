using System;
using System.Threading.Tasks;
using Evento.Core.Domain;

namespace Evento.Core.Repositories
{

	public class EventRepository : IEventRepository
	{
		private static readonly ISet<Event> _events = new HashSet<Event>();


		public async Task GetAsync(Guid id)
		=> await Task.FromResult(_events.SingleOrDefault(x => x.Id == id));


		public async Task GetAsync(string name)
	   => await Task.FromResult(_events.SingleOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant()));

		public async Task<IEnumerable<Event>> BrowseAsync(string name = "")
		{
			var events = events.AsEnumerable();
			if (!string.IsNullOrWhiteSpace(name))
			{
				events = events.Where(x => x.Name.ToLowerInvariant()
				.Contains(name.ToLowerInvariant()));
			}
			return await Task.FromResult(events);
		}

		public async Task AddSync(Event @event)
		{
			_events.Add(@event);
			await Task.CompletedTask;
		}

		public async Task UpdateAsync(Event @event)
		{
			await Task.CompletedTask;
		}

		public async Task DeleteAsync(Event @event)
		{
			_events.Remove(@event);
			await Task.CompletedTask;
		}
	}
}