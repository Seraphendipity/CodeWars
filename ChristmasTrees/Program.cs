

namespace ChristmasTrees
{

//-----------------------------------------------------------------------------
using System;
using System.Text;
public class Kata
{
    public static string CustomChristmasTree(string chars, int n){
        //coding and coding..
        int j = 0; // Int to Loop Through Chars

        StringBuilder treesb = new StringBuilder((2*n)^2); // Tree String Builder

        // Layering Leaf Lines
        for(int i = n-1; i >= 0; i--) {
            Console.WriteLine(i);
            treesb.Append(' ', i).AppendLine(Leaves(n-i));
        }

        // Layering Trunks
        for (int i = n/3; i > 0; i--) {
            treesb.Append(' ', n-1).AppendLine("|");
        }
        treesb.Remove(treesb.Length-1,1);

        return treesb.ToString();
    
        // Constructing Leaf Lines
        string Leaves(int x) {
            StringBuilder leavessb = new StringBuilder(n*2);
            
            for(int i = x; i > 0; i--) {
                leavessb.Append(chars[j++]).Append(' ');    
                if(j>=chars.Length) {
                    j = 0;
                }
            }
            leavessb.Length -= 1; 
            // Inspired By https://stackoverflow.com/questions/3395286/remove-last-character-of-a-stringbuilder/3395329
            return leavessb.ToString();
        }
    }
//-----------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Kata.CustomChristmasTree("123",3));

        }
    }

    }
}
