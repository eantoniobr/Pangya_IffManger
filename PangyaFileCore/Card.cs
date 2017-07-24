using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore
{
    public class Card : PangyaFile<Card>
    {
        public bool Enabled { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Preco { get; set; }
        public int ShopFlags { get; set; }
        public int Tag { get; set; }

        protected override int ItemHeaderLength
        {
            get
            {
                return 360;
            }
        }

        protected override Card Get(byte[] data)
        {
            return new Card()
            {
                Enabled = Convert.ToBoolean(data[0]),
                Id = data.ToIntenger(startIndex: 4, count: 4),
                Name = Encoding.ASCII.GetString(data.Skip(8).TakeWhile(x => x != 0x00).ToArray()),
                Preco = data.ToIntenger(startIndex: 92, count: 2),
                ShopFlags = Convert.ToInt32(data[104]),
                Tag = Convert.ToInt32(data[94])
            };
        }
    }
}
