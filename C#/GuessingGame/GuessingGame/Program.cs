using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuessingGame
{
    internal class Program
    {
        public static int GenerateRandNumber()
        {
            Random rd = new Random();
            int rand_num = rd.Next(1, 100);
            return rand_num;
        }
        static void Main(string[] args)
        {
            int rand_num;
            int guess = -1;
            while (true) {

                Y1:
                rand_num = GenerateRandNumber();
                Console.WriteLine("Guess the number: ");
                X1:
                guess = Convert.ToInt32(Console.ReadLine());
                if(guess == rand_num)
                {
                    Console.WriteLine("Congrats! You've guessed the number correct. Do you want to play again? Y/N");
                    char answer= Convert.ToChar(Console.ReadLine());
                    if (answer == 'Y')
                        goto Y1;
                    else
                        break;
                }
                else if (guess > rand_num)
                {
                    Console.WriteLine("Your guess is bigger than the actual number. Try again");
                    goto X1;
                }
                else if (guess < rand_num)
                {
                    Console.WriteLine("Your guess is smaller than the actual number. Try again");
                    goto X1; 
                }
            }
            Console.ReadLine();
        }
    }
}
