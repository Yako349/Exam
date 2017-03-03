using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management.Instrumentation;
using System.Diagnostics;
using JsonParserEncrypt;



namespace TestLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string wtw = Ipsum.GetPhrase(1500);
            /* Vernam v = new Vernam(wtw);
             JSON json = new JSON(Environment.CurrentDirectory + "\\JSON.json");
             Console.WriteLine(v.Encrypted);
             string file = json.Read();*/
            /* VeramBytes vb = new VeramBytes("test");
             foreach (var item in vb.Plaintext)
             {
                 Console.WriteLine(item);
             }
            */
            // JsonParserEncrypt.BitConverter.Convert(wtw);
            VeramBytes ver = new VeramBytes(wtw);
            Debug.WriteLine(ver.Plaintext + "\n" + ver.Key + "\n");
            
            foreach (var item in ver.Result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Console.InputEncoding.ToString());

            Console.ReadKey();
        }
    }
}
