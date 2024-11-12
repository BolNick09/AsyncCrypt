using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCrypt
{
    internal class Crypter
    {
        public string OrigText { get; set; }
        public string CryptedText { get; set; }

        private string origFileName;
        private string cryptedFileName;

        public Crypter(string origFileName, string cryptedFileName)
        {
            this.origFileName = origFileName;
            this.cryptedFileName = cryptedFileName;
        }

        public async Task ReadText()
        {
            try
            {
                using (StreamReader reader = new StreamReader(origFileName))
                {
                    OrigText = await reader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка чтения файла: " + ex.Message);
            }
        }
        public void EncryptText()
        {
            byte[] origBytes = Encoding.UTF8.GetBytes(OrigText);
            byte[] cryptedBytes = new byte[origBytes.Length];

            for (int i = 0; i < origBytes.Length; i++)
                cryptedBytes[i] = (byte)(origBytes[i] + 1);


            CryptedText = Encoding.UTF8.GetString(cryptedBytes);
        }
        public async Task WriteCryptedText()
        {
            StreamWriter writer = new StreamWriter(cryptedFileName, false, Encoding.UTF8);
            await writer.WriteAsync(CryptedText);
            writer.Close();
        }

        public async Task EncryptFile()
        {
            await ReadText();
            EncryptText();
            await WriteCryptedText();
        }
    }
}
