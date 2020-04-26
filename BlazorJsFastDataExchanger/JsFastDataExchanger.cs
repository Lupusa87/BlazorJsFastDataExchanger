using Mono.WebAssembly.Interop;


namespace BlazorJsFastDataExchanger
{
    public static class JsFastDataExchanger 
    {

        private static MonoWebAssemblyJSRuntime mono = new MonoWebAssemblyJSRuntime();


        public static void SetStringData(string variableName, string data)
        {

            mono.InvokeUnmarshalled<string, string, bool>(
                    "BJSFDEJsFunctions.BJSFDESetStringData", variableName, data);
        }


        public static void SetBinaryData(string variableName, byte[] data)
        {

            mono.InvokeUnmarshalled<string, byte[], bool>(
                    "BJSFDEJsFunctions.BJSFDESetBinaryData", variableName, data);
        }


        public static string GetStringData(string variableName)
        {
            return mono.InvokeUnmarshalled<string, string>(
                    "BJSFDEJsFunctions.BJSFDEGetStringData", variableName);

        }


        public static bool GetBinaryData(string variableName, byte[] destination)
        {
            return mono.InvokeUnmarshalled<string, byte[], bool>(
                    "BJSFDEJsFunctions.BJSFDEGetBinaryData", variableName, destination);

        }

        public static int GetBinaryDataLenght(string variableName)
        {

            return mono.InvokeUnmarshalled<string, int>(
                    "BJSFDEJsFunctions.BJSFDEGetBinaryDataLenght", variableName);

        }


    }
}
