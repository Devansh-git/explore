using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        //Devansh Shah  
        //Kautuk Udavant  

        //Everything in the begining same as assignment 1,2,3
        
        


        static void Main(string[] args)
        {


            string name;

            Console.WriteLine("HI EXPLORER");
            Console.WriteLine("WELCOME TO THE JUNGLE");
            Console.WriteLine("press ENTER to start");
            Console.ReadLine();
            Console.WriteLine("Enter your Name -");
            name = Console.ReadLine();



            int n;

            Console.WriteLine("Enter the number of characters you wanna create for adventuring party");
            n = Convert.ToInt32(Console.ReadLine());


            float[] c_str = new float[n];
            float[] c_dex = new float[n];
            float[] c_sta = new float[n];
            float[] c_wis = new float[n];
            float[] c_int = new float[n];
            float[] c_cha = new float[n];


            float[] s_str = new float[n];
            float[] s_dex = new float[n];
            float[] s_sta = new float[n];
            float[] s_wis = new float[n];
            float[] s_int = new float[n];
            float[] s_cha = new float[n];

            float[] MA = new float[n];
            float[] RA = new float[n];
            float[] lev = new float[n];

            float[] MAA = new float[n];
            float[] max = new float[n];

            int[] h = new int[n];//health for assignment-4

            string[] Des = new string[n];

            int[] type = new int[n];

            for (int i = 0; i < n; i++)



            {
                Console.WriteLine("Enter Attribute for character {0}", i + 1);
                Console.WriteLine("Note that attributes should be from 30");

                Console.WriteLine(" ");
                Console.WriteLine("Strength:-");
                c_str[i] = Convert.ToInt32(Console.ReadLine());

                if (c_str[i] > 30)
                {
                    Console.WriteLine("Too High, submit a lower score");

                    Console.WriteLine("Strength:-");
                    c_str[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_str[i] < 0)
                {
                    Console.WriteLine("Too Low, submit a higher score");

                    Console.WriteLine("Strength:-");
                    c_str[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_str[i] > 100 || c_str[i] < -40)
                {
                    Console.WriteLine("You entered a invalid score, Terminate the program");
                    Console.ReadLine();
                }




                Console.WriteLine("Dexterity:-");
                c_dex[i] = Convert.ToInt32(Console.ReadLine());
                if (c_dex[i] > 30)
                {
                    Console.WriteLine("Too High, submit a lower score");

                    Console.WriteLine("Strength:-");
                    c_dex[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_dex[i] < 0)
                {
                    Console.WriteLine("Too Low, submit a higher score");

                    Console.WriteLine("Strength:-");
                    c_dex[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_dex[i] > 100 || c_dex[i] < -40)
                {
                    Console.WriteLine("You entered a invalid score, Terminate the program");
                    Console.ReadLine();
                }

                Console.WriteLine("Stamina:-");
                c_sta[i] = Convert.ToInt32(Console.ReadLine());
                if (c_sta[i] > 30)
                {
                    Console.WriteLine("Too High, submit a lower score");

                    Console.WriteLine("Strength:-");
                    c_sta[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_sta[i] < 0)
                {
                    Console.WriteLine("Too Low, submit a higher score");

                    Console.WriteLine("Strength:-");
                    c_sta[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_sta[i] > 100 || c_sta[i] < -40)
                {
                    Console.WriteLine("You entered a invalid score, Terminate the program");
                    Console.ReadLine();
                }


                Console.WriteLine("Wisdom:-");
                c_wis[i] = Convert.ToInt32(Console.ReadLine());
                if (c_wis[i] > 30)
                {
                    Console.WriteLine("Too High, submit a lower score");

                    Console.WriteLine("Strength:-");
                    c_wis[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_wis[i] < 0)
                {
                    Console.WriteLine("Too Low, submit a higher score");

                    Console.WriteLine("Strength:-");
                    c_wis[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_wis[i] > 100 || c_wis[i] < -40)
                {
                    Console.WriteLine("You entered a invalid score, Terminate the program");
                    Console.ReadLine();
                }

                Console.WriteLine("Intelligence:-");
                c_int[i] = Convert.ToInt32(Console.ReadLine());
                if (c_int[i] > 30)
                {
                    Console.WriteLine("Too High, submit a lower score");

                    Console.WriteLine("Strength:-");
                    c_int[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_int[i] < 0)
                {
                    Console.WriteLine("Too Low, submit a higher score");

                    Console.WriteLine("Strength:-");
                    c_int[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_int[i] > 100 || c_int[i] < -40)
                {
                    Console.WriteLine("You entered a invalid score, Terminate the program");
                    Console.ReadLine();
                }

                Console.WriteLine("Charisma:-");
                c_cha[i] = Convert.ToInt32(Console.ReadLine());
                if (c_cha[i] > 30)
                {
                    Console.WriteLine("Too High, submit a lower score");

                    Console.WriteLine("Strength:-");
                    c_cha[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_cha[i] < 0)
                {
                    Console.WriteLine("Too Low, submit a higher score");

                    Console.WriteLine("Strength:-");
                    c_cha[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (c_cha[i] > 100 || c_cha[i] < -40)
                {
                    Console.WriteLine("You entered a invalid score, Terminate the program");
                    Console.ReadLine();
                }




                Console.WriteLine("Enter level of charcter {0}", i + 1);
                lev[i] = Convert.ToInt32(Console.ReadLine());








                Console.WriteLine("Choose Your Character :-");
                Console.WriteLine("1.Fighter");
                Console.WriteLine("2.Rogue");
                Console.WriteLine("3.Wizard");
                Console.WriteLine("4.Ranger");
                Console.WriteLine("5.Paladin");
                Console.WriteLine("Enter the number for selecting class for your character {0}", i + 1);
                type[i] = Convert.ToInt32(Console.ReadLine());






                if (type[i] == 1)
                {
                    Console.WriteLine("You chose Fighter as your character");

                    c_str[i] = c_str[i] + 2;
                    c_sta[i] = c_sta[i] + 2;

                    h[i] = 50;
                }

                else if (type[i] == 2)
                {
                    Console.WriteLine("You chose Rogue as your character");

                    c_dex[i] = c_dex[i] + 2;
                    c_cha[i] = c_cha[i] + 2;

                    h[i] = 25;

                }

                else if (type[i] == 3)
                {
                    Console.WriteLine("You chose Wizard as your character");

                    c_int[i] = c_int[i] + 2;
                    c_wis[i] = c_wis[i] + 2;

                    h[i] = 15;
                }

                else if (type[i] == 4)
                {
                    Console.WriteLine("You chose Ranger as your character");

                    c_str[i] = c_str[i] + 2;
                    c_dex[i] = c_dex[i] + 2;

                    h[i] = 40;
                }


                else if (type[i] == 5)
                {
                    Console.WriteLine("You chose Paladin as your character");

                    c_str[i] = c_str[i] + 2;
                    c_cha[i] = c_cha[i] + 2;

                    h[i] = 45;
                }




                Console.WriteLine("");
                int[] age = new int[n];

                Console.WriteLine("Choose The Characters age ");
                age[i] = Convert.ToInt32(Console.ReadLine());


               




                if (age[i] < 16)
                {
                    Console.WriteLine("Too Low, submit a higher age");
                    age[i] = Convert.ToInt32(Console.ReadLine());

                }

                else if (age[i] > 85)
                {
                    Console.WriteLine("Too High, submit a lower age");
                    age[i] = Convert.ToInt32(Console.ReadLine());


                }





                else if (age[i] > 15 && age[i] <= 22)
                {
                    Console.WriteLine("Your characters age is {0} ", age[i]);

                    c_str[i] = c_str[i] + 2;
                    c_sta[i] = c_sta[i] + 2;
                    c_dex[i] = c_dex[i] + 2;


                }

                else if (age[i] > 22 && age[i] < 41)
                {
                    Console.WriteLine("Your characters age is {0} ", age[i]);

                    c_str[i] = c_str[i] - 2;
                    c_sta[i] = c_sta[i] - 2;
                    c_dex[i] = c_dex[i] - 2;
                    c_wis[i] = c_wis[i] + 2;
                    c_cha[i] = c_cha[i] + 2;

                }

                else if (age[i] > 40 || age[i] == 40)
                {
                    Console.WriteLine("Your characters age is {0} ", age[i]);

                    c_str[i] = c_str[i] - 4;
                    c_sta[i] = c_sta[i] - 4;
                    c_dex[i] = c_dex[i] - 4;
                    c_wis[i] = c_wis[i] + 4;
                    c_cha[i] = s_cha[i] + 2;

                }



                s_str[i] = c_str[i] / 10;
                s_dex[i] = c_dex[i] / 10;
                s_sta[i] = c_sta[i] / 10;
                s_wis[i] = c_wis[i] / 10;
                s_int[i] = c_int[i] / 10;
                s_cha[i] = c_cha[i] / 10;

                Console.ReadLine();

                MA[i] = (s_str[i] + s_int[i]) * lev[i];
                RA[i] = (s_dex[i] + s_wis[i]) * lev[i];



                if (MA[i] > RA[i])
                { max[i] = MA[i]; }
                else
                { max[i] = RA[i]; }

                MAA[i] = max[i] * 3;

                Console.WriteLine("Enter Description for chracter {0} ", i + 1);

                Des[i] = Console.ReadLine();
                Console.WriteLine("");


            }




            for (int i = 0; i < n; i++)


            {


                Console.WriteLine("Now displaying the stats for character {0}", i + 1);


                Console.WriteLine(" strength score of character {1} is {0}", s_str[i], i + 1);
                Console.WriteLine(" dexterity score of character {1} is {0}", s_dex[i], i + 1);
                Console.WriteLine(" stamina score of character {1} is {0}", s_sta[i], i + 1);
                Console.WriteLine(" wisdom score of character {1} is {0}", s_wis[i], i + 1);
                Console.WriteLine(" intelligence score of character {1} is {0}", s_int[i], i + 1);
                Console.WriteLine(" charisma score of character {1} is {0}", s_cha[i], i + 1);

                Console.ReadLine();

                Console.WriteLine("Hit points for Melle Attack of character {1} will be {0}", MA[i], i + 1);
                Console.WriteLine("Hit points for Rangged Attack of character {1} will be {0}", RA[i], i + 1);
                if (type[i] == 3)
                    Console.WriteLine("Hit Points of Wizard for Magic Attack is {0}", MAA[i]);
                Console.ReadLine();



                Console.WriteLine("Character Description for character {1} :- {0}", Des[i], i + 1);
                Console.ReadLine();
            }


            //for assignment 4
            //movement and attack selection placed in a switch case 
            //ability to move to a position,attack and kill the enemy( if your hero dies - displays a message
            //3. to skip the chance
            //4 -- will exit the do while loop
            

            Console.WriteLine("The objective of the game is to move and attack the enemies");
            Console.WriteLine("Enter the coordinate for x-axis and y-axis to move around ");
            Console.WriteLine("Choose attack in selection menu to attack the enemy");
            Console.WriteLine("Press enter to continue");




            


            Console.ReadLine();
            int chd=0;//count how many hero died
            int ced = 0;//cout how many enemy died
            int ch1;
            int x = 0, y = 0;
            float[,] table = new float[20, 20];

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Selection Menu");
                Console.WriteLine("1.Move");
                Console.WriteLine("2.Attack");
                Console.WriteLine("3.Skip Chance");
                Console.WriteLine("4.exit");
                Console.WriteLine("Choose the number of your action");
                ch1 = Convert.ToInt32(Console.ReadLine());

                switch(ch1)
                {
                    case 1:
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < 20; j++)
                            {
                                table[i, j] = 0;

                            }

                        }

                        Console.WriteLine("Enter X and Y values ");
                        x = Convert.ToInt32(Console.ReadLine());
                        y = Convert.ToInt32(Console.ReadLine());



                        table[x, y] =1;

                        table[19, 19] = 2;


                        for (int i = 0; i < 20; i++)
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 20; j++)
                            {
                                Console.Write("  {0}  ", table[i, j]);

                            }

                        }

                        Console.ReadLine();
                        break;
                       

                    case 2:
                        if (table[18, 18] == 1 || table[19, 18] == 1 || table[18,19] == 1)
                        { 

                        Console.WriteLine("You chose to attack the enemy ");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.WriteLine("Enemy is dead");
                        for(int i=0;i<n;i++)
                        {
                            h[i] = h[i] - 20;//enemy attacks hero

                            if(h[i]<0)
                            {
                                Console.WriteLine("You hero no {0} died in the battle",i+1);
                                chd++;//counting for hero to die
                            }
                           
                        }
                        ced++;//counting dead enemies
                        }

                        else
                        {
                            Console.WriteLine("You are not near the enemy !! you cant attack them ");

                        }
                        break;

                    case 3:

                        continue;

                    case 4: break;

                }

                   
                 if(chd>n)
                { break; }// if all hero dies the the program will stop
                    
                    
            } while(ch1==1||ch1==2||ch1==3);


            Console.WriteLine("You killed {0} enemies", ced);

        }
    }
}
