﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.System
{
    public class Button : Component
    {
        private MouseState _currentMouse;
        private bool isHovering;
        private MouseState _previousMouse; //Checks left clicking?
        //private Texture2D _texture;
        private Sprite _sprite;
        public event EventHandler Click;
        public float X;
        public float Y;

        public bool Clicked { get; private set; }
        public Color PenColor { get; set; } //Color of the font
        //public Vector2 Position { get; set; } //Position of the button
        public string Text { get; set; }
        public Rectangle Rectangle //Size of the button
        {
           get
            {
                return new Rectangle(_sprite.X , _sprite.Y - 540, _sprite.Width, _sprite.Height);
            }
        }

        public Button(Sprite sprite, float x, float y)
        {
            _sprite = sprite;
            X = x;
            Y = y;
            //Position = new Vector2((float)_sprite.X, (float)_sprite.Y);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Color color = Color.White;
            if (this.isHovering) //If the mouse is hovering over the button
                _sprite.TintColor = Color.Gray;
            else
            {
                _sprite.TintColor = Color.White;
            }

            _sprite.Draw(spriteBatch, new Vector2(_sprite.X, _sprite.Y - 540));
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1); //Tracks current mouse

            isHovering = false;

            if (mouseRectangle.Intersects(Rectangle)) //If mouse hovers over button
            {
                isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
