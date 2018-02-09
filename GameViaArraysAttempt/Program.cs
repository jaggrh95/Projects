using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Resources;




namespace GameViaArraysAttempt
{

   
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[Console.WindowWidth, Console.WindowWidth];
            int[] opschuif = new int[60];
            int start = Console.WindowWidth / 2;
            int locatie = start;
            int diffic;
            int teller = 0;
            int enable = 2;
            int score = 0;
            int speed = 50;
            string diff;
            Random rnd = new Random();
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Mm.wav";
            player.Play();
            

            do
            {
                Console.Write("kies een difficulty hoe hoger het getal, hoe makkelijker het spel (max 30, minimum 10)");
                diff = Console.ReadLine();
                diffic = Convert.ToInt32(diff);
            } while (diffic > 30 || diffic < 10);



            int positionchange = rnd.Next(1, 3);
            int startpositie = (Console.WindowWidth / 2) - (diffic / 2);
           
           



            while (true)
            {
                score++;
                Console.SetCursorPosition(2, 2);
                Console.Write(score);
                

                positionchange = rnd.Next(1, 4);
                if (positionchange == 1)
                {
                    startpositie = startpositie - 1;
                    if (startpositie < 3)
                    {
                        startpositie = 3;
                    }
                }
                else if (positionchange == 2)
                {
                    startpositie = startpositie + 1;
                    if (startpositie + diffic > Console.WindowWidth)
                    {
                        startpositie = Console.WindowWidth - diffic;
                    }
                }
                else
                {

                }
                //arne loves you xxx
                opschuif[teller] = startpositie;
                Console.SetCursorPosition(startpositie, 0);
                Console.Write("*");
                Console.SetCursorPosition(startpositie + diffic - 1, 0);
                Console.Write("*");

                if (enable == 0)
                {
                    for (int i = 27; i > teller; i--)
                    {
                        Console.SetCursorPosition(opschuif[i], 28 + teller - i);
                        Console.Write("*");
                        Console.SetCursorPosition(opschuif[i] + diffic, 28 + teller - i);
                        Console.Write("*");
                    }
                    for (int i = 0; i < teller; i++)
                    {
                        Console.SetCursorPosition(opschuif[i], 0 + teller - i);
                        Console.Write("*");
                        Console.SetCursorPosition(opschuif[i] + diffic, 0 + teller - i);
                        Console.Write("*");
                    }
                }
                else if (enable == 1)
                {
                    for (int i = 0; i < teller; i++)
                    {
                        Console.SetCursorPosition(opschuif[i], 0 + teller - i);
                        Console.Write("*");
                        Console.SetCursorPosition(opschuif[i] + diffic, 0 + teller - i);
                        Console.Write("*");
                    }
                    for (int i = 27; i > teller; i--)
                    {
                        Console.SetCursorPosition(opschuif[i], 28 + teller - i);
                        Console.Write("*");
                        Console.SetCursorPosition(opschuif[i] + diffic, 28 + teller - i);
                        Console.Write("*");
                    }

                }
                else
                {
                    for (int i = 0; i < teller; i++)
                    {
                        Console.SetCursorPosition(opschuif[i], 0 + teller - i);
                        Console.Write("*");
                        Console.SetCursorPosition(opschuif[i] + diffic, 0 + teller - i);
                        Console.Write("*");
                    }

                }
                teller = teller + 1;
                if (teller > 28 && enable == 0)
                {
                    teller = 0;
                    enable = 1;
                }
                if (teller > 28 && enable == 1)
                {
                    teller = 0;
                    enable = 0;
                }
                if (teller > 28 && enable == 2)
                {
                    teller = 0;
                    enable = 1;
                }

                Console.SetCursorPosition(locatie, 25);
                Console.Write('^');
               
                Console.SetCursorPosition(0, 0);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        locatie = locatie - 1;
                        if (locatie < 0)
                        {
                            locatie = 0;
                        }

                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        locatie = locatie + 1;
                        if (locatie > Console.WindowWidth)
                        {
                            locatie = Console.WindowWidth;
                        }

                    }
                }
               
                if (enable != 2 && (locatie <= opschuif[25]  || locatie >= opschuif[25]+diffic))
                {
                    
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("uw schip is neer gestort! uw score is " + score + " op difficulty " + diff);
                    Console.Read();
                   
                }
                if (score < 200 || score == 201 || score == 203 || score == 205 || score == 207)
                {
                    Console.ForegroundColor = (ConsoleColor)rnd.Next(14, 16);
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                if (score ==200 || score == 202 || score == 204 || score == 206 || score == 208 || score == 501 || score == 503 || score == 505 || score == 507)
                {
                    if (score == 200)
                    {
                        diffic = diffic - 2;
                        speed = 35;
                        
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    

                    
                }
                if (score == 500 || score == 502 || score == 504 || score == 506 || score == 508)
                {
                    if (score == 500)
                    {
                        speed = 20;
                        diffic = diffic - 2;

                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                if (score == 800)
                {
                    diffic = diffic - 2;
                    speed = 15;
                }
                if (score > 800)
                {
                   
                    Console.ForegroundColor = (ConsoleColor)rnd.Next(0, 16);
                    Console.BackgroundColor = (ConsoleColor)rnd.Next(0, 16);
                    
                }
                if (score == 1000)
                {
                    diffic = diffic - 2;
                    speed = 10;
                }
                if (score == 1200)
                {
                    diffic = diffic - 2;
                    speed = 5;
                }

                if (score >= 1100)
                {
                    
                    Console.ForegroundColor = (ConsoleColor)rnd.Next(14, 16);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                if (score == 1400 || score == 1600 || score == 1800 || score == 2000 || score == 2200)
                {

                    diffic = diffic - 2;
                    
                }

                System.Threading.Thread.Sleep(speed);
                Console.Clear();
                
            }
        }
    }
}
