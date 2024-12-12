using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void BtnList_Click(object sender, EventArgs e)
        {
            var values=db.Tbl_Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Guide guide= new Tbl_Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname= txtSurname.Text;
            db.Tbl_Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Eklendi");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var removeId=db.Tbl_Guide.Find(id);
            db.Tbl_Guide.Remove(removeId);
            db.SaveChanges();
            MessageBox.Show("Rehber Silindi...");

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue=db.Tbl_Guide.Find(id);
            updateValue.GuideName=txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı...","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void BtnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var getGuide=db.Tbl_Guide.Where(x=> x.GuideId==id).ToList();
            dataGridView1.DataSource=getGuide;

        }
    }
}
