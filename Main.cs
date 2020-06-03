using GTA;
using System;
using NativeUI;
using System.Windows.Forms;

namespace GTAAnimator
{
   public class GTAAnimator : Script
    {
        private Ped Player = Game.Player.Character;
        private MenuPool mpool;
        private UIMenu aniM;
        public GTAAnimator()
        {
            mpool = new MenuPool();
            aniM = new UIMenu("GTA Animations", "by DaErich");
            mpool.Add(aniM);
            AddAnimation("amb@world_human_hang_out_street@female_arms_crossed@idle_a", "idle_a");
            AddStop();
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
                    Player.Task.PlayAnimation(animdict, anim, 8f, -1, AnimationFlags.CancelableWithMovement);
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
            if (e.KeyCode == Keys.F5 && !mpool.IsAnyMenuOpen())
            {
                aniM.Visible = !aniM.Visible;
            }
        }


    }
}
