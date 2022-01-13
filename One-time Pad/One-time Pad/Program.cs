using System;

namespace One_time_Pad
{
    class Program
    {
        static public Random gen = new Random();
        static string GetKey ( string message)
        {
            string key = "";
            foreach (char maybeLetter in message)
            {
                bool isLetterUppercase = maybeLetter >= 'A' && maybeLetter <= 'Z';
                bool isLetterLowercase = maybeLetter >= 'a' && maybeLetter <= 'z';
                bool isLetter = isLetterUppercase || isLetterLowercase;
                if (isLetter)
                {
                    if(isLetterUppercase)
                    {
                        key += (char)((maybeLetter - 'A' + gen.Next(65,91)) % 26 + 'A');
                    }
                    else
                    {
                        key += (char)((maybeLetter - 'a' + gen.Next(97, 124)) % 26 + 'a');
                    }
                }
                else
                {
                    key += maybeLetter;
                }
            }
            return key;
        }

        static string GetMessage(string key)
        {
            string message = "";
            foreach (char maybeLetter in key)
            {
                bool isLetterUppercase = maybeLetter >= 'A' && maybeLetter <= 'Z';
                bool isLetterLowercase = maybeLetter >= 'a' && maybeLetter <= 'z';
                bool isLetter = isLetterUppercase || isLetterLowercase;
                if (isLetter)
                {
                    if (isLetterUppercase)
                    {
                        message += (char)((maybeLetter - 'A' + gen.Next(65, 91)) % 26 + 'A');
                    }
                    else
                    {
                        message += (char)((maybeLetter - 'a' + gen.Next(97, 124)) % 26 + 'a');
                    }
                }
                else
                {
                    message += maybeLetter;
                }
            }
            return message;
        }
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string key = GetKey(message);
            Console.WriteLine(key);
        }
    }
}
