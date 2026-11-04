using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ICS4U_Monogame_4
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;
        Rectangle frame;

        Texture2D frameTexture;

        Rectangle shipRect;
        Texture2D shipTexture;

        Texture2D starTexture;

        List<Star> stars;

        Random generator;

        KeyboardState keyboardState;

        int shipY = 250;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            frame = new Rectangle(0, 0, window.Width, window.Height); 


            generator = new Random();

            stars = new List<Star>();


            base.Initialize();
            for (int i = 0; i < 150; i++)
            {
                int size = generator.Next(1, 4);
                stars.Add(new Star(starTexture, window));

            }

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            shipTexture = Content.Load<Texture2D>("images/enterprise");
            starTexture = Content.Load<Texture2D>("images/circle");
            frameTexture = Content.Load<Texture2D>("images/frame");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && shipRect.Top != frame.Top)
            {
                shipY -= 5;
            }
            else if (keyboardState.IsKeyDown(Keys.Down) && shipRect.Bottom != frame.Bottom)
            {
                shipY += 5;

            }

            shipRect = new Rectangle(200, shipY, 150, 40);


            foreach (Star star in stars) 
            {
                star.Update(window, keyboardState);
            }


            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            foreach (Star star in stars)
            {
                star.Draw(_spriteBatch, Color.White);
            }


            _spriteBatch.Draw(shipTexture, shipRect, Color.White);

            _spriteBatch.Draw(frameTexture, frame, Color.White);


            


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
