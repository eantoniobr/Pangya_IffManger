using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore
{
    public abstract class PangyaFile<T>
    {
        protected abstract int ItemHeaderLength { get; }

        public List<T> Itens { get; set; }

        public List<T> GetFromFile(string filePath)
        {
            Itens = new List<T>();

            //Lê todos os bytes do arquivo
            var data = File.ReadAllBytes(filePath);

            //var totalParts = ((Data.Length - 8) / PartData);

            //Lê quantidade de Roupas disponíveis. Posição inicial: 0 do arquivo .iff
            var Total = BitConverter.ToUInt32(data, 0);

            //Loop para ler todas as roupas
            for (int i = 0; i < Total; i++)
            {
                //Cada roupa tem um total exato de 544 bytes
                var itemData = new byte[ItemHeaderLength];

                //Lê a primeira roupa, cada roupa começa com o byte 01 (exemplo, posição 8 do arquivo)
                Buffer.BlockCopy(data, ItemHeaderLength * i + 8, itemData, 0, ItemHeaderLength);

                //T.Get(itemData);
                //Lê informações da roupa
                Itens.Add(Get(itemData));
            }

            return Itens;
        }

       protected abstract T Get(byte[] data);
    }
}
