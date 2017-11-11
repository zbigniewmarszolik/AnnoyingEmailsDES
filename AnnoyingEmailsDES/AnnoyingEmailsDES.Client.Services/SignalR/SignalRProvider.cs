using Microsoft.AspNet.SignalR.Client;
using System;

namespace AnnoyingEmailsDES.Client.Services.SignalR
{
    /*
     * SignalR provider singleton.
     */
    public class SignalRProvider
    {
        public IHubProxy Proxy { get; }

        private readonly HubConnection _hubConnection;

        private static SignalRProvider _provider;

        public static SignalRProvider Instance
        {
            get
            {
                _provider = new SignalRProvider("MailSimulatorHub");

                return _provider;
            }
        }

        private SignalRProvider(string hubName)
        {
            _hubConnection = new HubConnection("http://localhost:8080");

            Proxy = _hubConnection.CreateHubProxy(hubName);
        }

        public async void Invoke(string method, params object[] obj)
        {
            try
            {
                await _hubConnection.Start();

                await Proxy.Invoke(method, obj);
            }
            catch (Exception e)
            {

            }
        }

        public async void Invoke(string method)
        {
            try
            {
                await _hubConnection.Start();

                await Proxy.Invoke(method);
            }
            catch (Exception e)
            {

            }
        }
    }
}
