using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ADB_Helper
{
    class Device
    {
        public string id, name, vendor;
        public NavBar navBar;
        public Size resolution;
        public float scale;

        public static Device LoadInstalled(string name)
        {
            if (!File.Exists("./res/devices/" + name + ".xml")) return null;

            Dictionary<string, NavBar> navs = NavBar.GetAllAvailable();
            Device dev = new Device();
            dev.navBar = navs["stk_lollipop"];

            using (XmlReader reader = XmlReader.Create("./res/devices/" + name + ".xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "id":
                                reader.Read();
                                dev.id = reader.Value;
                                break;
                            case "name":
                                reader.Read();
                                dev.name = reader.Value;
                                break;
                            case "vendor":
                                reader.Read();
                                dev.vendor = reader.Value;
                                break;
                            case "navbarid":
                                reader.Read();
                                NavBar t = null;
                                if (navs.TryGetValue(reader.Value, out t))
                                    dev.navBar = NavBar.GetAllAvailable()[reader.Value];
                                break;
                            case "res":
                                reader.Read();
                                string[] s = reader.Value.Split('x');
                                dev.resolution = new Size(int.Parse(s[0]), int.Parse(s[1]));
                                break;
                            case "rem_scale":
                                reader.Read();
                                dev.scale = float.Parse(reader.Value);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return dev;
        }

        public static List<Device> GetAllInstalled()
        {
            List<Device> list = new List<Device>();
            foreach (string item in Directory.EnumerateFiles("./res/devices"))
            {
                list.Add(LoadInstalled(Path.GetFileNameWithoutExtension(item)));
            }
            return list;
        }

        public static Device GetDeviceByName(string name)
        {
            List<Device> devices = GetAllInstalled();
            foreach (Device item in devices)
            {
                if (item.name == name)
                    return item;
            }
            return null;
        }
    }
}
