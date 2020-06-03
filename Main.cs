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
            AddAnimation(aniM,"amb@world_human_hang_out_street@female_arms_crossed@idle_a", "idle_a");
            AddStop(aniM);
            mpool.RefreshIndex();

            Tick += OnTick;
            KeyDown += OnKeyDown;
        }

     
        private void AddAnimation(UIMenu menu, string animdict, string anim)
        {
            UIMenuItem animbtn = new UIMenuItem(animdict);
            menu.AddItem(animbtn);
            menu.OnItemSelect += (sender, item, index) =>{
                if(item == animbtn)
                {
                    Player.Task.PlayAnimation(animdict, anim, 8f, -1, AnimationFlags.CancelableWithMovement);
                }
            };
        

        }

        private void AddStop(UIMenu menu)
        {
            UIMenuItem Stopbtn = new UIMenuItem("Stop Animation");
            menu.AddItem(Stopbtn);
            menu.OnItemSelect += (sender, item, index) =>
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
