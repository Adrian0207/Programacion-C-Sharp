﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace StackPalindromo
{
    class CStack
    {
        private int p_index;
        private ArrayList list;

        public CStack()
        {
            list = new ArrayList();
            p_index = -1;
        }
        //public int count { get { return list.Count; } }
        public int getCount()
        {
            int count = list.Count;
            return count;
        }

        public void clear()
        {
            list.Clear();
            p_index = -1;
        }
        public object peek()
        {
            return list[p_index];
        }
        public void push(object item)
        {
            list.Add(item);
            p_index++;
        }
        public object pop()
        {
            object obj;
            try
            {
                obj = list[p_index];
                list.RemoveAt(p_index);
                p_index--;
            }
            catch (Exception e)
            {
                obj = null;
                throw new Exception ("Fuera de limite");
                
            }
            return obj;   
        }
        public Array toArray()
        {
            Array arr = new Array[list.Count];
            return arr = list.ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CStack alist = new CStack();
            string ch;
            string word = Console.ReadLine();
            bool isPalindromo = true;
            for (int x = 0; x < word.Length; x++)
                alist.push(word.Substring(x, 1));
            Array arr = alist.toArray();
            int pos = 0;
            try              
            {
                while (alist.getCount() > 0)
                //while (alist.count > 0)
                {
                    ch = alist.pop().ToString();
                    if (alist == null)
                        break;

                    if (ch != word.Substring(pos, 1))
                    {
                        isPalindromo = false;
                        break;
                    }
                    pos++;
                }
                if (isPalindromo)
                    Console.WriteLine(word + " es palindromo");
                else
                    Console.WriteLine(word + " no es palindromo");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
            Console.Read();
        }
    }
}