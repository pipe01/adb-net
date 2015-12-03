using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB.net
{
    public class Notification
    {
        public enum NotificationFlags
        {
            FLAG_NONE = 0,
            FLAG_SHOW_LIGHTS = 0x00000001,
            FLAG_ONGOING_EVENT = 0x00000002,
            FLAG_INSISTENT = 0x00000004,
            FLAG_ONLY_ALERT_ONCE = 0x00000008,
            FLAG_AUTO_CANCEL = 0x00000010,
            FLAG_NO_CLEAR = 0x00000020,
            FLAG_FOREGROUND_SERVICE = 0x00000040,
            FLAG_HIGH_PRIORITY = 0x00000080,
            FLAG_LOCAL_ONLY = 0x00000100,
            FLAG_GROUP_SUMMARY = 0x00000200
        }
        public static NotificationFlags GetFlagsFromInt(int n)
        {
            NotificationFlags flags = NotificationFlags.FLAG_NONE;
            if (IsBitSet(n, 1))
            {
                flags = flags & NotificationFlags.FLAG_SHOW_LIGHTS;
            } else if (IsBitSet(n, 2)){
                flags = flags & NotificationFlags.FLAG_ONGOING_EVENT;
            } else if (IsBitSet(n, 3)){
                flags = flags & NotificationFlags.FLAG_INSISTENT;
            } else if (IsBitSet(n, 4)){ 
                flags = flags & NotificationFlags.FLAG_ONLY_ALERT_ONCE;
            } else if (IsBitSet(n, 5)){
                flags = flags & NotificationFlags.FLAG_AUTO_CANCEL;
            } else if (IsBitSet(n, 6)){
                flags = flags & NotificationFlags.FLAG_NO_CLEAR;
            } else if (IsBitSet(n, 7)){
                flags = flags & NotificationFlags.FLAG_FOREGROUND_SERVICE;
            } else if (IsBitSet(n, 8)){
                flags = flags & NotificationFlags.FLAG_HIGH_PRIORITY;
            } else if (IsBitSet(n, 9)){
                flags = flags & NotificationFlags.FLAG_LOCAL_ONLY;
            } else if (IsBitSet(n, 10)){
                flags = flags & NotificationFlags.FLAG_GROUP_SUMMARY;
            }
            return flags;
        }
        private static bool IsBitSet(int b, int pos)
        {
            return (b & pos) == pos;
        }

        public readonly string PackageName;
        public readonly NotificationFlags Flags = NotificationFlags.FLAG_NONE;

        public Notification() { }
        public Notification(string packageName, NotificationFlags flags)
        {
            PackageName = packageName;
            Flags = flags;
        }
        public Notification(string packageName, int flags)
        {
            PackageName = packageName;
            Flags = GetFlagsFromInt(flags);
        }

    }
}
