using System.Collections.Generic;
using System.IO;
namespace GTAAnimator.Animations
{
    internal class Animation
    {
        public Dictionary<string, string> Animations = new Dictionary<string, string>();
        private string path;
        public Animation(string Path)
        {
            path = Path;
        }

        public void Read()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string _line;
                while((_line = sr.ReadLine()) != null){
                    string[] keyvalue = _line.Split('=');
                    if(keyvalue.Length == 2)
                    {
                        Animations.Add(keyvalue[0], keyvalue[1]);
                    }
                }
            }
        }

    }
}
