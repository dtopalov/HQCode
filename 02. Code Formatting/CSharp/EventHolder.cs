namespace CodeFormattingHomework
{
	using System;
	using Wintellect.PowerCollections;

	public class EventHolder
	{
		private MultiDictionary<string, Event> m_byTitle = new MultiDictionary<string, Event>(true);
		private OrderedBag<Event> m_byDate = new OrderedBag<Event>();

		public void AddEvent(DateTime date, string title, string location)
		{
			Event newEvent = new Event(date, title, location);
			this.m_byTitle.Add(title.ToLower(), newEvent);
			this.m_byDate.Add(newEvent);
			Messages.EventAdded();
		}

		public void DeleteEvents(string titleToDelete)
		{
			string title = titleToDelete.ToLower();
			int removed = 0;

			foreach (var eventToRemove in this.m_byTitle[title])
			{
				removed++;
				this.m_byDate.Remove(eventToRemove);
			}

			this.m_byTitle.Remove(title);
			Messages.EventDeleted(removed);
		}

		public void ListEvents(DateTime date, int count)
		{
			OrderedBag<Event>.View eventsToShow = this.m_byDate.RangeFrom(
																		new Event(date, string.Empty, string.Empty),
																		true);
			int showed = 0;
			foreach (var eventToShow in eventsToShow)
			{
				if (showed == count)
				{
					break;
				}

				Messages.PrintEvent(eventToShow);
				showed++;
			}

			if (showed == 0)
			{
				Messages.NoEventsFound();
			}
		}
	}
}
