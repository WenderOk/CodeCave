using System.Threading;
using System.Text;

namespace AsyncWait
{
    class AsyncWaitClass
    {
        static void Main(string[] args)
        {
            string[] files = {
                "source1.txt",
                "source2.txt",
                "source3.txt"
            };
            AsyncReader[] asrArr = new AsyncReader[3];
            for(int i = 0; i < asrArr.Length; ++i)
            asrArr[i] = new AsyncReader(
                new FileStream(files[i],
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, FileOptions.Asynchronous),100);
            foreach (AsyncReader asr in asrArr)
            Console.WriteLine(asr.EndRead());
        }
    }
    class AsyncReader
    {
        FileStream stream;
        byte[] data;
        IAsyncResult asRes;
        public AsyncReader(FileStream s, int size)
        {
            stream = s;
            data = new byte[size];
            asRes = s.BeginRead(data, 0, size, null, null);
        }

        public string EndRead()
        {
            int countByte = stream.EndRead(asRes);
            stream.Close();
            Array.Resize(ref data, countByte);
            return string.Format("Файл: {0}\n{1}\n\n",
            stream.Name,
            Encoding.UTF8.
            GetString(data));
        }
    }
}