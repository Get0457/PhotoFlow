using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFlow
{
    public interface ISaveable
    {
        JObject SaveData();
        void LoadData(JObject bytes);
    }
}
