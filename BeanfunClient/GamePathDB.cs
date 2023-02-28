using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanfunLogin
{
    class GamePathDB
    {
        Dictionary<string, string> alias = new Dictionary<string, string>()
            {
                {"新楓之谷", "MapleStory.exe"},
                {"艾爾之光", "elsword.exe"},
                {"跑跑", "KartRider.exe"},
                {"mabinogi", "mabinogi.exe" },
            };

        Dictionary<string, string> db;
        public GamePathDB()
        {
            string oldGamePath = GomiBean.Properties.Settings.Default.gamePath;
            string raw = GomiBean.Properties.Settings.Default.gamePathDB;
            db = new Dictionary<string, string>();

            if (oldGamePath != "")
            {
                db["MapleStory"] = oldGamePath;
                GomiBean.Properties.Settings.Default.gamePath = "";
            }

            try
            {
                db = JsonConvert.DeserializeObject<Dictionary<string, string>>(raw);
            }
            catch
            {
                GomiBean.Properties.Settings.Default.gamePathDB = JsonConvert.SerializeObject(db);
            }

            GomiBean.Properties.Settings.Default.Save();
        }

        public string GetAlias(string key)
        {
            foreach (string k in alias.Keys)
            {
                if (key.Contains(k))
                {
                    return alias[k];
                }
            }

            return key;
        }

        public string Get(string key)
        {
            string val = "";
            return db.TryGetValue(GetAlias(key), out val) == true ? val : "";
        }

        public void Set(string key, string val)
        {

            db[GetAlias(key)] = val;
        }

        public void Save()
        {
            GomiBean.Properties.Settings.Default.gamePathDB = JsonConvert.SerializeObject(db);
            GomiBean.Properties.Settings.Default.Save();
        }
    }

    public class GameService
    {
        public string name { get; set; }
        public string service_code { get; set; }
        public string service_region { get; set; }

        public GameService(string name, string service_code, string service_region)
        {
            this.name = name;
            this.service_code = service_code;
            this.service_region = service_region;
        }
    }
}
