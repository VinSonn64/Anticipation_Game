using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneButtonGame
{
    class myStuff: Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteFont myFont;
        Vector2 SpriteLoc;
        SpriteBatch mySpriteBatch;
        int click;
        bool pressed;
        public myStuff (Game game): base(game)
        {

        }

        protected override void LoadContent()
        {
            myFont = this.Game.Content.Load<SpriteFont>("MyFont");
            SpriteLoc = new Vector2(450, 250);
            mySpriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            pressed = false;
            click = 0;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            if (!pressed)
            {
                HandleInput();
            }
            base.Update(gameTime);
        }

        private void HandleInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                click++;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space) && click > 0)
            {
                pressed = true;
            }

        }

        string Results()
        {
            string Ending = "You were off by " + (click - 300).ToString();
            return Ending;
        }


        public override void Draw(GameTime gameTime)
        {
            mySpriteBatch.Begin();
            mySpriteBatch.DrawString(myFont, click.ToString(), SpriteLoc, Color.Yellow);
            mySpriteBatch.DrawString(myFont, "Hold SPACEBAR to raise the number. Try to let go on 300.", new Vector2(200, 200), Color.Yellow);
            if (pressed)
            {
                mySpriteBatch.DrawString(myFont, Results(), new Vector2(200, 250), Color.Yellow);
            }
            mySpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
