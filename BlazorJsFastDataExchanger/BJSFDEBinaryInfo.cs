using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJsFastDataExchanger
{
    public class BJSFDEBinaryInfo
    {

        public string variableName { get; private set; }

        public int dataLenght { get; set; } = -1;

        public string progressInfo { get; set; }

        public int position { get; set; } = 0;
        public int chunkSize { get; set; } = 2097152; //1024*1024*2;

        public byte[] data { get; set; }



        public string dataString { get; set; }

        public Action<int> OnDataRead;

        public Action OnFinish;

        public BJSFDEBinaryInfo(string varName)
        {
            variableName = varName.ToLower();
        }

        public string ReadAsString(bool KeepBinary = true)
        {
            dataString = Encoding.UTF8.GetString(data);

            if (!KeepBinary)
            {
                data = new byte[0];
            }

            return dataString;
        }

        public async Task<int> LoadEntirelyAsync()
        {

            data = new byte[dataLenght];

            await JsFastDataExchanger.GetBinaryData(this);

            progressInfo = ".net loaded 100 of 100%";
            OnDataRead?.Invoke(100);

            OnFinish?.Invoke();

            return 1;
        }

        public async Task<int> LoadByPortionsAsync()
        {
           
            data = new byte[dataLenght];


            int CurrentPercent = 0;

            double p;

            while (position < dataLenght)
            {

                p = position * 100.0 / dataLenght;

                chunkSize = Math.Min(chunkSize, dataLenght - position);

                await JsFastDataExchanger.GetBinaryDataByPortions(this);

                position += chunkSize;

                if (CurrentPercent != (int)p)
                {
                    
                    CurrentPercent = (int)p;
                    progressInfo = ".net loaded " + (int)p + " of 100%";

                    OnDataRead?.Invoke(CurrentPercent);
                }
            }

            progressInfo = ".net loaded 100 of 100%";
            OnDataRead?.Invoke(100);

            JsFastDataExchanger.DeleteGlobalVariable(variableName);

            OnFinish?.Invoke();


            return 1;
        }

    }
}
