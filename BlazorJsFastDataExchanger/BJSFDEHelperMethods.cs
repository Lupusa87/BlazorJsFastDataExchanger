using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorJsFastDataExchanger
{
    public static class BJSFDEHelperMethods
    {
        public static double ConvertSize(double bytes, SizeUnit sizeUnit)
        {
            try
            {
                const double d = 1024.0;

                return sizeUnit switch
                {
                    SizeUnit.kb => Math.Round(bytes / d, 2),
                    SizeUnit.mb => Math.Round(bytes / Math.Pow(d, 2), 2),
                    SizeUnit.gb => Math.Round(bytes / Math.Pow(d, 3), 2),
                    _ => 0,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public enum SizeUnit
        {
            kb,
            mb,
            gb
        }
    }
}
