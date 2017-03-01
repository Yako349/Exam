using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using RandomStringGenerator;
using System.Runtime.Serialization;

namespace JsonParserEncrypt
{
  /*  public class Vernam
    {
        private string _text;
        private string _3ncryp73d;
        private int[] random;
        public Vernam(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                text = "test";
            }
            _text = text;
            _3ncryp73d = Encrypt();
        }
        public string Encrypt()
        {
            char[] chartext = _text.ToCharArray();

            for (int i = 0; i < chartext.Length; i++)
            {
                _3ncryp73d += Convert.ToInt32(chartext[i], CultureInfo.CurrentCulture);
            }
            while ((_3ncryp73d.Length) % 5 != 0)
            {
                _3ncryp73d += "0";
            }
            List<string> encryptedDivided = new List<string>();


            for (int i = 0; i < _3ncryp73d.Length; i += 5)
            {
                string temp = "";
                temp += _3ncryp73d.Substring(i, 5);
                encryptedDivided.Add(temp);
            }
            random = new int[encryptedDivided.Count];
            NR3Generator rand = new NR3Generator();
            for (int i = 0; i < encryptedDivided.Count; i++)
            {
                random[i] = Convert.ToInt32(rand.NextUInt(10000, 99999));
                encryptedDivided[i] = DigitPerDigitSum(encryptedDivided[i], random[i], 5).ToString();
            }
            _3ncryp73d = "";
            foreach (string item in encryptedDivided)
            {
                _3ncryp73d += item;
            }
            return _3ncryp73d;
        }
        private int DigitPerDigitSum(string a, int b, int digitNum)
        {
            int[] digitsA = new int[digitNum];
            int[] digitsB = new int[digitNum];
            int[] result = new int[digitNum];
            for (int i = 0; i < digitNum; i++)
            {
                digitsA[i] = Convert.ToInt32(a.ToString().Substring(i, 1));
                digitsB[i] = Convert.ToInt32(b.ToString().Substring(i, 1));
                result[i] = (digitsA[i] + digitsB[i]) % 10;
            }
            string temp = "";
            foreach (int item in result)
            {
                temp += item.ToString();
            }
            return Convert.ToInt32(temp);
        }
        public string Encrypted
        {
            get
            {
                return _3ncryp73d;
            }
        }
        public int[] Key
        {
            get
            {
                return random;
            }
        }
    }*/
    public class VeramBytes
    {
        private string key = "";
        private string plain = "";
        private string[] result;
        /// <summary>
        /// It allows to use a bit per bit
        /// Vernam cryptography inserting only a
        /// plaintext and eventually a key
        /// </summary>
        /// <param name="plaintext">The text to encrypt.</param>
        /// <param name="key">The key you want to use. Useful for decrypt</param>


        public VeramBytes(string plaintext)
        {
            
            if (String.IsNullOrEmpty(plaintext) || String.IsNullOrWhiteSpace(plaintext))
            {
                throw new InvalidTextException();
            }
            else
            {
                plain = plaintext;
                string[] bitPlain = BitConversion.BitConvert(plain);
                StringGenerator generator = new StringGenerator();
                key = generator.GenerateString(plain.Length);
                string[] bitKey = BitConversion.BitConvert(key);
                result = VernamResult(bitPlain, bitKey);
               
            }
        }
        /// <summary>
        /// Returns the current key
        /// </summary>
        public string Key
        {
            get
            {
                return key;
            }
        }
        /// <summary>
        /// Returns the current plaintext
        /// </summary>
        public string Plaintext
        {
            get
            {
                return plain;
            }
        }
        /// <summary>
        /// Returns the current result
        /// </summary>
        public string[] Result
        {
            get
            {
                return result;
            }
        }
        public string[] VernamResult(string[] plain, string[] key)
        {
            string[] results = new string[plain.Length];

            for (int i = 0; i < plain.Length; i++)
            {
                results[i] = Convert.ToString(Convert.ToInt64(plain[i]) ^ Convert.ToInt64(key[i]),2);
            }
           /* foreach (var item in results)
            {
                Console.WriteLine(item);
            }*/
            return results;
        }
     
