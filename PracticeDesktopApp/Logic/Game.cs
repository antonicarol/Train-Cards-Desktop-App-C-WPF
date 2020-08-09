using System;
using System.Collections.Generic;
using System.Text;

namespace TrainCards
{
    class Game
    {
        public Card[] cards;

        public Card[] progress;


        public Game()
        {
            cards = fillCards();
            progress = new Card[5];
        }

        public Card GetRandomCard()
        {
            Random rnd = new Random();
            int index = rnd.Next(1, 48);
            Card card = GetCard(index);
            return card;
        }

        public Card GetCard(int index)
        {
            return cards[index];
        }

        private void AddToProgres(int round,Card card) 
        {
            progress[round] = card;
        }
        public string GetProcess()
        {
            string result = "";
            int i = 0;
            foreach(Card card in progress)
            {
               
                if(card != null)
                {
                    if (i != 0)
                    {
                        result += " and ";
                    }

                    result += card.ToString();
                }
                i++;
            }
            return result;
            
        }
        static Card[] fillCards()
        {

            Card[] cards = new Card[48];

            for(int i = 1; i<49; i++)
            {
                if (i <= 12)
                {
                    cards[i-1] = new Card(i, "diamonds", true);
                }
                else if( i>12 && i <= 24)
                {
                    cards[i-1] = new Card((i-12), "clubs", false);
                }
                else if ( i>24 && i <= 36)
                {
                    cards[i-1] = new Card((i - 24), "hearts", true);
                }
                else if( i>36 && i <= 48)
                {
                    cards[i-1] = new Card((i - 36), "spades", false);
                }
            }

            return cards;
        }

        public void ClearProgress()
        {
            progress = new Card[5];
        }
        public bool RoundOne(string color, Card randomCard)
        {
            bool bColor;
            if (color.Equals("RED"))
            {
                bColor = true;
            }
            else
            {
                bColor = false;
            }

            if(randomCard.GetColor() == bColor)
            {
                AddToProgres(0, randomCard);
                return true;
               
            }
            else
            {
                return false;
            }

        }

    
        public bool RoundTwo(string choice)
        {
            Card baseCard = progress[0];

            Console.WriteLine("You selected : " + choice + " than "+ baseCard.ToString());

            Card randomCard = GetRandomCard();

            Console.WriteLine("The crupier take out one card : \n" +
                                "The card is : " + randomCard.ToString());
            if (choice.Equals("Higher"))
            {
                if (randomCard.GetValue() > baseCard.GetValue())
                {
                    AddToProgres(1, randomCard);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (choice.Equals("Lower"))
            {
                if (randomCard.GetValue() < baseCard.GetValue())
                {
                    AddToProgres(1, randomCard);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
            
        }

        

        internal bool RoundThree(string choice)
        {
            Card[] baseCards = { progress[0], progress[1] };

            Card high , low = new Card();
            if(baseCards[0].GetValue() > baseCards[1].GetValue())
            {
                high = baseCards[0];
                low = baseCards[1];
            }
            else
            {
                high = baseCards[1];
                low = baseCards[0];
            }

            string deck = GetProcess();

            Console.WriteLine("You selected : " + choice + " " + high.ToString() + " and "+ low.ToString() );

            Card randomCard = GetRandomCard();

            Console.WriteLine("The crupier take out one card : \n" +
                                "The card is : " + randomCard.ToString());

            if (choice.Equals("Between"))
            {
                Console.WriteLine("gzgshh");
                if(randomCard.GetValue() < high.GetValue() && randomCard.GetValue() > low.GetValue())
                {
                    AddToProgres(2, randomCard);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (choice.Equals("Outside"))
            {
                if (randomCard.GetValue() > high.GetValue() || randomCard.GetValue() < low.GetValue())
                {
                    AddToProgres(2, randomCard);
                    return true;
                }
                else
                {
                    return false;
                }
            }
         

            return false;

        }
        internal bool RoundFour(string choice)
        {
            int i = 0;
            string[] typesInDeck = new string[3];

            foreach(Card card in progress)
            {
                if(card != null)
                {
                    typesInDeck[i] += card.GetType();
                }
                i++;
            }

            Console.WriteLine("You selected that " + choice + " it will repeat type");
            Card randomCard = GetRandomCard();

            Console.WriteLine("The crupier take out one card : \n" +
                                "The card is : " + randomCard.ToString());

            if (choice.Equals("Yes"))
            {
                if (Array.Exists(typesInDeck,element => element == randomCard.GetType()))
                {
                    AddToProgres(3, randomCard);
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                if(!Array.Exists(typesInDeck, element => element == randomCard.GetType()))
                {
                    AddToProgres(3, randomCard);
                    return true;
                }
                else
                {
    
                    return false;
                }
            }

            return false;
        }

        internal bool RoundFive(string choice)
        {
            int i = 0;
            int[] numbersInDeck = new int[4];

            foreach (Card card in progress)
            {
                if (card != null)
                {
                    numbersInDeck[i] += card.GetValue();
                }
                i++;
            }

            Console.WriteLine("You selected that " + choice + " it will repeat number");
            Card randomCard = GetRandomCard();

            Console.WriteLine("The crupier take out one card : \n" +
                                "The card is : " + randomCard.ToString());

            if (choice.Equals("Yes"))
            {
                if (Array.Exists(numbersInDeck, element => element == randomCard.GetValue()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (!Array.Exists(numbersInDeck, element => element == randomCard.GetValue()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            


        }

    }


}
