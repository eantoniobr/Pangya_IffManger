using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Manager criado por ericv2_a@hotmail.com -> cavaleirodovent (ragezone)
/// </summary>

namespace Pangya_IffManger
{
    public class PartManager
    {
        public List<Part> Load(string filePatch)
        {
            //Lê todos os bytes do arquivo
            var data = File.ReadAllBytes(filePatch);

            //var totalParts = ((Data.Length - 8) / PartData);

            //Lê quantidade de Roupas disponíveis. Posição inicial: 0 do arquivo .iff
            var totalParts = BitConverter.ToUInt32(data, 0);

            //Para armazenar as roupas
            List<Part> partList = new List<Part>();

            //Loop para ler todas as roupas
            for (int i = 0; i < totalParts; i++)
            {
                //Cada roupa tem um total exato de 544 bytes
                var partData = new byte[544];

                //Lê a primeira roupa, cada roupa começa com o byte 01 (exemplo, posição 8 do arquivo)
                Buffer.BlockCopy(data, 544 * i + 8, partData, 0, 544);

                //Lê informações da roupa
                partList.Add(GetPart(partData));
            }

            return partList;

        }

        private Part GetPart(byte[] data)
        {
            return new Part()
            {
                Enabled = Convert.ToBoolean(data[0]), //Posição 0
                Id = data.ToIntenger(startIndex: 4, count: 4), //Posição 4
                Name = Encoding.ASCII.GetString(data.Skip(8).TakeWhile(x => x != 0x00).ToArray()), //Posição 8, lê o nome enquanto o byte for diferente de 0x00
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
