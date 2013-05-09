using System.Diagnostics;

namespace NginxService
{
    public class NginxSignalProcess
    {
        private readonly NginxExeLocator _nginxExeLocator = new NginxExeLocator();

        public void SendShutdownCommand()
        {
            SendSignalToMasterProcess("stop");
        }

        private void SendSignalToMasterProcess(string signal)
        {
            var signalProcess = new Process();
            signalProcess.StartInfo.FileName = _nginxExeLocator.GetNginxExePath();
            signalProcess.StartInfo.Arguments = "-s " + signal;
            signalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            signalProcess.Start();
            signalProcess.WaitForExit(10000);
        }
    }
}