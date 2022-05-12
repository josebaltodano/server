using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Applications.Services;
using DepreciationDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepreciationDBApp.Forms
{
    public partial class Form1 : Form
    {
        private IAssetService assetService;
        private static int ideactivo = 0;
        private bool borrar = false;
        public Form1(IAssetService assetService)
        {
            this.assetService = assetService;
            InitializeComponent();
        }
        private void LoadDT1()
        {
            dgvAsset.DataSource = assetService.GetAll();
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            Asset asset = new Asset()
            {
                Name = textBox1.Text,
                Description =richTextBox1.Text,
                Amount = decimal.Parse(textBox2.Text),
                AmountResidual = decimal.Parse(textBox3.Text),
                Terms = int.Parse(textBox4.Text),
                Code = Guid.NewGuid().ToString(),
                Status = comboBox1.SelectedItem.ToString(),
                IsActive = true
            };

            assetService.Create(asset);
            LoadDT1();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar este activo", "Adventercia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var Asset = assetService.FindById(ideactivo);
                assetService.Delete(Asset);
                Clean();
                LoadDT1();
                borrar = true;
                LoadID(borrar);




            }
            else
            {
                Clean();
            }
          
            
        }
        private void Clean()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
            textBox4.Enabled = true;
            textBox2.Enabled = true;

        }
      


        }

    }
