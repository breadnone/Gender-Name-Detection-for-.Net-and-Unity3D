# Gender Name Detection for Unity3D
A gender detection based on person's name. Currently only supports english-like names.  

  
# How To Use  
Add VGender as namespace. 

            string stringName = "Benjamin";
            var t = VGenderName.NameGender(stringName);
            Debug.Log("StringResult : " + t.value + " Female IntValue : " + t.femaleVal " Male IntValue : " + t.maleVal);


# Method  
There are two approaches, one with commonal patterns by letter shifting, the other is by taking from corpus data.  
  
There are common patterns hardcoded mostly for fallback if it returns equals. This should affect a little other gender name detection from other cultures (JPN, KOR, etc..).  
```
                male = (lastThree) switch //common last three characters
                {
                    var x when
                    x == "elo" || x == "les" || x == "ino" || x == "nho" ||
                    x == "xon" || x == "con" || x == "jon" || x == "moa" ||
                    x == "yan" || x == "ton" || x == "bon" || x == "gon" ||
                    ...
                };
```  
# Tweaking Accuracies  
NOTE: Adding custom bounds will require adjustment to length checks!
```
                //set this higher/lower depends on country cultures. 
                //US/UK best with value of 3, other countries/cultures may need to tweak this value lower/higher.  
                
                int bounds = 3; 
                
                female += CommonNameParser.ShiftMatching(inputWrd, false, bounds);
                male += CommonNameParser.ShiftMatching(inputWrd, true, bounds);
```
Gender name detection is very useful for NLPs, NER, games such as visual novels(for gender pronouns detection), chatbots etc.
While this same module is meant to be used for a conversational AI in .Net and Unity3D, it is not by any means an AI. The goal of this module is to be paired with ML.NET. Although you can use it as standalone with no problem.   
  
# Add More Common Names  
You can make it learn other gender name detection from other languages (KOR, JPN, AUS, FIN, anything you want to add!) by adding more names in :  
[Female Names Dictionary](https://github.com/breadnone/Gender-Name-Detection-for-.Net-and-Unity3D/blob/main/Velvie_AI/velvie-genderName/commonFemaleNames.txt)  
[Male Names Dictionary](https://github.com/breadnone/Gender-Name-Detection-for-.Net-and-Unity3D/blob/main/Velvie_AI/velvie-genderName/commonMaleNames.txt)  
  
Note 1: for Unity3D copy the script into Assets/Scripts.  
Note 2: Unity3D 2021.4.x or above  
Note 3: Net Standard 2.1 selected in project settings.  
  
Note for .Net setup : Change the Application.Datapath with GetFolderPath method then remove all Unity's namespace and treat it as reqular c# classes (well, you know the drill)
  
# Limitations  
Only supports English-like names (US/UK).  
Doesn't support multiple words(first and last name). You must split it manually and make two instances (one for first name, other for last name) so it would work.