        public class InvalidTextException : Exception
        {
            string message;
            public InvalidTextException() : base()
            {
                message = "Invalid text inserted";
            }
            public string Message
            {
                get
                {
                    return message;
                }
            }
        }
       
        }
    public static class BitConversion
    {
        /// <summary>
        /// Converts a string in
        /// a series of bit returned
        /// as a string
        /// </summary>
        /// <param name="value">The string to convert</param>
        public static string[] BitConvert(string value)
        {
            UTF8Encoding enc = new UTF8Encoding();
            BitArray[] bits = new BitArray[enc.GetByteCount(value)];
            string[] ret = new string[value.ToCharArray().Length];
            for (int i = 0; i < value.ToCharArray().Length; i++)
            {
                char[] ch = new char[] { value.ToCharArray()[i] };
                bits[i] = new BitArray(enc.GetBytes(ch));
                string s = "";
                for (int j = 0; j < bits[i].Length; j++)
                {
                    s+= Convert.ToInt32(bits[i][j]).ToString();
                }
                ret[i] = s;
            }
            return ret;

        }
        
      

        /// <summary>
        /// Contains all the 
        /// UTF-8 Characters
        /// codification
        /// </summary>
        enum UTF_8
        {
            SPACE = 00100000,
            EXC_MARK = 00100001,
            QUOT_MARK = 00100010,
            NUM_SIGN = 00100011,
            DOLLAR = 00100100,
            PERCENT = 00100101,
            AMPSAND = 00100110,
            APOSTROPHE = 00100111,
            LEFT_PAR = 00101000,
            RIGHT_PAR = 00101001,
            AST = 00101010,
            PLUS = 00101011,
            COMMA = 00101100,
            MINUS = 00101101,
            DOT = 00101110,
            SOL = 00101111,
            ZERO = 00110000,
            ONE = 00110001,
            TWO = 00110010,
            THREE = 00110011,
            FOUR = 00110100,
            FIVE = 00110101,
            SIX = 00110110,
            SEVEN = 00110111,
            EIGHT = 00111000,
            NINE = 00111001,
            COLON = 00111010,
            SEMICOL = 00111011,
            LESS = 00111100,
            EQUAL = 00111101,
            GREAT = 00111110,
            QUEST_MARK = 00111111,
            AT = 01000000,
            A = 01000001,
            B = 01000010,
            C = 01000011,
            D = 01000100,
            E = 01000101,
            F = 01000110,
            G = 01000111,
            H = 01001000,
            I = 01001001,
            J = 01001010,
            K = 01001011,
            L = 01001100,
            M = 01001101,
            N = 01001110,
            O = 01001111,
            P = 01010000,
            Q = 01010001,
            R = 01010010,
            S = 01010011,
            T = 01010100,
            U = 01010101,
            V = 01010110,
            W = 01010111,
            X = 01011000,
            Y = 01011001,
            Z = 01011010,
            LEFT_SQR_BRACKET = 01011011,
            REV_SOL = 01011100,
            RIGHT_SQR_BRACKET = 01011101,
            CIRCFLX_ACCENT = 01011110,
            LOW_LINE = 01011111,
            GRAVE_ACCENT = 01100000,
            a = 01100001,
            b = 01100010,
            c = 01100011,
            d = 01100100,
            e = 01100101,
            f = 01100110,
            g = 01100111,
            h = 01101000,
            i = 01101001,
            j = 01101010,
            k = 01101011,
            l = 01101100,
            m = 01101101,
            n = 01101110,
            o = 01101111,
            p = 01110000,
            q = 01110001,
            r = 01110010,
            s = 01110011,
            t = 01110100,
            u = 01110101,
            v = 01110110,
            w = 01110111,
            x = 01111000,
            y = 01111001,
            z = 01111010,
            LEFT_CURLY_BRACKET = 01111011,
            PIPE = 01111100,
            RIGHT_CURLY_BRACKET = 01111101,
            TILDE = 01111110
        }
         }
            
    }
        
    



    