﻿using SnakeGame.Constants;

namespace SnakeGame.Interfaces
{
    public interface ISnake
    {
        int MaxLength { get; }
        List<IPoint> Body { get; }
        IPoint Head { get; }
        Directions Direction { get; set; }

        void AddPart();
        void Move();
        void RemovePart();
        void Render();
        void UpdateBodyPosition();
    }
}