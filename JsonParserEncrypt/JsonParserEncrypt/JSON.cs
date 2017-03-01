using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BlowFishCS;



namespace JsonParserEncrypt
{
    public class JSON
    {
        /*
         * Generating two streams:
         * ♦ one to read on the file
         * ♦ one to write on it
         * 
         */
        StreamWriter JsonSW;
        StreamReader JsonSR;
        private string _path;
        public JSON(string path)
        {
            _path = path;
            FileInfo f = new FileInfo(path);
            if (f.Extension != ".json")
            {
                throw new WrongExtensionException("The file extension isn't the right one.\nThe file extension must be '.json'");
            }
            else
            {
                _path = path;
            }

        }
        public void Write(object value)
        {
            
            if(JsonSW != null)
            {
                JsonSW.Write(value.ToString());
            }
            else
            {
                throw new StreamClosedException("The stream was closed, so the writing has been aborted");

            }
        }

        /*   public void Write(string writeWhat)
           {

               if (JsonStream.CanWrite)
               {
                   byte[] arr = ToByteArray(writeWhat);
                   JsonStream.BeginWrite(arr, 0, arr.Length,,)
                }
           }*/
        
        public string Read()
        {
            string file;
            using (StreamReader SR = new StreamReader(_path))
            {
                try
                {
                    file = SR.ReadToEnd();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return file;
            }
        }
        public void OpenRead()
        {
            JsonSR = new StreamReader(_path);
        }
        public void OpenWrite()
        {
            JsonSW = new StreamWriter(_path, true);
        }
        public void CloseAll()
        {
            JsonSR.Close();
            JsonSW.Close();
        }
        public void CloseRead()
        {
            JsonSR.Close();
        }
        public void CloseWrite()
        {
            JsonSW.Close();
        }
        private byte[] ToByteArray(string data)
        {
            char[] charConv = data.ToCharArray();
            byte[] array = new byte[charConv.Length - 1];

            for (int i = 0; i < charConv.Length - 1; i++)
            {
                array[i] = Convert.ToByte(charConv[i]);
            }
            return array;
        }

        public class WrongExtensionException : Exception
        {
            string _mex;
            public WrongExtensionException(string message) : base(message)
            {
                _mex = message;
            }
            override public string Message
            {
                get { return _mex; }
            }
        }
        public class StreamClosedException : Exception
        {
            string _mex;
            public StreamClosedException(string message) : base(message)
            {
                _mex = message;
            }
            public new string Message
            {
                get
                {
                    return base.Message;
                }
            }
        }

    }
}
