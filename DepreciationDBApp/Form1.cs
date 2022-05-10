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
                Status = "Disponible",
                IsActive = true
            };

            assetService.Create(asset);
            LoadDT1();
            
        }
    }

}
