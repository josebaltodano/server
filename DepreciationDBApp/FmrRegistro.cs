using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
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
    public partial class FmrRegistro : Form
    {
        public Iemployeeservice iemployeeservice;
        public FmrRegistro(Iemployeeservice iemployeeservice)
        {
            this.iemployeeservice = iemployeeservice;
            InitializeComponent();
        }
        public void data ()=> dataGridView1.DataSource = iemployeeservice.GetAll();
        private void btnenviar_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                Names = txtnombre.Text,
                Lastnames = txtapellido.Text,
                Address = txtandress.Text,
                Phone = txttelefono.Text,
                Email = txtemail.Text,
                Dni = txtdni.Text,
                Status = txtstatus.SelectedItem.ToString()

            };
            iemployeeservice.Create(employee);
            data();
            Clean();
        }
        private void Clean()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtandress.Clear();
            txttelefono.Clear();
            txtemail.Clear();
            txtstatus.SelectedIndex = -1;
            txtdni.Clear();
           
        
        }
    }
}
