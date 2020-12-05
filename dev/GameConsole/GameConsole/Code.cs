﻿using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Code
    {
        private string _code;
        private List<string> _hints;
        private List<string> _hintBodies = new List<string> { "One is correct, and in the right spot.", "One is correct, and in the wrong spot.", "Two are correct, and in the wrong spots.", "Nothing is correct.", "One is correct, and in the wrong spot." };

        public List<string> HintBodies { get { return _hintBodies; } }

        public Code(string[] data)
        {
            _code = data[0];
            for(int i = 1; i < data.Length; i++)
            {
                _hints.Add(data[i]);
            }
        }

        public Dictionary<string, List<string>> GetCodeData()
        {
            Dictionary<string, List<string>> codeData = new Dictionary<string, List<string>>();
            codeData.Add(_code, _hints);
            return codeData;
        }
    }
}
