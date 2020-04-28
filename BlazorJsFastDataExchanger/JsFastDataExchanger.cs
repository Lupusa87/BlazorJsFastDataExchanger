using Microsoft.JSInterop;
using Mono.WebAssembly.Interop;
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

        public static MonoWebAssemblyJSRuntime monoWebAssemblyJSRuntime = new MonoWebAssemblyJSRuntime();


        public static void SetStringData(string variableName, string data)
        {

            monoWebAssemblyJSRuntime.InvokeUnmarshalled<string, string, bool>(
                    "BJSFDEJsFunctions.BJSFDESetStringData", variableName, data);
        }


        public static void SetBinaryData(string variableName, byte[] data)
        {

            monoWebAssemblyJSRuntime.InvokeUnmarshalled<string, byte[], bool>(
                    "BJSFDEJsFunctions.BJSFDESetBinaryData", variableName, data);
        }


        public static string GetStringData(string variableName)
        {
            return monoWebAssemblyJSRuntime.InvokeUnmarshalled<string, string>(
                    "BJSFDEJsFunctions.BJSFDEGetStringData", variableName);

        }


        public static bool GetBinaryData(BinaryInfo binaryInfo)
        {

            return monoWebAssemblyJSRuntime.InvokeUnmarshalled<string, byte[], bool>(
                    "BJSFDEJsFunctions.BJSFDEGetBinaryData", binaryInfo.variableName, binaryInfo.data);

        }


        public static async Task<bool> GetBinaryDataByPortions(BinaryInfo binaryInfo)
        {

            monoWebAssemblyJSRuntime.InvokeUnmarshalled<string, byte[], string, bool>(
                "BJSFDEJsFunctions.BJSFDEGetBinaryDataChunk", binaryInfo.variableName, binaryInfo.data, binaryInfo.position + "," + binaryInfo.chunkSize);
            await Task.Delay(1);
            return await Task.FromResult(true);

        }

        public static bool DeleteGlobalVariable(string variableName)
        {
            return monoWebAssemblyJSRuntime.InvokeUnmarshalled<string, bool>(
                  "BJSFDEJsFunctions.BJSFDEDeleteGlobalVariable", variableName);
        }

        public static int GetBinaryDataLenght(string variableName)
        {

            return monoWebAssemblyJSRuntime.InvokeUnmarshalled<string, int>(
                    "BJSFDEJsFunctions.BJSFDEGetBinaryDataLenght", variableName);

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
