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
    public partial class Frm_Location : Form
    {
        public Frm_Location()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void BtnList_Click(object sender, EventArgs e)
        {
            var values=db.Tbl_Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void Frm_Location_Load(object sender, EventArgs e)
        {
            var values = db.Tbl_Guide.Select(x => new
            {
                Fullname = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cmBoxGuide.DisplayMember = "Fullname";
            cmBoxGuide.ValueMember = "GuideId";
            cmBoxGuide.DataSource = values;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Location location = new Tbl_Location();
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight=txtDay.Text;
            location.GuideId = int.Parse(cmBoxGuide.SelectedValue.ToString());
            db.Tbl_Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Yapıldı...");

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedValue = db.Tbl_Location.Find(id);
            db.Tbl_Location.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Yapıldı...");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var value=db.Tbl_Location.Find(id);
            value.City=txtCity.Text;
            value.Country=txtCountry.Text;
            value.Capacity=byte.Parse(nudCapacity.Value.ToString());
            value.DayNight = txtDay.Text;
            value.Price = decimal.Parse(txtPrice.Text);
            value.GuideId = int.Parse(cmBoxGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Yapıldı...");

        }
    }
}
