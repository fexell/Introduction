using System;
using System.Text.RegularExpressions;

namespace Calculator {
    class Program {
        static void Menu() {
            string input;

            do {

                Console.WriteLine();
                Console.WriteLine( "MENU" );
                Console.WriteLine( "1. Calculator" );
                Console.WriteLine( "0. Exit" );
                Console.Write( "Select an options: " );

                input = Console.ReadLine();

                Console.WriteLine();

                MenuOptions( input );

            } while ( input != "0" );
        }

        static void MenuOptions( string input ) {
            switch( input ) {
                case "1":
                    Calculator();
                    break;
                case "0":
                    Console.WriteLine( "Exiting..." );
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( "Invalid option. '{0}' given.", input );
                    Console.ResetColor();
                    break;
            }
        }

        static int GetIntInput( string input, string writeMessage = "Reenter value: " ) {
            while( !int.TryParse( input, out int value ) ) {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "Input needs to be a number. '{0}' given.", input );
                Console.ResetColor();

                Console.Write( writeMessage );
                input = Console.ReadLine();

            }

            return int.Parse( input );
        }

        static char ValidOperator( string input ) {
            while( !Regex.IsMatch( input, @"[\+\-\*\/]" ) || !Char.TryParse( input, out Char value ) ) {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "Input needs to be a valid operator (+, -, *, /). '{0}' given.", input );
                Console.ResetColor();
                Console.WriteLine();

                Console.Write( "Enter operation (+, -, *, /): " );
                input = Console.ReadLine();
            }

            return char.Parse( input );
        }

        static void Calculator() {
            int number1, number2;
            char operation;

            Console.Write( "Enter first number: " );
            number1 = GetIntInput( Console.ReadLine(), "Enter first number: " );

            Console.Write( "Enter second number: " );
            number2 = GetIntInput( Console.ReadLine(), "Enter second number: " );

            Console.Write( "Enter operation (+, -, *, /): " );
            operation = ValidOperator( Console.ReadLine() );

            double sum;

            switch( operation ) {
                case '+':
                    sum = number1 + number2;
                    break;

                case '-':
                    sum = number1 - number2;
                    break;

                case '*':
                    sum = number1 * number2;
                    break;

                case '/':
                    if( number2 == 0 ) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine( "Division by zero is not allowed." );
                        Console.ResetColor();
                        return;
                    }
                    sum = (double)(number1 / number2);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( "Invalid operation." );
                    Console.ResetColor();
                    return;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( $"{ number1 } { operation } { number2 } = { sum }" );
            Console.ResetColor();
            Console.WriteLine();
        }

        static void Main( string[] args ) {
            Menu();
        }
    }
}