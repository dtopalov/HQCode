namespace CodeFormattingHomework
{
	using System;
	using System.Text;

	public static class Messages
	{
		private static StringBuilder s_output = new StringBuilder();

		public static StringBuilder Output
		{
			get { return s_output; }
		}

		public static void EventAdded()
		{
			s_output.Append("Event added\n");
		}

		public static void EventDeleted(int x)
		{
			if (x == 0)
			{
				NoEventsFound();
			}
			else
			{
				s_output.AppendFormat("{0} events deleted\n", x);
			}
		}

		public static void NoEventsFound()
		{
			s_output.Append("No events found\n");
		}

		public static void PrintEvent(Event eventToPrint)
		{
			if (eventToPrint != null)
			{
				s_output.Append(eventToPrint + "\n");
			}
		}

		internal static void PrintEvent(object eventToShow)
		{
			throw new NotImplementedException();
		}
	}
}
