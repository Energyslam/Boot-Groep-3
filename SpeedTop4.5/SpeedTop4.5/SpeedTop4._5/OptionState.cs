using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTop4._5
{
    class OptionState : GameObjectList
    {
        BlankText volume = new BlankText();
        BlankText goBack = new BlankText();
        public OptionState()
        {

            volume.Text = "Press Enter to mute or play the music";
            volume.Position = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 2);
            goBack.Text = "Press Space to go back";
            goBack.Position = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 5 * 4);
            Add(new SpriteGameObject("spr_background"));
            Add(volume);

            Add(goBack);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter)) Console.WriteLine(InformationProject4._5.Information.volume + "");
            if (inputHelper.KeyPressed(Keys.Down) && InformationProject4._5.Information.volume == 1)
            {
                InformationProject4._5.Information.volume = 0;
            }
            if (inputHelper.KeyPressed(Keys.Up) && InformationProject4._5.Information.volume == 0)
            {
                InformationProject4._5.Information.volume = 1;
            }
            if (inputHelper.KeyPressed(Keys.Space)) Game1.GameStateManager.SwitchTo("menuState");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (InformationProject4._5.Information.volume == 1) volume.Text = "Press Down to mute the music\n music is ON";
            if (InformationProject4._5.Information.volume == 0) volume.Text = "Press Up to play the music\n music is OFF";
        }
    }
}
