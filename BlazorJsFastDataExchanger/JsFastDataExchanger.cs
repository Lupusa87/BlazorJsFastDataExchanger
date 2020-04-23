using Microsoft.JSInterop;
using Mono.WebAssembly.Interop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJsFastDataExchanger
{
    public static class JsFastDataExchanger 
    {

        public static Action<string> OnDataReceived { get; set; }


        public static IJSRuntime _JSRuntime;


        public static void SendData(string data)
        {
            MonoWebAssemblyJSRuntime mono = new MonoWebAssemblyJSRuntime();
            mono.InvokeUnmarshalled<string, bool>(
                    "BJSFDEJsFunctions.BJSFDESendData", data);

            //MonoWebAssemblyJSRuntime mono = new MonoWebAssemblyJSRuntime();
            //mono.InvokeUnmarshalled<byte[], bool>(
            //        "BJSFDEJsFunctions.BJSFDESendData", Encoding.UTF8.GetBytes(data));
        }

        public static void SendData(byte[] data)
        {
            MonoWebAssemblyJSRuntime mono = new MonoWebAssemblyJSRuntime();
            mono.InvokeUnmarshalled<byte[], bool>(
                    "BJSFDEJsFunctions.BJSFDEReceiveData", data);
        }

        public static void RequestData()
        {
            _JSRuntime.InvokeVoidAsync("BJSFDEJsFunctions.BJSFDERequestData");

        }


        [JSInvokable]
        public static void HandleMessage(string data)
        {
            OnDataReceived?.Invoke(data);
        }

    }
}
