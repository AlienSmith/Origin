﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System.Collections.Generic;
using StickyHandGame_C9_RP7.Source.Components.DynamicLighting;
using StickyHandGame_C9_RP7.Source.MathmaticHelper;
using StickyHandGame_C9_RP7.Source.Managers.Classes;

namespace StickyHandGame_C9_RP7.Source.TestResource
{
    //This is the start of the dynamic lighting system Include 
    //DrawPolygoon
    //Hull/
    //IntersectDetection/
    //Light/
    //ShadowManager
    //Trace/
    //TraceHelperClass/
    //using MonoGame.Extend for drawing simple lines and rectangles
    //TODO include shader for the lighting component
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch lightSpriteBatch;
        //private DrawPolygon drawShadow;
        Vector2 startpoint = PolygongEntity.StartPoint;
        ShadowManager shadowManager;
        public static Vector2 WINDOWSIZE = new Vector2(1000, 1000);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = (int)Game1.WINDOWSIZE.X;
            graphics.PreferredBackBufferHeight = (int)Game1.WINDOWSIZE.Y;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //this.drawShadow = new DrawPolygon();
            //this.drawShadow.AddPolygon(new Vector2(100, 100), new Vector2(200, 100), new Vector2(200, 200), new Vector2(100, 200));
            //this.drawShadow.AddPolygon(new Vector2(300, 300), new Vector2(400, 300), new Vector2(400,400), new Vector2(300, 400));
            //this.drawShadow.AddPolygon(new Vector2(100, 400), new Vector2(200, 400), new Vector2(200, 500), new Vector2(100, 500));
            //this.drawShadow.Traces = TraceHelperClass.Range(MathHelper.Pi/360f, MathHelper.Pi*2, (MathHelper.Pi / 360), new Vector2(20, 0));
            //this.drawShadow.Traces.AddRange(TraceHelperClass.Range(MathHelper.Pi /120f, MathHelper.Pi*2, (MathHelper.Pi / 60), new Vector2(0, 20)));
            //this.drawShadow.Traces.AddRange(TraceHelperClass.Range(MathHelper.Pi /80f, MathHelper.Pi*2, (MathHelper.Pi/60), new Vector2(-20, 0)));
            //this.drawShadow.Traces.AddRange(TraceHelperClass.Range(MathHelper.Pi / 60f, MathHelper.Pi * 2, (MathHelper.Pi / 60), new Vector2(0, -20)));
            //Add Polygons here

            shadowManager = new ShadowManager(this);
            shadowManager.AddPolygon(new Vector2(100, 100), new Vector2(600, 100), new Vector2(600, 150), new Vector2(100, 150));
            shadowManager.AddPolygon(new Vector2(300, 300), new Vector2(400, 300), new Vector2(400, 400), new Vector2(300, 400));
            shadowManager.AddPolygon(new Vector2(100, 400), new Vector2(200, 400), new Vector2(200, 500), new Vector2(100, 500));
            shadowManager.addLight(MathHelper.Pi / 360f, new Vector2(-10, -10));
            shadowManager.addLight(MathHelper.Pi / 720f, new Vector2(10, 10));
            shadowManager.InitiateLight();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            lightSpriteBatch = new SpriteBatch(GraphicsDevice);
            this.shadowManager.loadContent(spriteBatch, lightSpriteBatch);
            // TODO: use this.Content to load your game content here
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
            this.shadowManager.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            shadowManager.Draw();

            spriteBatch.End();
            lightSpriteBatch.Begin();
            this.shadowManager.DrawLight();
            lightSpriteBatch.End();
            base.Draw(gameTime);
        }
        /*public void PointLightUpdate() {
            Vector2 MousePoint = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            Vector2 Extend = MousePoint - startpoint;
            drawShadow.Traces[0].Extend = Extend;
            drawShadow.Update();
            return;
        }*/
    }
}
