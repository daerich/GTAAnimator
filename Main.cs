using GTA;
using System;
using NativeUI;
using System.Windows.Forms;
using GTAAnimator.Animations;
using System.Collections.Generic;

namespace GTAAnimator
{
   public class GTAAnimator : Script
    {
        private Ped Player;
        private MenuPool mpool;
        private UIMenu aniM;
        public GTAAnimator()
        {
            Animation Animations = new Animation("scripts/Animations.ini");
            Animations.Read();
  
            mpool = new MenuPool();
            aniM = new UIMenu("GTA Animations", "by DaErich");
            mpool.Add(aniM);
            AddStop();
            foreach (KeyValuePair<string, string> element in Animations.Animations)
            {
                AddAnimation(element.Key, element.Value);
            }
           // AddAnimation("amb@medic@standing@tendtodead@idle_a", "idle_a");
           //AddAnimation("amb@world_human_hang_out_street@female_arms_crossed@idle_a", "idle_a");
            mpool.RefreshIndex();

            Tick += OnTick;
            KeyDown += OnKeyDown;
        }

     
        private void AddAnimation(string animdict, string anim)
        {
            UIMenuItem animbtn = new UIMenuItem(animdict);
            aniM.AddItem(animbtn);
            aniM.OnItemSelect += (sender, item, index) =>{
                if(item == animbtn)
                {
                    Player.Task.PlayAnimation(animdict, anim, 8f, -1, AnimationFlags.Loop);
                }
            };
        

        }

        private void AddStop()
        {
            UIMenuItem Stopbtn = new UIMenuItem("Stop Animation");
            aniM.AddItem(Stopbtn);
            aniM.OnItemSelect += (sender, item, index) =>
            {
                if (item == Stopbtn)
                {
                    Player.Task.ClearAll();
                }
            };
        }


        private void OnTick(object sender, EventArgs e)
        {
            mpool.ProcessMenus();

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Player = Game.Player.Character;  //update Character
            if (e.KeyCode == Keys.F5 && !mpool.IsAnyMenuOpen())
            {
                aniM.Visible = !aniM.Visible;
            }
        }


    }
}
