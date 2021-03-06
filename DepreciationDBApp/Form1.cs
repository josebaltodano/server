using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Applications.Services;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Enum;
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
            //loaddata();
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
                Name = txtnombre.Text,
                Amount = decimal.Parse(txtvalor.Text),
                AmountResidual = decimal.Parse(txtvalorresidual.Text),
                Terms = int.Parse(txtvidautil.Text),
                Description = richTextBox1.Text,
                Status = comboBox1.SelectedItem.ToString(),
                Code = GeneradorCodigo(),
                IsActive = true,

        
             
            };
            if (decimal.Parse(txtvalorresidual.Text) > decimal.Parse(txtvalor.Text))
            {
                MessageBox.Show("No debe de ser mayor que el valor del activo");
            }
            else
            {
                assetService.Create(asset);
               /* loaddata()*/;
                Clean();
            }

            //assetService.Create(asset);
            LoadDT1();

        }
        //private void loaddata() => dgvAsset.DataSource = assetService.GetAll();
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea eliminar este activo", "Adventercia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //var Asset = assetService.FindById(ideactivo);
                    //assetService.Delete(Asset);
                    //Clean();
                    ////loaddata();
                    //borrar = true;
                    //LoadID(borrar);
                    //LoadDT1();

                    object a = dgvAsset.CurrentRow.Cells[0].Value;
                    Asset asset = assetService.FindById((Int32)a);
                    asset.IsActive = false;
                    assetService.Update(asset);
                    assetService.Delete(asset);
                    fillDgv();
                    Clean();
                   





                }
                else
                {
                   
                }
            }
            catch (Exception)
            {
                throw;
            }
            
          
            
        }
        private void Clean()
        {
            txtnombre.Clear();
            txtvidautil.Clear();
            txtvalorresidual.Clear();
            txtvalor.Clear();
            richTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
            txtvalor.Enabled = true;
            txtvidautil.Enabled = true;

        }
        public string GeneradorCodigo()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            return new String(Charsarr);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtvalor_TextChanged(object sender, EventArgs e)
        {

        }
        private void fillDgv()
        {
            dgvAsset.DataSource = null;
            List<Asset> assets = assetService.GetAll();
            dgvAsset.DataSource = assets;
        }

        private void dgvAsset_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.RowIndex >= 0)
            {
                Asset asset = assetService.GetAll()[e.RowIndex];
                txtnombre.Text = asset.Name;
                txtvalor.Text = asset.Amount.ToString();
                txtvalorresidual.Text = asset.AmountResidual.ToString();
                txtvidautil.Text = asset.Terms.ToString();
                richTextBox1.Text = asset.Description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validacion.emptyFIelds(txtnombre.Text, txtvalor.Text, txtvalorresidual.Text, txtvidautil.Text, richTextBox1.Text, comboBox1.SelectedIndex))
            {
                if (Validacion.ValidationAmount(decimal.Parse(txtvalor.Text), decimal.Parse(txtvalorresidual.Text)))
                {
                    object u = dgvAsset.CurrentRow.Cells[0].Value;
                    Asset asset = assetService.FindById((Int32)u);
                    asset.Name = txtnombre.Text;
                    asset.Amount = decimal.Parse(txtvalor.Text);
                    asset.AmountResidual = decimal.Parse(txtvalorresidual.Text);
                    asset.Terms = int.Parse(txtvidautil.Text);
                    asset.Description = richTextBox1.Text;
                    asset.Status = comboBox1.SelectedItem.ToString();
                    assetService.Update(asset);
                    fillDgv();
                    Clean();
                }
            }
        }
    }

    }
