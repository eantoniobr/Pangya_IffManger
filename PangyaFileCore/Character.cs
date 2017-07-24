using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore
{
    public class Character : PangyaFile<Character>
    {
        public bool Enabled { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public int Preco { get; set; }
        public int Power { get; set; }
        public int Control { get; set; }
        public int Accuracy { get; set; }
        public int Curve { get; set; }
        public int Spin { get; set; }

        protected override int ItemHeaderLength
        {
            get { return 396; }
        }

        protected override Character Get(byte[] data)
        {
            return new Character()
            {
                Enabled = Convert.ToBoolean(data[0]),
                Id = data.ToIntenger(startIndex: 4, count: 4),
                Name = Encoding.ASCII.GetString(data.Skip(8).TakeWhile(x => x != 0x00).ToArray()),
                Preco = data.ToIntenger(startIndex: 92, count: 2),
                Power = Convert.ToInt32(data[328]),
                Control = Convert.ToInt32(data[330]),
                Accuracy = Convert.ToInt32(data[332]),
                Curve = Convert.ToInt32(data[334]),
                Spin = Convert.ToInt32(data[336])
            };
        }
    }
}
