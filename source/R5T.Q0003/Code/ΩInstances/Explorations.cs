using System;


namespace R5T.Q0003
{
	public class Explorations : IExplorations
	{
		#region Infrastructure

	    public static IExplorations Instance { get; } = new Explorations();

	    private Explorations()
	    {
        }

	    #endregion
	}
}


namespace R5T.Q0003.Raw
{
    public class Explorations : IExplorations
    {
        #region Infrastructure

        public static IExplorations Instance { get; } = new Explorations();

        private Explorations()
        {
        }

        #endregion
    }
}