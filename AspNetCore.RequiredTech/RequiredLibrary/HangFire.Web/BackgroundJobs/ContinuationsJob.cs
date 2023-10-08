using System.Diagnostics;

namespace HangFire.Web.BackgroundJobs
{
    public class ContinuationsJob
    {
        public static void WriteWatermarkStatusJob(string id, string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{fileName} : resim'e watermark eklenmiştir"));
        }
    }
}