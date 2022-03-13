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
        private static StringComparison sc = StringComparison.OrdinalIgnoreCase;
        private static string path = Application.dataPath + "/Scripts/Velvie_AI/velvie-genderName/";

        //First four characters
        public static double FirstFour(string str, bool isMale)
        {
            if(str.Length < 5)
                return 0;

            double val = 0;

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
                        
                        if(firstFour.Equals(comparer, sc))
                        {
                            val += 0.2;
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
        public static double SecondFour(string str, bool isMale)
        {
            if(str.Length < 6)
                return 0;

            double val = 0;

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
                        
                        if(firstFour.Equals(comparer, sc))
                        {
                            val += 0.2;
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
        public static double LastFour(string str, bool isMale)
        {
            if(str.Length < 5)
                return 0;

            double val = 0;
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

                        if(lastFour.Equals(comparer, sc))
                        {
                            val += 0.2;
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
        public static double MiddleFour(string str, bool isMale)
        {
            if(str.Length < 5)
                return 0;

            double val = 0;

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

                        if(lastFour.Equals(comparer, sc))
                        {
                            val += 0.2;
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
        public static double ShiftMatching(string str, bool isMale, int bounds)
        {
            double val = 0;            

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
                    if (!String.IsNullOrEmpty(e) && str.Length >= e.Length)
                    {
                        for(int i = 0; i < e.Length; i++)
                        {
                            if(i + bounds <= e.Length - 1 && e[i] == str[i] && 
                                e[i + (bounds - 2)] == str[i + (bounds - 2)] && 
                                e[i + (bounds - 1)] == str[i + (bounds - 1)] && 
                                e[i + bounds] == str[i + bounds])
                            {
                                val += 0.2;
                                Debug.Log("simillar +3 sequence match : " + e + " : " + isMale);
                            }
                            if(i + (bounds + 1) <= e.Length - 1 && e[i+bounds] == str[i+bounds] && 
                                e[i] == str[i] && e[i + (bounds + 1)] == str[i + (bounds + 1)])
                            {
                                val += 0.2;
                                Debug.Log("simillar shift +3 skip match : " + e + " : " + isMale);
                            }
                        }
                    }

                    if(str.Equals(e, sc))
                        val += 10;
                }
            }

            if(isMale)
                Debug.Log("male common : " + (double)val / (double)1000);
            else
                Debug.Log("female common : " + (double)val / (double)1000);
            return val;
        }
    }
}