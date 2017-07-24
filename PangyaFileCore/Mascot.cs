using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore
{
    public class Mascot: PangyaFile<Mascot>
    {
        public bool Enabled { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Price30 { get; set; }
        public int PriceType { get; set; }

        public int Power { get; set; } 
        public int Control { get; set; }
        public int Accuracy { get; set; } 
        public int Spin { get; set; } 
        public int Curve { get; set; }
        public int Lounge { get; set; }

        public int PowerSlot { get; set; } 
        public int ControlSlot { get; set; }
        public int AccuracySlot { get; set; }
        public int SpinSlot { get; set; }
        public int CurveSlot { get; set; }

        protected override int ItemHeaderLength
        {
            get
            {
                return 284;
            }
        }

        protected override Mascot Get(byte[] data)
        {
            return new Mascot()
            {
                Enabled = Convert.ToBoolean(data[0]),
                Id = data.ToIntenger(startIndex: 4, count: 4),
                Name = Encoding.ASCII.GetString(data.Skip(8).TakeWhile(x => x != 0x00).ToArray()),
                PriceType = data.ToIntenger(startIndex: 105, count: 2),
            };
        }
    }
}
