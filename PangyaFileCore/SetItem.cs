using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore
{
    public class SetItem : PangyaFile<SetItem>
    {
        public bool Enabled { get; set; } 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        protected override int ItemHeaderLength
        {
            get
            {
                return 244;
            }
        }

        protected override SetItem Get(byte[] data)
        {
            return new SetItem()
            {
                Enabled = Convert.ToBoolean(data[0]),
                Id = data.ToIntenger(startIndex: 4, count: 4), 
                Name = Encoding.ASCII.GetString(data.Skip(8).TakeWhile(x => x != 0x00).ToArray()),
                Price = data.ToIntenger(startIndex: 94, count: 2),
            };
        }
    }
}
