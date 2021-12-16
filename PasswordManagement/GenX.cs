using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PasswordManagement
{
    class GenX
    {
        static readonly char[] AvailableCharacters =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_', '!',
            '@', '#', '$', '%', '^', '&', '*', '(', ')'
        };

        internal static string GenerateIdentifier(int length)
        {
            char[] identifier = new char[length];
            byte[] randomData = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomData);
            }

            for (int idx = 0; idx < identifier.Length; idx++)
            {
                int pos = randomData[idx] % AvailableCharacters.Length;
                identifier[idx] = AvailableCharacters[pos];
            }

            return new string(identifier);
        }
    }

    static class StringExtensions
    {
        public static int CountLower(this string value)
        {
            int count = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLower(value[i]))
                {
                    count++;
                }
            }

            return count;
        }

        public static int CountUpper(this string value)
        {
            int count = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsUpper(value[i]))
                {
                    count++;
                }
            }

            return count;
        }

    }

    static class ImageExtensions
    {
        public static byte[] ImageToByte(this Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));

            
        }
    }

    static class InvokeExtensions
    {
        public static void SynchronizedInvoke(this ISynchronizeInvoke sync, Action action)
        {
            if(!sync.InvokeRequired)
            {
                action();

                return;
            }

            sync.Invoke(action, new object[] { });
        }
    }

    class ListViewCustom : ListView
    {

        [Description("Occurs when collection has been added, removed and cleared from")]
        public event EventHandler<EventArgs> CollectionChanged;

        public void AddItems(string name, int imageIndex)
        {
            base.Items.Add(name, imageIndex);
            if (CollectionChanged != null)
                CollectionChanged(this, EventArgs.Empty);
        }

        public void RemoveAtItems(int index)
        {
            base.Items.RemoveAt(index);
            if (CollectionChanged != null)
                CollectionChanged(this, EventArgs.Empty);
        }

        public void ClearItems()
        {
            base.Items.Clear();
            if (CollectionChanged != null)
                CollectionChanged(this, EventArgs.Empty);
        }
        
    }
}
