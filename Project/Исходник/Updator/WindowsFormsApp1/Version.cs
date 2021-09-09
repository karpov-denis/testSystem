using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    [Serializable]
    public class Version
    {
        public int version { get; set; }
        public Version()
        {

        }
        public Version(int a)
        {
            this.version = a;
        }
    }
}
