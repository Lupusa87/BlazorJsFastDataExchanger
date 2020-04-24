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

        public static void SetData(string variableName, string data)
        {
            MonoWebAssemblyJSRuntime mono = new MonoWebAssemblyJSRuntime();
            mono.InvokeUnmarshalled<string, string, bool>(
                    "BJSFDEJsFunctions.BJSFDESetData", variableName, data);
        }


        public static string GetData(string variableName)
        {

            MonoWebAssemblyJSRuntime mono = new MonoWebAssemblyJSRuntime();


            return mono.InvokeUnmarshalled<string, string>(
                    "BJSFDEJsFunctions.BJSFDEGetData", variableName);

        }

    }
}
