using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ProjetoTCC.Common
{
    public class Time
    {
        /// <summary>
        /// Executa a função/evento do parâmetro a cada um segundo.
        /// </summary>
        public static void KeepExecuting(EventHandler e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(e);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
    }

    public class Image
    {
        /// <summary>
        /// Converte um ImageSource para um Array de bytes : byte[]
        /// </summary>
        public static byte[] Byte(ImageSource imageSource)
        {
            PngBitmapEncoder p = new PngBitmapEncoder();
            BitmapEncoder encoder = p;
            byte[] bytes = null;
            var bitmapSource = imageSource as BitmapSource;
            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    bytes = stream.ToArray();
                }
            }

            return bytes;
        }
    }

    public class Validation
    {
        public static void Reset()
        {
            ErrorMessage = "";
        }
        public static bool HasErrors()
        {
            if (ErrorMessage == null || ErrorMessage == "") return false; else return true;
        }
        public static string ErrorMessage;
        public static void Error(string erro)
        {
            if (Empty(ErrorMessage)) ErrorMessage += "•" + erro;
            else ErrorMessage += "\n•" + erro;

        }
        public static bool Empty(string text)
        {
            try { if (text.TrimStart().TrimEnd() == "") return true; else return false; }
            catch { return true; }
        }
        public static bool Email(string email)
        {
            if (Empty(email))
                return true;
            return Patters.Email(email);
        }
        public static bool EmailObrigatorio(string email)
        {
            if (Empty(email))
            {
                Error("Email precisa ser preenchido");
                return false;
            }
            return Patters.Email(email);
        }
        public class Patters
        {
            public static bool Email(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    Error("Email inválido");
                    return false;
                }
            }
        }
        public class Only
        {

            public static bool Letters(string input)
            {
                return Regex.IsMatch(input, "^[a-zA-Z]+$");
            }

            public static bool Numbers(string input)
            {
                return Regex.IsMatch(input, "^[0-9]+$");
            }

            public static bool Both(string input)
            {
                return Regex.IsMatch(input, "^[a-zA-Z0-9_]+$");
            }


        }

    }

    public class Message
    {
        public static void Warning(string message, string title, int duration)
        {
            View.Warning.Warning n = new View.Warning.Warning(title, message, duration);
            n.Show();
        }
        public static void Warning(string message, string title)
        {
            View.Warning.Warning n = new View.Warning.Warning(title, message, 6);
            n.Show();
        }
        public static void Warning(string message)
        {
            View.Warning.Warning n = new View.Warning.Warning("Notificação", message, 6);
            n.Show();
        }

        /// <summary>
        /// 1 - If the first answer have been clicked and 2 - if the 2nd one;
        /// </summary>
        public static int Ask(string question,string title, string resp1, string resp2, int duration)
        {
            View.Warning.Question q = new View.Warning.Question(title, question, duration, resp1, resp2);
            if ((bool)q.ShowDialog()) return 1; else return 2;
        }

        public static int Ask(string question,  string resp1, string resp2 )
        {
            View.Warning.Question q = new View.Warning.Question("Atenção",  question, 7, resp1, resp2);
            q.ShowDialog();
            return q.Result;
        }

    }
}
