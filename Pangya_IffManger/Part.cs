using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pangya_IffManger.PartManager;

namespace Pangya_IffManger
{
    public enum PriceTypeEnum
    {
        Pang = 0x22,
        Pang_Purchase_Only_PINTINHO = 0x60,
        Cookie = 0x21,
    }

    /// <summary>
    /// Cada part.iff tem exatos 544 bytes
    /// </summary>
    public class Part
    {
        public bool Enabled { get; set; }

        public int Id { get; set; }
        //public int Id2 { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int PriceType { get; set; }

        public int Power { get; set; } //Index 460
        public int Control { get; set; } //Index 462
        public int Accuracy { get; set; } //Index 464
        public int Spin { get; set; } //Index 466
        public int Curve { get; set; } //Index 468

        public int PowerSlot { get; set; } //Index 470
        public int ControlSlot { get; set; } //Index 472
        public int AccuracySlot { get; set; } //Index 474
        public int SpinSlot { get; set; } //Index 476
        public int CurveSlot { get; set; } //Index 478

    }
}
