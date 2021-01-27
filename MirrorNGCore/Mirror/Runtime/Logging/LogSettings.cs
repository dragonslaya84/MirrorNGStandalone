using System;
using System.Collections.Generic;
#if NETSTANDARD
using UnityEngine;
#endif

namespace Mirror.Runtime.Logging
{
#if NETSTANDARD
    [ExecuteInEditMode]
    [AddComponentMenu("Network/LogSettings")]
    public class LogSettings : MonoBehaviour
    #else
    public class LogSettings
#endif
    {
        [Serializable]
        public struct Level
        {
            public string Name;
            public LogType level;
        };

#if NETSTANDARD
        [SerializeField]
#endif
        public List<Level> Levels = new List<Level>();

        // Start is called before the first frame update
        void Awake()
        {
            SetLogLevels();
        }

        public void SetLogLevels()
        {
            foreach (Level setting in Levels)
            {
                var logger = LogFactory.GetLogger(setting.Name);
                logger.filterLogType = setting.level;
            }
        }
    }
}