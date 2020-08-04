using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }
    }

    public class Finder {
    
        /* You are at position [0, 0] in maze NxN and you can only move in one 
        of the four cardinal directions (i.e. North, East, South, West).
         Return true if you can reach position [N-1, N-1] or false otherwise.

        Empty positions are marked .. Walls are marked W. 
        Start and exit positions are empty in all test cases.
        */

        /* Wall Lines
            You can trace the walls, if they start from one edge and 
            go to either the opposite edge or the edge across the y=x line 
            (from 0,0 to -N,-N), no path can be made. If the walls end in empty
            space or the other edge on the same side of y=x, it cannot
            stop the path. Note that the walls, unlike the tracer, is considered
            a line in cardinal directions AND diagonals.

            Potentially implement both this and standard tracer, as they are similar,
            using whichever based on if the walls or empty space take up more space.
            (note that the path may need a bias, as walls have more complex and thus
            potentially more lines in the same space due to diagonals counting).

            However, a standard tracer will prove more practical based on the mere fact
            that there are more problems which are not forseeably solvable with
            wall lines.
        */

        /* Tracer

        */

        public static bool PathFinder(string maze) {
            // Find Edge Walls
            // Mark Right and Top Walls with +, mark Left and Bottom Edgewalls with -.
            // EC: (Edge Case) Assuming walls cannot be directly on 0,0 and N-1,N-1.
            // EC: 1x1 Grid

            // Initialization
            // Find N (how many units across).
            char[] mazec = maze.ToCharArray();

            int n = -1;
            while(mazec[++n] != '\n'); 
            int m = n+1; // Used to jump to next row
            //Console.WriteLine("n: "+n);

            int index = 0;

            // Bottom-Left Walls (walls with y=N-1 or x=0)
            // If either list has no values, the space-tracer may pass.
            for(int i = 1; i < n; i++) {
                if ( mazec[index = m*i] == 'W') {
                    mazec[index] = '-';
                }
                
                if ( mazec[index = i+(n*n-1)] == 'W') {
                    Console.WriteLine(index);

                    mazec[index] = '-';
                }
            }

            // Top-Right Walls (walls with y=0 or x=N-1)
            // Note: N vertical edges, N horizontal edges, -3 (overlap, start, beginning).
            for(int i = 1; i < n; i++) {
                if ( mazec[i] == 'W') {
                    if(WallTracer(i) == true) return false;

                    mazec[i] = '+';
                }
                
                if ( mazec[index = m*i-2] == 'W') {
                    if(WallTracer(index) == true) return false;
                    mazec[index] = '+';
                }
            }

            // Recursively Trace along Wall until Opposite-Edge Wall
                // Replace Traced Walls with new Value: T
                // Start with + side because why not
                // If - side discovered, congrats, impassable wall, break.
                // If T discovered, that means previously traced, discontinue.
                // If . discovered, similarly pass.
                // If + side discovered, treat as W (mark as T).
                    Console.WriteLine(mazec);

            return true;

            bool WallTracer(int pos) {
                // Is there a contiguous, unpassable wall?
                //Console.WriteLine("pos: "+pos);
                //Console.WriteLine("mazec[pos]: "+mazec[pos]);

                switch(mazec[pos]) {
                    case 'T': // Already Traced
                    case '+': // Will or has been checked already, thus irrelevant
                    case '.': // Empty Space, ignore
                        return false;
                    case '-':
                        return true;
                    case 'W': // A Wall, continue recursion
                        mazec[pos] = 'T';
                                        //Console.WriteLine("p: "+pos);

                        for(int i = -1; i < 2; i++) {
                            if((pos+i)%n != 0 && (pos+i)>=0) {
                                for(int j = -m; j < 2*m; j += m) {
                                    if( (pos+j)>0) {
                                        //Console.WriteLine("p: "+pos);
                                        //Console.WriteLine("i: "+i);
                                        //Console.WriteLine("j: "+j);
                                        if(WallTracer(pos+i+j) == true) {
                                            return true;
                                        }
                                    }
                                }
                            } 
                        }
                        break;
                }
                return false;
            }

        }
    }
}


// Learning

// Counting String Length

// Math
// You could probably use an algorithm on the basis of assuming NxN (+N-1 due to \n).

// One-Liner with LINQ
// https://stackoverflow.com/questions/5340564/counting-how-many-times-a-certain-char-appears-in-a-string-before-any-other-char
// var count = mystring.Count(x => x == '$')

// Efficiency
// https://stackoverflow.com/questions/541954/how-would-you-count-occurrences-of-a-string-actually-a-char-within-a-string/541976#541976
// string source = "/once/upon/a/time/";
// int count = 0;
// foreach (char c in source) 
//   if (c == '/') count++;