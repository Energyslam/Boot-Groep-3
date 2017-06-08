using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpeedTop4._5
{
    class GameOverState : GameObjectList
    {
        public GameOverState()
        {
            Add(new SpriteGameObject("spr_gameover"));
        }

        public override void HandleInput(InputHelper inputHelper) //switch state
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space)) Game1.GameStateManager.SwitchTo("menuState");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
