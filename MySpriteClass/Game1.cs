using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MySpriteClass
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D player;
        Texture2D vide;
        public Vector2 position;
        Sprite sprite;
        List<Sprite> sprites;
        Map map = new Map();
        public MouseState lastMouseState { get; private set; }
        public MouseState currentMouseState { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprites = new List<Sprite>();
            
            player = Content.Load<Texture2D>("assets/images/player");
            vide = Content.Load<Texture2D>("assets/images/vide");
            //position.X = (GraphicsDevice.Viewport.Width / 2) - player.Width / 2;

            //string strMap = map.createMap();
            int [,] _map = map.getMap;
            for (int ligne = 0; ligne < _map.GetLength(0); ligne++)
            {
                for(int colone = 0; colone < _map.GetLength(1); colone++)
                {
                    switch(_map[ligne, colone])
                    {
                        case 0:
                            position.X += 32;
                            break;
                        case 1:
                            sprite = new Sprite(player, position);
                            position.X += 32;
                            sprites.Add(sprite);
                            break;
                    }
                }
                position.Y += 32;
                position.X = 0;
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Test etat du bouton gauche de la souris
            currentMouseState = Mouse.GetState();
            bool bClick = false;
            if (currentMouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
            {
                bClick = true;
            }
            if (bClick)
                {
                    Console.WriteLine("Ouille !!");
                }
            
            lastMouseState = currentMouseState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            
                sprite.Draw(spriteBatch, sprites);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
