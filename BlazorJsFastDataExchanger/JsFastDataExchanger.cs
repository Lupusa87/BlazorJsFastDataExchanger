using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJsFastDataExchanger
{
    public static class JsFastDataExchanger 
    {
        public static Action<string> OnMessage { get; set; }
        public static Action<string> OnProgress { get; set; }

        public static IJSRuntime _jsRuntime;
        public static IJSRuntime jsRuntime
        {

            get {
                return _jsRuntime;
            }

            set {

                _jsRuntime = value;
                _jsUnmarshalledRuntime = value as IJSUnmarshalledRuntime;
            }
        }


        private static IJSUnmarshalledRuntime _jsUnmarshalledRuntime;


        public static void SetStringData(string variableName, string data)
        {
           
            _jsUnmarshalledRuntime.InvokeUnmarshalled<string, string, bool>(
                    "BJSFDEJsFunctions.SetStringData", variableName, data);
        }

        public static string GetStringData(string variableName)
        {
            return _jsUnmarshalledRuntime.InvokeUnmarshalled<string, string>(
                    "BJSFDEJsFunctions.GetStringData", variableName);

        }


        public static void SetBinaryData(string variableName, byte[] data)
        {

            _jsUnmarshalledRuntime.InvokeUnmarshalled<string, byte[], bool>(
                    "BJSFDEJsFunctions.SetBinaryData", variableName, data);
        }


        public static async Task<bool> GetBinaryData(BJSFDEBinaryInfo binaryInfo)
        {
            bool b = _jsUnmarshalledRuntime.InvokeUnmarshalled<string, byte[], bool>(
                    "BJSFDEJsFunctions.GetBinaryData", binaryInfo.variableName, binaryInfo.data);
            await Task.Delay(1);
            return await Task.FromResult(b);
        }


        public static async Task<bool> GetBinaryDataByPortions(BJSFDEBinaryInfo binaryInfo)
        {

            bool b = _jsUnmarshalledRuntime.InvokeUnmarshalled<string, byte[], string, bool>(
                "BJSFDEJsFunctions.GetBinaryDataChunk", binaryInfo.variableName, binaryInfo.data, binaryInfo.position + "," + binaryInfo.chunkSize);
            await Task.Delay(1);
            return await Task.FromResult(b);
        }

        public static bool DeleteGlobalVariable(string variableName)
        {
            return _jsUnmarshalledRuntime.InvokeUnmarshalled<string, bool>(
                  "BJSFDEJsFunctions.DeleteGlobalVariable", variableName);
        }

        public static int GetBinaryDataLenght(string variableName)
        {

            return _jsUnmarshalledRuntime.InvokeUnmarshalled<string, int>(
                    "BJSFDEJsFunctions.GetBinaryDataLenght", variableName);

        }


        [JSInvokable]
        public static void HandleMessage(string msg)
        {
            OnMessage?.Invoke(msg);
           
        }

        [JSInvokable]
        public static void HandleProgress(string msg)
        {
            OnProgress?.Invoke(msg);

        }



    }


}
