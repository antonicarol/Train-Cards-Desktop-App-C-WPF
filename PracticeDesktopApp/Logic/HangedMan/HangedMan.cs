using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDesktopApp.Logic.HangedMan
{

    class HangedMan
    {
        public int progress;
        public string[] words;
        public int hangedMan;
        public char[] abecedarie;
        public char[] result;

        public HangedMan()
        {
            progress = 0;
            hangedMan = 0;
            words = new string[1];
            words[0] = "house".ToUpper();
            abecedarie = FillAbecedarie();
        }

        public char[] GetResult()
        {
            return result;
        }

        private char[] FillAbecedarie()
        {
            return new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        }
        public char[] GetAbecedarie()
        {
            return abecedarie;
        }

        public string GetRandomWord()
        {
            int index = 0;
            string word = GetWord(index);
            progress = word.Length;

            result = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                result[i] = '_';
            }
            return word;
        }

        public String GetWord(int index)
        {
            return words[index];
        }

        public bool SayCharacter(string letter, string word)
        {
            char[] res = GetResult();
            bool b = word.Contains(letter);
            if (b)
            {
                int index = word.IndexOf(letter);
                result[index] = letter[0];

            }
            return b;
        }
    }
}
