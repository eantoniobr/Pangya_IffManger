using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore
{
    public class Caddie : PangyaFile<Caddie>
    {
        protected override int ItemHeaderLength
        {
            get
            {
                return 224;
            }
        }

        public bool Enabled { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Preco { get; set; } 
        public int Power { get; set; }
        public int Spin { get; set; }
        public int LvlReq { get; set; }
        public int PriceType { get; set; }

        protected override Caddie Get(byte[] data)
        {
            return new Caddie()
            {
                Enabled = Convert.ToBoolean(data[0]),
                Id = data.ToIntenger(startIndex: 4, count: 4),
                Name = Encoding.ASCII.GetString(data.Skip(8).TakeWhile(x => x != 0x00).ToArray()),
                Preco = data.ToIntenger(startIndex: 92, count: 2),
                PriceType = Convert.ToInt32(data[50]),
                LvlReq = Convert.ToInt32(data[48]),
                Power = Convert.ToInt32(data[212]),
                Spin = Convert.ToInt32(data[218]),
            };
        }
    }
}
