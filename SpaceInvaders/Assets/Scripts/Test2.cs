using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class Test2 : MonoBehaviour
    {
        public void Start()
        {
            Debug.LogError(Solution("00-44  48 5555 8361"));
        }

        public string Solution(string phoneNumber)
        {
            phoneNumber = RemoveNonDigitsChars(phoneNumber);
            return FormatPhoneNumber(phoneNumber, IsNumberSizeOk(phoneNumber));
        }

        private bool IsNumberSizeOk(string phoneNumber)
        {
            return phoneNumber.Length % 3 == 1;
        }

        private string RemoveNonDigitsChars(string s)
        {
            return Regex.Replace(s, "[^0-9]", "");
        }

        private string FormatPhoneNumber(string s, bool lastGroup)
        {
            string tempNumber = "";
            int dashCounter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (dashCounter < 3)
                {
                    tempNumber = tempNumber + s.Substring(i, 1);
                    dashCounter++;
                }
                else if (dashCounter == 3)
                {
                    tempNumber = tempNumber + "-";
                    tempNumber = tempNumber + s.Substring(i, 1);
                    dashCounter = 1;
                }
            }

            if (lastGroup)
            {
                char[] temp = tempNumber.ToCharArray();
                temp[temp.Length - 2] = temp[temp.Length - 3];
                temp[temp.Length - 3] = '-';
                tempNumber = new string(temp);
            }

            return tempNumber;
        }
    }
}