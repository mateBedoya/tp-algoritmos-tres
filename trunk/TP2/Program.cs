using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TP2
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            List<int> enteros = new List<int>();
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(4);
            enteros.Add(2);
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(0);
            enteros.Add(0);
            List<int> copiaDeEnteros = enteros; 

            int indice = copiaDeEnteros.Count() - 1;
            while (indice >= 0)
            {
                if (copiaDeEnteros[indice] == 0)
                {
                    enteros.RemoveAt(indice);
                    enteros.Insert(indice, 8);
                }
                indice--;
            }
            foreach (int entero in enteros)
            {
                Console.WriteLine(entero);
            }
           
           
      
            
            
           

        }
    }
}
