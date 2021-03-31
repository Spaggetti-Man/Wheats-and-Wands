﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.Levels;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands
{
    public class WheatandWandsGame : Game
    {

        public const int WINDOW_WIDTH = 960;
        public const int WINDOW_HEIGHT = 540;

        GameState _gameState;
        Level _level;
        TitleScreen _titleScreen;
        TutorialFarm _tutorial;
        CreditScreen _creditScreen;


        Texture2D _titleScreenSprite;
        Texture2D _tutorialFarmBackground;
        Texture2D _farmerSpriteSheet;
        Vector2 playerPosition;

        Texture2D _creditScreenSprite; //Added
        SpriteFont _creditFont; //Added
        //SpriteFont _artFont; //Added, Not implemented
        //SpriteFont _musicFont; //Added, Not implemented
        //SpriteFont _programFont; //Added, Not implemented
        //SpriteFont _scottFont; //Added, Not implemented
        //SpriteFont _lukeFont; //Added, Not implemented


        MusicManager _musicManager;
        Song _titleTheme;
        Song _tutorialTheme;


        InputController _inputController;
        Display_Options _displayOptions;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Farmer _farmer;

        public WheatandWandsGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.ApplyChanges();

            _gameState = new GameState();

            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, (_graphics.PreferredBackBufferHeight / 2) + 15 ); //defaults player to center of the screen
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            _titleScreenSprite = Content.Load<Texture2D>("Backgrounds/Title screen");
            _titleTheme = Content.Load<Song>("music_zapsplat_game_music_zen_calm_soft_arpeggios_013");

            _tutorialFarmBackground = Content.Load<Texture2D>("Backgrounds/FarmerBackground2D");
            _tutorialTheme = Content.Load<Song>("music_orlamusic_Happy+006");

            _creditScreenSprite = Content.Load<Texture2D>("Backgrounds/Credits Screen"); //Added
            _creditFont = Content.Load<SpriteFont>("Spritefonts/Credits"); //Added

            _farmerSpriteSheet = Content.Load<Texture2D>("Farmer walk cycle");

            _farmer = new Farmer(_farmerSpriteSheet, playerPosition);
            _displayOptions = new Display_Options(_graphics);
            _inputController = new InputController(_farmer, _displayOptions);

            _musicManager = new MusicManager(_gameState, _titleTheme, _tutorialTheme);


            _titleScreen = new TitleScreen(_titleScreenSprite, _gameState);
            _creditScreen = new CreditScreen(_creditScreenSprite,_creditFont );

            _tutorial = new TutorialFarm(_tutorialFarmBackground, _farmer);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { 
            Exit();
            }



            if (_gameState.state == States.TitleScreen)
            {
                _level = _titleScreen;
            }
            if (_gameState.state == States.Tutorial)
            {
                _level = _tutorial;
            }
            if (_gameState.state == States.CreditScreen)
            {
                _level = _creditScreen;
            }

            _level.Update(gameTime);
            
            base.Update(gameTime);
            _inputController.ProcessControls(gameTime);
            _musicManager.Play();
        }

        protected override void Draw(GameTime gameTime)
        {


            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.White);
            
            _level.Draw(_spriteBatch,gameTime);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
