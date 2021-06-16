using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class Test : MonoBehaviour
    {
        private const string AM = "AM";
        private const string DOTS_SYMBOL = ":";
        
        public void Start()
        {
            //07:31PM' -> "19:31"
            //07:31am' -> "19:31"
            
            
            
        }
        
        public string solution(string[] A, string[] B, string P) {
            List<int> matchedIndexes = new List<int>();
            for (int i = 0; i < B.Length; i++)
            {
                if (B[i].Contains(P))
                {
                    matchedIndexes.Add(i);
                }
            }

            if (matchedIndexes.Count == 0)
            {
                return "NO CONTACT";
            }
            
            List<string> matchedNames = new List<string>();
            for (int i = 0; i < A.Length; i++)
            {
                if (matchedIndexes.Contains(i))
                {
                    matchedNames.Add(A[i]);
                }
            }
            
            matchedNames.Sort();
            return matchedNames[0];
        }

        private string Convert(string americanTime)
        {
            americanTime = americanTime.ToUpper();
            americanTime = americanTime.Replace(" ", string.Empty);
            bool isAfterMidDay = americanTime.Contains(AM);

            string[] splitText = americanTime.Split(':');
            int hours = int.Parse(splitText[0]);
            int minutes = int.Parse(splitText[1].Substring(0, 2));

            if (isAfterMidDay)
            {
                hours += 12;
            }

            return hours + DOTS_SYMBOL + minutes;
        }
    }
}