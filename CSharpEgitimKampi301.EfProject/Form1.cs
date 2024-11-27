using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EfProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1();
        private void btnList_Click(object sender, EventArgs e)
        {

            var values = db.TblGuides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblGuides guide = new TblGuides();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.TblGuides.Add(guide);
            db.SaveChanges();

            MessageBox.Show("Rehber başrıyla eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.TblGuides.Find(id);
            db.TblGuides.Remove(removeValue);
            db.SaveChanges();

            MessageBox.Show("Rehber başarıyla silindi");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.TblGuides.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();

            MessageBox.Show("Rehber başarıyla güncellendi", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.TblGuides.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource= values;
        }
    }
}
