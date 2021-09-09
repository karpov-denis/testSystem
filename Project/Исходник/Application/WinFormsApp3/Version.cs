using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp3
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
