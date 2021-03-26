﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wheats_and_Wands.Graphics
{
    public class Sprite
    {
        public Texture2D Texture { get; private set; } 
        public int X { get; set; }
        public int Y { get; set; }
        public Vector2 position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color TintColor { get; set; } = Color.White;
        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;

        public Sprite(Texture2D texture, int x, int y, int width, int height)
        {
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.position = new Vector2(x, y);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position )
        {
            spriteBatch.Draw(Texture, position, new Rectangle(X, Y, Width, Height), TintColor); //, SpriteEffects
        }


    }
}