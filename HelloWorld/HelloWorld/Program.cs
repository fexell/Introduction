using System;

namespace HelloWorld {
    public class  Program {
        static void Main( string[] args ) {
            Console.WriteLine( "Hello, World!" );
            Console.WriteLine( "My name is Felix Cervin." );
            Console.WriteLine( "Today it's {0}", DateTime.Now.ToShortTimeString() );
            Console.WriteLine();

            string favoriteColor = "blue";
            Console.WriteLine( "My favorite color is {0}.", favoriteColor );
            Console.WriteLine();

            Console.Write( "What's your name?: " );
            string name = Console.ReadLine() ?? "Anonymous";
            Console.WriteLine( "Hello, {0}!", name );
            Console.WriteLine();
        }
    }
}