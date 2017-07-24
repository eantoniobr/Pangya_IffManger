using PangyaFileCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pangya_IffManger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Pangya File (*.iff)|*.iff";
            //+ "Character (Character*.iff)|Character*.iff";

            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = openFileDialog.SafeFileName.ToLower();

                try
                {
                    switch (fileName)
                    {
                        case "character.iff":
                            {
                                PangyaFile<Character> arquivo = new Character();
                                this.dataGridView1.DataSource = arquivo.GetFromFile(filePath);
                            }
                            break;
                        case "part.iff":
                            {
                                PangyaFile<Part> arquivo = new Part();
                                this.dataGridView1.DataSource = arquivo.GetFromFile(filePath);
                            }
                            break;
                        case "card.iff":
                            {
                                PangyaFile<Card> arquivo = new Card();
                                this.dataGridView1.DataSource = arquivo.GetFromFile(filePath);
                            }
                            break;
                        case "caddie.iff":
                            {
                                PangyaFile<Caddie> arquivo = new Caddie();
                                this.dataGridView1.DataSource = arquivo.GetFromFile(filePath);
                            }
                            break;
                        case "setitem.iff":
                            {
                                PangyaFile<SetItem> arquivo = new SetItem();
                                this.dataGridView1.DataSource = arquivo.GetFromFile(filePath);
                            }
                            break;
                        case "mascot.iff":
                            {
                                PangyaFile<Mascot> arquivo = new Mascot();
                                this.dataGridView1.DataSource = arquivo.GetFromFile(filePath);
                            }
                            break;
                        default:
                            {
                                MessageBox.Show($"A leitura de {openFileDialog.SafeFileName} não implementado, escolha outro arquivo.");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar ler o arquivo. Mensagem: " + ex.Message);
                }
            }
        }
    }
}
