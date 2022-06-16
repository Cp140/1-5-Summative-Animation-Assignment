using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1_5_Summative_Animation_Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //
        //
        // change names to class names
        //
        //

        List<Intro_Screen> tribbles = new List<Tribble>();

        Texture2D tribbleBrownTexture;

        Texture2D tribbleCreamTexture;

        Texture2D tribbleGreyTexture;

        Texture2D tribbleOrangeTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 500;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            //tribbleGreySpeed = new Vector2(2, 0);

            base.Initialize();
            tribbles.Add(new Tribble(tribbleGreyTexture, new Rectangle(300, 10, 100, 100), new Vector2(5, 5)));
            tribbles.Add(new Tribble(tribbleBrownTexture, new Rectangle(300, 10, 100, 100), new Vector2(8, 1)));
            tribbles.Add(new Tribble(tribbleCreamTexture, new Rectangle(300, 10, 100, 100), new Vector2(-5, -5)));
            tribbles.Add(new Tribble(tribbleOrangeTexture, new Rectangle(300, 10, 100, 100), new Vector2(-80, -80)));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            foreach (Tribble tribble in tribbles)
            {
                tribble.Move();

                if (tribble.Bounds.Right > _graphics.PreferredBackBufferWidth || tribble.Bounds.Left < 0)
                    tribble.BounceLeftRight();
                if (tribble.Bounds.Bottom > _graphics.PreferredBackBufferHeight || tribble.Bounds.Top < 0)
                    tribble.BounceTopBottom();


            }







            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Tribble tribble in tribbles)
                tribble.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
