using IOT.Philips.WebAPI.Models;
using IOT.Repository;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IOT.Philips.WebAPI.Controllers
{
    public class LightController : ApiController
    {
        IOTDBContext db = new IOTDBContext();
        private const string BRIDGE_IP = "192.168.20.106";///"192.168.1.225";//"192.168.0.8";// "192.168.0.1";
        private const string APP_ID = "hb7b215e002b8b8f";// "1d0de40d14861c71a21c0c923d8a9e3";//"001788fffe7b215e";
    
        //command keys for queue
        private const string ON_OFF = "ON_OFF";
        //private const string BRIGHTNESS = "BRIGHTNESS";
        //private const string COLOR = "COLOR";

        private Dictionary<string, LightCommand> _commandQueue;
        //DispatcherTimer _timer; //timer for queue

        ILocalHueClient _client;
        Light _light;
        List<string> _lightList;
        bool _isInitialized;
        //protected override async void OnNavigatedTo()
        //{
        //    base.OnNavigatedTo();

        //    string appId = "";
        //    string clientId = "";
        //    string clientSecret = "";

        //    IRemoteAuthenticationClient authClient = new RemoteAuthenticationClient(clientId, clientSecret, appId);

            

        //    var authorizeUri = authClient.BuildAuthorizeUri("sample", "consoleapp");
        //    var callbackUri = new Uri("https://localhost/q42hueapi");
            
        //    var webAuthenticationResult = await Windows.Security.Authentication.Web WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, authorizeUri, callbackUri);

        //    if (webAuthenticationResult != null)
        //    {
        //        var result = authClient.ProcessAuthorizeResponse(webAuthenticationResult.ResponseData);

        //        if (!string.IsNullOrEmpty(result.Code))
        //        {
        //            //You can store the accessToken for later use
        //            var accessToken = await authClient.GetToken(result.Code);

        //            IRemoteHueClient client = new RemoteHueClient(authClient.GetValidToken);
        //            var bridges = await client.GetBridgesAsync();

        //            if (bridges != null)
        //            {
        //                //Register app
        //                //var key = await client.RegisterAsync(bridges.First().Id, "Sample App");

        //                //Or initialize with saved key:
        //                client.Initialize(bridges.First().Id, "C95sK6Cchq2LfbkbVkfpRKSBlns2CylN-VxxDD8F");

        //                //Turn all lights on
        //                var lightResult = await client.SendCommandAsync(new LightCommand().TurnOn());

        //            }
        //        }
        //    }
        //}

        public LightController()
        {
           
            //InitializeHue(); //fire and forget, don't wait on this call// uncomment local

            //initialize command queue
            _commandQueue = new Dictionary<string, LightCommand>();
            
        }
        public bool OnOff(bool IsOn)
        {
            if (_isInitialized)
            {
                //queue power command
                LightCommand cmd = new LightCommand();
                cmd.On =IsOn;
                QueueCommand(ON_OFF, cmd);
            }
                return true;
        }
        public async void InitializeHue()
        {
            _isInitialized = false;
            //initialize client with bridge IP and app GUID
            _client = new LocalHueClient(BRIDGE_IP);
            _client.Initialize(APP_ID);

            //only working with light #1 in this demo
            _light = await _client.GetLightAsync("1");
            _lightList = new List<string>() { "1" };

           
           
            _isInitialized = true;
         
        }
        private void QueueCommand(string commandType, LightCommand cmd)
        {
            if (_commandQueue.ContainsKey(commandType))
            {
                //replace with most recent
                _commandQueue[commandType] = cmd;
            }
            else
            {
                _commandQueue.Add(commandType, cmd);
            }

        }
    }
}
