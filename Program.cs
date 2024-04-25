using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowsAndBulls
{
    internal class Program
    {
        static int[] MakeNumber() //subroutine to create random number 

        {

            Random rnd = new Random();

            int[] mynum = { 0, 0, 0, 0 };

            int uniq = 0;





            do



            {



                mynum[0] = rnd.Next(1, 10);





                for (int i = 1; i < 4; i++)



                {



                    mynum[i] = rnd.Next(10);



                }





                IEnumerable<int> uniques = mynum.Distinct();// creates an array with all unique values   of mynum 



                uniq = 0;





                foreach (int i in uniques)



                {



                    uniq++;



                }



            }



            while (mynum.Length > uniq);





            return mynum;



        }



        static int[] UserGuess() // valid user guess 



        {



            int[] guess = { 0, 0, 0, 0 };



            int x = 0;



            int uniq = 0;



            string user = ""; // stores userinput 





            while (guess[0] <= 0 || guess.Length > uniq || user.Length != 4)



            {



                if (x != 0)



                {



                    Console.WriteLine("\n\nSorry, that is invalid!\nYour 4 digit number must be greater than and contain all different digits!\n\n");



                }





                Console.Write("Guess my 4 digit number: ");



                user = Console.ReadLine();





                for (int i = 0; i < 4; i++)



                {



                    guess[i] = Convert.ToInt32(user[i]) - 48;



                }





                IEnumerable<int> uniques = guess.Distinct(); // to check for repeats 



                uniq = 0;





                foreach (char i in uniques)



                {



                    uniq++;



                }





                x = 1;



            }





            return guess;



        }



        static int[] CowsAndBulls(int[] answer, int[] guess)



        {



            int bulls = 0;



            int cows = 0;



            int[] cowlist = { 10, 10, 10, 10 };





            for (int i = 0; i < 4; i++)



            {





                if (answer[i] == guess[i])



                {



                    bulls += 1;



                }



                else



                {



                    cowlist[i] = guess[i];



                }



            }





            for (int i = 0; i < 4; i++)// checks every value against every other value 



            {





                for (int j = 0; j < 4; j++)



                {





                    if (cowlist[i] == answer[j])



                    {



                        cows += 1;



                    }



                }



            }





            int[] cowsandbulls = { cows, bulls };





            return cowsandbulls;





        }



        static void Main(string[] args)



        {



            bool play_again = true;





            Console.WriteLine("Welcome!!\nIn this game you will have to guess my 4 digit number: ");



            Console.WriteLine("\tA cow means one of your digits is in my number but not in the correct spot");



            Console.WriteLine("\tA bull means one of your digits is in the right place\n\n");





            int high_score = 0;





            while (play_again)



            {





                int[] comp = MakeNumber();







                int attempts = 0;



                int cows = 0;



                int bulls = 0;





                Console.WriteLine($"\nWell done! My number was {comp[0]}{comp[1]}{comp[2]}{comp[3]}!");





                while (bulls != 4)



                {





                    Console.WriteLine("\n");



                    int[] user = UserGuess();



                    int[] cAndb = CowsAndBulls(comp, user);



                    cows = cAndb[0]; bulls = cAndb[1];





                    Console.WriteLine($"\nCows -> {cows}\nBulls -> {bulls}");



                    attempts++;



                }





                Console.WriteLine($"\nWell done! My number was {comp[0]}{comp[1]}{comp[2]}{comp[3]}!");





                if (attempts < high_score || high_score == 0)



                {



                    Console.WriteLine("\nNEW HIGH SCORE!\n");



                    high_score = attempts;



                }





                Console.WriteLine($"\nHigh Score -> {high_score} attempts");



                Console.WriteLine($"Current Score -> {attempts} attempts");



                string play = "";





                do



                {



                    Console.WriteLine("\n\nWould you like to play again - 'yes' or 'no': ");



                    play = Console.ReadLine();



                }



                while (play != "yes" && play != "no");





                if (play == "no")



                {



                    play_again = false;



                }



                else



                {



                    Console.WriteLine("\n\nOkay.\n\n   |\n   |\n  \\_/\n\n");



                }



            }




        }
    }
}
