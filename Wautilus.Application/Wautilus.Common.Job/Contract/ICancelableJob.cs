namespace Wautilus.Common.Job
{

	public interface ICancelableJob : IJob
	{

		void Cancel ();

	}

}
