using System;
using System.Collections.Generic;
using System.Text;

namespace algorytmy_i_struktury_danych
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string ciąg_znaków;
            string wzorzec;
            Console.WriteLine("Podaj ciag");
            ciąg_znaków = Console.ReadLine();
            Console.WriteLine("Podaj wzorzec");
            wzorzec = Console.ReadLine();
            Console.WriteLine("Algorytm Sundaya:");
            Console.WriteLine(sundaya(ciąg_znaków, wzorzec));
            Console.WriteLine("Algorytm naiwny:");
            Console.WriteLine(Naiwny(ciąg_znaków,wzorzec));
        }

        static int Naiwny(string ciag_, string wzorzec_)
        {
            var a = ciag_.Length;
            var b = wzorzec_.Length;
            int licznik = 0;
             for (int i = 0; i <= a - b; i++)
            {
                
                if(matchesAt(ciag_,i,wzorzec_))
                 licznik = licznik + 1;
           
            }
            return licznik;
        }
       
            static int sundaya(string ciag_,string wzorzec_)
            {
            var a = ciag_.Length;
            var b = wzorzec_.Length;
            int licznik = 0;

                var lastp = new Dictionary<char, int>();
                for (int i = 0; i <=255; i++)
                {
                    lastp.Add((char)(i), -1);
                }
                for (int i = 0; i < wzorzec_.Length;i++)
                {
                    lastp[wzorzec_[i]] = i;
                }

            for (int i = 0; i < a - b;) 
              {
                if (matchesAt(ciag_, i, wzorzec_))
                    licznik++;
               
                
               
                    i = i + b - lastp[ciag_[i + b]];
              }
            if (matchesAt(ciag_, a-b, wzorzec_))
                licznik++;
            return licznik;
            }


        static bool matchesAt(string T, int p, string W)
        {
            if (p >= 0 && p <= T.Length - W.Length)
            {
                for (int i = 0; i <= W.Length - 1; i++)
                {
                    if (W[i] != T[p + i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}




