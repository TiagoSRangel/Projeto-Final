using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cartas_Yugioh
{
    public class CartasYugioh
    {
        public int id { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
    }
}
