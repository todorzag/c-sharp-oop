﻿using SnakeGame.Classes;
using SnakeGame.Interfaces;
using SnakeGame.Utils;

namespace SnakeGame.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Thread thread = new Thread(() =>
            {
                IGameConfig gameConfig = Factory.CreateGameConfig();

                (IPlayer player, bool hasWalls, int snakeLength) 
                = gameConfig.GetDataFromInput();

                var game
                = Factory.CreateGame(player, hasWalls, snakeLength);

                game.MainProcess();
            });

            thread.Start();
        }
    }
}