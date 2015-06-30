namespace Minesweeper
{
	public class Points
	{
	    public Points(string name, int points)
		{
			this.UserName = name;
			this.UserPoints = points;
		}

		public string UserName { get; set; }

	    public int UserPoints { get; set; }
	}
}