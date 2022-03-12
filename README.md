# Gender Name Detection for .Net and Unity3D
A gender detection based on person's name. Currently only supports english-like names.  

  
# How To Use  
Add VGender as namespace. 

            string stringName = "Benjamin";
            var t = VGenderName.NameGender(stringName);
            Console.WriteLine("StringResult : " + t.value + " Female IntValue : " + t.femaleVal " Male IntValue : " + t.maleVal);


# Method  
There are two approaches, one with commonal patterns by letter shifting, the other is by taking from corpus data.  

Gender name detection is very useful for NLPs, visual novels, chatbots etc.
While this same module is meant to be used for a conversational AI in .Net and Unity3D, it is not by any means an AI. The goal of this module is to be paired with ML.NET. Although you can use it as standalone with no problem.   
  
Note : for Unity3D copy the script into Assets/Scripts.  
  
# Limitations  
Only supports English-like names (US/UK).  
Doesn't support multiple words(first and last name). You must split it manually and make two instances (one for first name, other for last name) so it would work.

