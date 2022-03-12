using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;

namespace VGender
{
    public static class CommonNameParser
    {
        private static string femalefileName = "commonFemaleNames.txt";
        private static string malefileName = "commonMaleNames.txt";

        //First four characters
        public static int FirstFour(string str, bool isMale)
        {
            if(str.Length < 5)
                return 0;

            int val = 0;
            var path = Application.dataPath + "/Scripts/Velvie_AI/velvie-genderName/";

            //2 is the upper bound, setting this higher would gain accuracy 
            //but too many abstraction that can lead to false information

            if (isMale)
            {
                path += malefileName;
            }
            else
            {
                path += femalefileName;
            }

            if (File.Exists(path))
            {
                foreach (var e in File.ReadLines(path))
                {                    
                    if (!String.IsNullOrEmpty(e) && e.Length > 4)
                    {
                        string firstFour = e[0..5]; //skip first letter
                        string comparer = str[0..5];
                        
                        if(firstFour.Equals(comparer, StringComparison.OrdinalIgnoreCase))
                        {
                            val++;
                            Debug.Log("simillar firstFour pattern : " + firstFour + " : " + isMale);
                        }
                    }
                }
            }
            if(isMale)
                Debug.Log("male common : " + val);
            else
                Debug.Log("female common : " + val);
            return val;
        }
        public static int SecondFour(string str, bool isMale)
        {
            if(str.Length < 6)
                return 0;

            int val = 0;
            var path = Application.dataPath + "/Scripts/Velvie_AI/velvie-genderName/";

            //2 is the upper bound, setting this higher would gain accuracy 
            //but too many abstraction that can lead to false information

            if (isMale)
            {
                path += malefileName;
            }
            else
            {
                path += femalefileName;
            }

            if (File.Exists(path))
            {
                foreach (var e in File.ReadLines(path))
                {                    
                    if (!String.IsNullOrEmpty(e) && e.Length >= 6)
                    {
                        string firstFour = e[2..6]; //skip first letter
                        string comparer = str[2..6];
                        
                        if(firstFour.Equals(comparer, StringComparison.OrdinalIgnoreCase))
                        {
                            val++;
                            Debug.Log("simillar firstFour pattern : " + firstFour + " : " + isMale);
                        }
                    }
                }
            }
            if(isMale)
                Debug.Log("male common : " + val);
            else
                Debug.Log("female common : " + val);
            return val;
        }
        //Last four character
        public static int LastFour(string str, bool isMale)
        {
            if(str.Length < 5)
                return 0;

            int val = 0;
            var path = Application.dataPath + "/Scripts/Velvie_AI/velvie-genderName/";

            //2 is the upper bound, setting this higher would gain accuracy 
            //but too many abstraction that can lead to false information
            if (isMale)
            {
                path += malefileName;
            }
            else
            {
                path += femalefileName;
            }

            if (File.Exists(path))
            {
                foreach (var e in File.ReadLines(path))
                {                    
                    if (!String.IsNullOrEmpty(e) && e.Length > 4)
                    {
                        string lastFour = e.Substring(e.Length - 3);
                        string comparer = str.Substring(str.Length - 3);

                        if(lastFour.Equals(comparer, StringComparison.OrdinalIgnoreCase))
                        {
                            val++;
                            Debug.Log("simillar lastFour pattern : " + lastFour + " : " + isMale);
                        }
                    }
                }
            }

            if(isMale)
                Debug.Log("male common : " + val);
            else
                Debug.Log("female common : " + val);
            return val;
        }
        public static int MiddleFour(string str, bool isMale)
        {
            if(str.Length < 5)
                return 0;

            int val = 0;
            var path = Application.dataPath + "/Scripts/Velvie_AI/velvie-genderName/";

            //2 is the upper bound, setting this higher would gain accuracy 
            //but too many abstraction that can lead to false information
            if (isMale)
            {
                path += malefileName;
            }
            else
            {
                path += femalefileName;
            }

            if (File.Exists(path))
            {
                foreach (var e in File.ReadLines(path))
                {                    
                    if (!String.IsNullOrEmpty(e) && e.Length > 4)
                    {
                        if(e.Length < 4)
                            continue;

                        string lastFour = e.Substring(2);
                        string comparer = str.Substring(2);

                        if(lastFour.Equals(comparer, StringComparison.OrdinalIgnoreCase))
                        {
                            val++;
                            Debug.Log("simillar midFour pattern : " + lastFour + " : " + isMale);
                        }
                    }
                }
            }

            if(isMale)
                Debug.Log("male common : " + val);
            else
                Debug.Log("female common : " + val);
            return val;
        }
        public static int ExactName(string str, bool isMale)
        {
            int val = 0;
            var path = Application.dataPath + "/Scripts/Velvie_AI/velvie-genderName/";

            //2 is the upper bound, setting this higher would gain accuracy 
            //but too many abstraction that can lead to false information
            if (isMale)
            {
                path += malefileName;
            }
            else
            {
                path += femalefileName;
            }

            if (File.Exists(path))
            {
                foreach (var e in File.ReadLines(path))
                {                    
                    if (!String.IsNullOrEmpty(e) && e.Length == str.Length)
                    {
                        if(e.Equals(str, StringComparison.OrdinalIgnoreCase))
                        {
                            val = 100;
                            Debug.Log("simillar exact match : " + e + " : " + isMale);
                        }
                    }
                }
            }

            if(isMale)
                Debug.Log("male common : " + val);
            else
                Debug.Log("female common : " + val);
            return val;
        }
    }
}