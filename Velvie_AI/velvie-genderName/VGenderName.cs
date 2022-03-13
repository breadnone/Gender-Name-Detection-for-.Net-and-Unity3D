using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace VGender
{
    public static class VGenderName
    {
        // Start is called before the first frame update
        private static StringComparison sc = StringComparison.OrdinalIgnoreCase;
        public static (double maleVal, double femaleVal, string value) NameGender(string inputWrd)
        {
            var t = string.Empty;
            (double maleVal, double femaleVal, string value) finalVal = (0.0, 0.0, string.Empty);

            if (inputWrd.Length >= 4)
            {
                string[] wordChunks = inputWrd.ToLower().Split(' ');

                var wc = wordChunks[0];

                string firstTwo = wc.Substring(0, 2);
                string firstThree = wc.Substring(0, 3);
                string firstFour = wc[1..4];

                string lastThree = wordChunks[0].Substring(wc.Length - 3);
                string lastTwo = wordChunks[0].Substring(wc.Length - 2);

                string[] vowels = new[] { "a", "i", "u", "e", "o" };
                int vowelCounter = 0;

                int oCount = 0; int aCount = 0; int iCount = 0; int uCount = 0; int eCount = 0;

                for (int i = 0; i < wordChunks.Length; i++)
                {
                    for (int j = 0; j < vowels.Length; j++)
                    {
                        var cw = vowels[j];

                        if (wordChunks[i] == cw) vowelCounter++;

                        if (wordChunks[i].Equals("a", sc)) aCount++;
                        if (wordChunks[i].Equals("i", sc)) iCount++;
                        if (wordChunks[i].Equals("e", sc)) eCount++;
                        if (wordChunks[i].Equals("o", sc)) oCount++;
                        if (wordChunks[i].Equals("u", sc)) uCount++;
                    }
                }

                string startChar = wc[0].ToString().ToLower();
                string lastChar = wc[wc.Length - 1].ToString().ToLower();

                double female = 0; double male = 0;

                female += CommonNameParser.FirstFour(inputWrd, false);
                male += CommonNameParser.FirstFour(inputWrd, true);
                female += CommonNameParser.LastFour(inputWrd, false);
                male += CommonNameParser.LastFour(inputWrd, true);
                female += CommonNameParser.MiddleFour(inputWrd, false);
                male += CommonNameParser.MiddleFour(inputWrd, true);
                female += CommonNameParser.SecondFour(inputWrd, false);
                male += CommonNameParser.SecondFour(inputWrd, true);
                female += CommonNameParser.ShiftMatching(inputWrd, false, 3);
                male += CommonNameParser.ShiftMatching(inputWrd, true, 3);

                //Vowels counter
                if (aCount > 1 && iCount > 0) female += 0.2;
                if (aCount > 0 && iCount > 0 && eCount > 0) female += 0.2;
                if (aCount > 0 && iCount == 0 && eCount == 0)male += 0.2;
                if (aCount > 1 && eCount > 1) female += 0.2;

                //Common pattern matching
                //FEMALE common lastThree characters
                female = (lastThree) switch
                {
                    var x when
                    x == "ava" ||
                    x == "aby" || x == "myn" || x == "idy" || x == "tea" ||
                    x == "tzy" || x == "umn" || x == "tyn" || x == "ree" ||
                    x == "ami" || x == "emi" || x == "rie" ||
                    x == "uby" || x == "rra" || x == "ova" || x == "eva" ||
                    x == "hea" || x == "mea" || x == "lea" || x == "lby" ||
                    x == "ela" || x == "iya" || x == "cey" || x == "iea" ||
                    x == "aia" || x == "nya" || x == "nna" || x == "eya" ||
                    x == "yue" || x == "yui" || x == "udy" || x == "oly" ||
                    x == "yam" || x == "isy" || x == "mia" || x == "yua" ||
                    x == "nta" || x == "ove" || x == "que" || x == "cah" ||
                    x == "nee" || x == "eya" || x == "ssa" || x == "ige" ||
                    x == "oey" || x == "ira" || x == "yra" || x == "cia" ||
                    x == "ely" || x == "ity" || x == "een" || x == "nce" ||
                    x == "iza" || x == "mra" || x == "ail" || x == "bey" ||
                    x == "rla" || x == "acy" || x == "ety" || x == "ice" ||
                    x == "lla" || x == "abi" || x == "ebi" || x == "dys" ||
                    x == "ini" || x == "dah" || x == "eno" || x == "lli" ||
                    x == "mah" || x == "una" || x == "rna" || x == "une" ||
                    x == "sta" || x == "ita" || x == "ema" || x == "ele" ||
                    x == "aki" || x == "omi" || x == "uki" || x == "kie" ||
                    x == "idi" || x == "era" || x == "ena" || x == "eta" ||
                    x == "nie" || x == "kay" || x == "mma" || x == "lla" ||
                    x == "hia" || x == "lyn" || x == "ila" || x == "una" ||
                    x == "ria" || x == "nor" || x == "fia" || x == "ope" ||
                    x == "ora" || x == "lia" || x == "eah" || x == "ija" ||
                    x == "aya" || x == "nah" || x == "ina" || x == "ice" ||
                    x == "ley" || x == "inn" || x == "per" || x == "dia" ||
                    x == "ara" || x == "ose" || x == "ary" || x == "ise" ||
                    x == "bel" || x == "sia" || x == "loe" || x == "igh" ||
                    x == "lly" || x == "lie" || x == "cie" || x == "ren" ||
                    x == "cca" || x == "ynn" || x == "zie" || x == "nce" ||
                    x == "eth" || x == "eli" || x == "omi" || x == "yja" ||
                    x == "ola" || x == "any" || x == "tta" || x == "ebe" ||
                    x == "nna" || x == "vie" || x == "yah" || x == "yne" ||
                    x == "ssa" || x == "ery" || x == "ana" || x == "ith" ||
                    x == "ani" || x == "ati" || x == "ida" || x == "lah" ||
                    x == "ren" || x == "lee" || x == "via" || x == "ona" ||
                    x == "wen" || x == "vka" || x == "tal" || x == "lin" ||
                    x == "ncy" || x == "ida" || x == "lsa" || x == "rya" ||
                    x == "uel" || x == "hay" || x == "tha" || x == "xie" ||
                    x == "ney" || x == "owe" || x == "len" || x == "eah" ||
                    x == "iah" || x == "yla" || x == "nda" || x == "rly" ||
                    x == "lah" || x == "tzi" || x == "ata" || x == "yna" ||
                    x == "lda" || x == "ber" || x == "lei" || x == "vay" ||
                    x == "rai" || x == "loh" || x == "nca" || x == "ica" ||
                    x == "era" || x == "uri" || x == "ena" || x == "aly" ||
                    x == "nza" || x == "rmi" || x == "isa" || x == "nri" ||
                    x == "rai" || x == "idi" || x == "ima" || x == "ynn" ||
                    x == "ssa" || 
                    x == "oma" => female += 0.4,
                    _ => female += 0
                };

                //Common pattern matching
                //MALE common lastThree characters

                if (startChar == "a" && wc.EndsWith("n"))
                    male += 0.2;

                male = (lastThree) switch
                {
                    var x when
                    x == "elo" || x == "les" || x == "ino" || x == "nho" ||
                    x == "xon" || x == "con" || x == "jon" || x == "moa" ||
                    x == "yan" || x == "ton" || x == "bon" || x == "gon" ||
                    x == "lmy" || x == "lmi" || x == "cka" || x == "uly" ||
                    x == "aji" || x == "ben" || x == "gue" || x == "poe" ||
                    x == "doh" || x == "agi" || x == "dab" || x == "oue" ||
                    x == "one" || x == "leo" || x == "ipo" || x == "imo" ||
                    x == "com" || x == "ime" || x == "abe" || x == "ine" ||
                    x == "yde" || x == "sac" || x == "koa" || x == "ian" ||
                    x == "och" || x == "nks" || x == "ugh" || x == "lus" ||
                    x == "hop" || x == "coy" || x == "eif" || x == "ain" ||
                    x == "sen" || x == "cos" || x == "wes" || x == "xen" ||
                    x == "dox" || x == "dro" || x == "rix" || x == "dhi" ||
                    x == "nny" || x == "lio" || x == "leb" || x == "ilo" ||
                    x == "aim" || x == "ven" || x == "teo" || x == "rth" ||
                    x == "ent" || x == "ggs" || x == "phy" || x == "lel" ||
                    x == "lem" || x == "tos" || x == "roy" || x == "nco" ||
                    x == "hir" || x == "kob" || x == "axx" || x == "ear" ||
                    x == "yro" || x == "bir" || x == "sef" || x == "fan" ||
                    x == "rmo" || x == "uda" || x == "aro" || x == "bby" ||
                    x == "elz" || x == "eer" || x == "ris" || x == "ers" ||
                    x == "ken" || x == "sby" || x == "est" || x == "arl" ||
                    x == "nce" || x == "dre" || x == "cio" || x == "seo" ||
                    x == "deo" || x == "kin" || x == "ger" || x == "eus" ||
                    x == "rav" || x == "tis" || x == "mza" || x == "tan" ||
                    x == "ncy" || x == "loh" || x == "eem" || x == "dul" ||
                    x == "aul" || x == "uro" || x == "ius" || x == "han" ||
                    x == "ram" || x == "jun" || x == "ald" || x == "suf" ||
                    x == "tus" || x == "itt" || x == "anu" || x == "ake" ||
                    x == "ban" || x == "dax" || x == "xis" || x == "ipp" ||
                    x == "ias" || x == "age" || x == "lip" || x == "das" ||
                    x == "blo" || x == "nin" || x == "gar" || x == "ndy" ||
                    x == "ota" || x == "sir" || x == "lik" || x == "gio" ||
                    x == "nte" || x == "mad" || x == "eid" || x == "rdo" ||
                    x == "cus" || x == "ayn" || x == "ruz" || x == "rus" ||
                    x == "lil" || x == "hen" || x == "rew" || x == "sco" ||
                    x == "mus" || x == "mon" || x == "ias" || x == "las" ||
                    x == "olt" || x == "nox" || x == "obe" || x == "ash" ||
                    x == "ham" || x == "uel" || x == "thy" || x == "car" ||
                    x == "hur" || x == "ing" || x == "nzo" || x == "las" ||
                    x == "rge" || x == "ker" || x == "ell" || x == "yce" ||
                    x == "ike" || x == "ego" || x == "end" || x == "ler" ||
                    x == "mir" || x == "eys" || x == "den" || x == "yer" ||
                    x == "lan" || x == "don" || x == "mas" || x == "hua" ||
                    x == "eph" || x == "zra" || x == "hys" || x == "ory" ||
                    x == "rek" || x == "mon" || x == "cas" || x == "ien" ||
                    x == "ver" || x == "mes" || x == "ant" || x == "jah" ||
                    x == "ack" || x == "ert" || x == "rdo" || x == "tin" ||
                    x == "ick" || x == "ter" || x == "ith" || x == "nar" ||
                    x == "arc" || x == "ran" || x == "hew" || x == "ark" ||
                    x == "yle" || x == "vin" || x == "aac" || x == "vin" ||
                    x == "ard" || x == "per" || x == "ony" || x == "iel" ||
                    x == "der" => male += 0.4,
                    _ => male += 0
                };

                //Fallback
                bool genderEqual = false;

                if (female > male)
                {
                    t = "female";
                    genderEqual = true;
                }
                else if (male > female)
                {
                    t = "male";
                    genderEqual = true;
                }

                if (male == female && aCount > 0 && eCount > 0 && iCount > 0)
                {
                    t = "female";
                    genderEqual = true;
                }
                else if (male == female && aCount > 1 && eCount > 0)
                {
                    t = "female";
                    genderEqual = true;
                }
                else if (male == female && aCount > 1 && eCount > 1)
                {
                    t = "female";
                    genderEqual = true;
                }

                if (!genderEqual)
                    t = "male";

                //Debug.Log("Gender : " + t + " || " + "Male Value : " + male + " || " + "Female Value : " + female);

                finalVal.femaleVal = female / 100;
                finalVal.maleVal = male / 100;
                finalVal.value = t;
            }
            return finalVal;
        }
    }
}
