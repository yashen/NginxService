using System;
using System.Diagnostics;

namespace NginxService
{
    public class NginxController
    {
        private NginxMasterProcess _nginxProcess;

        public void Start()
        {
            Stop();
            StartMasterProcess();
            AssertNginxWasStarted();
        }

        public void Stop()
        {
            if (_nginxProcess != null)
            {
                _nginxProcess.StopMasterProcess();
            }
        }

        private void StartMasterProcess()
        {
            _nginxProcess = new NginxMasterProcess();
            _nginxProcess.StartMasterProcess();
        }

        private void AssertNginxWasStarted()
        {
            Execute.UntilTrueOrTimeout(_nginxProcess.IsRunning, 10, TimeSpan.FromMilliseconds(250));
            if (!_nginxProcess.IsRunning())
            {
                throw new Exception("Failed to start the nginx process");
            }
        }

        public void ReloadConfig() {
          if (_nginxProcess != null) {
            _nginxProcess.ReloadConfig();
          }
        }
    }
}