using Topshelf;

namespace NginxService
{
	class Program
	{
		static int Main(string[] args)
		{
			var host = HostFactory.New(x =>
			{
				x.Service<NginxController>(s => 
				{
					s.ConstructUsing(name => new NginxController());
                    s.WhenStarted(tc => tc.Start());
					s.WhenStopped(tc => tc.Stop());
          s.WhenContinued(tc => { });
          s.WhenPaused(tc => tc.ReloadConfig());
				});
	
				x.RunAsNetworkService();
				x.StartAutomatically();

				x.SetDescription("Nginx web server");
				x.SetDisplayName("nginx");
				x.SetServiceName("nginx");
        x.EnablePauseAndContinue();
			});
		    return (int) host.Run();
		}	
	}
}
