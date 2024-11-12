using System.Text;

namespace AsyncCrypt
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            String[] OrigFileNames =
            {
                "file1.txt",
                "file2.txt",
                "file3.txt",
                "file4.txt"
            };
            String[] CryptedFileNames =
            {
                "cfile1.txt",
                "cfile2.txt",
                "cfile3.txt",
                "cfile4.txt"
            };
            Task[] tasks = new Task[4];

            Crypter[] crypters = 
              {
                new Crypter(OrigFileNames[0], CryptedFileNames[0]),
                new Crypter(OrigFileNames[1], CryptedFileNames[1]),
                new Crypter(OrigFileNames[2], CryptedFileNames[2]),
                new Crypter(OrigFileNames[3], CryptedFileNames[3])
            };
            for (int i = 0; i < OrigFileNames.Length; i++)
            {
                int index = i;
                await crypters[index].EncryptFile();
            }

            Console.WriteLine("Файлы зашифрованы");


        }
    }
}
