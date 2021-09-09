using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp3
{
    class Data
    {
        private string _Word;
        private string _V1;
        private string _V2;
        private int _Used;
        private int _Correct;
        public Data(string A, string B, string C,int D)
        {
            this._Word = A;
            this._V1 = B;
            this._V2 = C;
            this._Used = 0;
            this._Correct = D;
        }
        public bool CheckCorrect(int res)
        {
            return res == _Correct;
        }
        public int Used
        {
            get => _Used;
            set => _Used = value;
        }

        public string Word
        {
            get => _Word;
        }
        public string V1
        {
            get => _V1;
        }
        public string V2
        {
            get => _V2;
        }
    }
}
