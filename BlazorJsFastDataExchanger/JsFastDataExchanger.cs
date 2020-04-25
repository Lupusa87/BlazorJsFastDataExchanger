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

        private static MonoWebAssemblyJSRuntime mono = new MonoWebAssemblyJSRuntime();


        public static void SetData(string variableName, string data)
        {
            
            mono.InvokeUnmarshalled<string, string, bool>(
                    "BJSFDEJsFunctions.BJSFDESetData", variableName, data);
        }


        public static string GetData(string variableName)
        {
            return mono.InvokeUnmarshalled<string, string>(
                    "BJSFDEJsFunctions.BJSFDEGetData", variableName);

        }

    }
}
