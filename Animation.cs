using System.Collections.Generic;
using System.IO;
namespace GTAAnimator.Animations
{
    internal class Animation
    {
        internal Dictionary<string, string> Animations = new Dictionary<string, string>();
        private string path;
        internal Animation(string Path)
        {
            path = Path;
        }

        internal void Read()
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
