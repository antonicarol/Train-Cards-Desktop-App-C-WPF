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
        public List<char[]> abecedarie;
        public char[] result;


        public HangedMan()
        {
            progress = 0;
            hangedMan = 0;
            words = new string[1];
            words = FillWords();
            abecedarie = FillAbecedarie();
        }

        public char[] GetResult()
        {
            return result;
        }

        private string[] FillWords()
        {
            return new string[] {"database","algorithm","command","cyberbullying", "debugging", "function", "Internet", "iteration",
                                 "output","parameter","programming","variable","workspace","operand","statement","string","argument","brackets","execute"};
        }

        private List<char[]> FillAbecedarie()
        {
            return new List<char[]>
            {
                new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',},
                new char[] { 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }
            };
        }

       
        

        public List<char[]> GetAbecedarie()
        {
            return abecedarie;
        }

        public string GetRandomWord()
        {
            Random rnd = new Random();
            int index = rnd.Next(1, words.Length);
            string word = GetWord(index).ToUpper();
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
            var foundIndexes = new List<int>();
            bool b = word.Contains(letter);
            if (b)
            {
                for (int i = word.IndexOf(letter); i > -1; i = word.IndexOf(letter, i + 1))
                {
                    // for loop end when i=-1 ('a' not found)
                    foundIndexes.Add(i);
                }
                for (int i = 0; i < foundIndexes.Count; i++)
                {
                    result[foundIndexes[i]] = letter[0];
                }


                //The progres will reach 0 when all the word is completed!
                progress--;
                if (progress == 0)
                {
                    //It means the game is Won

                }

            }
            else
            {
                //The hanged man will start building, it will reach to 5
                hangedMan++;
                if (hangedMan == 5)
                {
                    //It means the game's lost
                }
            }
            return b;
        }

        public int GetProgress()
        {
            return progress;
        }

        public int GetHangedMan()
        {
            return hangedMan;
        }

        public string GetImgHangedMan()
        {
            return "hangedMan" + hangedMan;
        }
    }
}
