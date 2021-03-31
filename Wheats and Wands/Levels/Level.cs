﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Entities;

namespace Wheats_and_Wands.Levels
{
    public abstract class Level
    {
        
        
        Texture2D _backGround { get; set; }
        public Rectangle _frame = new Rectangle(0, 0, WheatandWandsGame.WINDOW_WIDTH, WheatandWandsGame.WINDOW_HEIGHT);
        SpriteBatch _spriteBatch;

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _spriteBatch = spriteBatch;
            _spriteBatch.Draw(_backGround, _frame, Color.White);
        }

    }
}
