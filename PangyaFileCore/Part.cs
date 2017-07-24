using System;
using System.Linq;
using System.Text;

namespace PangyaFileCore
{
    public enum PriceTypeEnum
    {
        Pang = 0x22,
        Pang_Purchase_Only_WithIcon = 0x60,
        Cookie = 0x21,
    }

    public class Part : PangyaFile<Part>
    {
        public bool Enabled { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int PriceType { get; set; }

        public int Power { get; set; } 
        public int Control { get; set; } 
        public int Accuracy { get; set; }
        public int Spin { get; set; } 
        public int Curve { get; set; } 

        public int PowerSlot { get; set; }
        public int ControlSlot { get; set; }
        public int AccuracySlot { get; set; }
        public int SpinSlot { get; set; }
        public int CurveSlot { get; set; }

        protected override int ItemHeaderLength
        {
            get
            {
                return 544;
            }
        }

        protected override Part Get(byte[] data)
        {
            return new Part()
            {
                Enabled = Convert.ToBoolean(data[0]), //Posição 0
                Id = data.ToIntenger(startIndex: 4, count: 4), //Posição 4
                Name = Encoding.ASCII.GetString(data.Skip(8).TakeWhile(x => x != 0x00).ToArray()),
                Price = data.ToIntenger(startIndex: 92, count: 2), //Posição 92
                PriceType = Convert.ToInt32(data[104]), //Posição 104

                //Attributes
                Power = Convert.ToInt32(data[460]), //Posição 460
                Control = Convert.ToInt32(data[462]),
                Accuracy = Convert.ToInt32(data[464]),
                Spin = Convert.ToInt32(data[466]),
                Curve = Convert.ToInt32(data[468]),

                //Slots
                PowerSlot = Convert.ToInt32(data[470]),
                ControlSlot = Convert.ToInt32(data[472]),
                AccuracySlot = Convert.ToInt32(data[474]),
                SpinSlot = Convert.ToInt32(data[476]),
                CurveSlot = Convert.ToInt32(data[478])
            };
        }

    }
}
