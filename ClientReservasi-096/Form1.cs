using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReservasi_096
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;
            string NamaCustomer = textBoxNama.Text;
            string NoTelepon = textBoxNoTlf.Text;
            int JumlahPemesanan = int.Parse(textBoxJumlah.Text);
            string IDLokasi = textBoxNama.Text;

            var a = service.pemesanan(IDPemesanan, NamaCustomer, NoTelepon, JumlahPemesanan, IDLokasi);
            MessageBox.Show(a);
            TampilData();
            Clear();

        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;

            var a = service.deletePemesanan(IDPemesanan);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }
        public void TampilData()
        {
            var List = service.Pemesanan1();
            dtPemesanan.DataSource = List;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;
            string NamaCustomer = textBoxNama.Text;
            string NoTelepon = textBoxNoTlf.Text;

            var a = service.editPemesanan(IDPemesanan, NamaCustomer, NoTelepon);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBoxID.Clear();
            textBoxNama.Clear();
            textBoxNoTlf.Clear();
            textBoxJumlah.Clear();
            textBoxNama.Clear();

            textBoxJumlah.Enabled = true;
            textBoxNama.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = true;
            btHapus.Enabled = false;

            textBoxID.Enabled = true;
        }
        private void dtPemesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[0].Value);
            textBoxNama.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[1].Value);
            textBoxNoTlf.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[2].Value);
            textBoxJumlah.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[3].Value);
            textBoxNama.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[4].Value);

            textBoxJumlah.Enabled = false;
            textBoxNama.Enabled = false;

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            textBoxID.Enabled = false;
        }
    }
}
