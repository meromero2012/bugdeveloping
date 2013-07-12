using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;

namespace FrbaBus.DateSystem
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }

    public static class MySystemDate
    {
        static SYSTEMTIME st;
        
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public static void setSystemDate(short anio, short mes, short dia)
        {
            st.wYear = anio; // must be short
            st.wMonth = mes;
            st.wDay = dia;
            st.wHour = 0;
            st.wMinute = 0;
            st.wSecond = 0;

            SetSystemTime(ref st); // invoke this method.
        }
    }
}