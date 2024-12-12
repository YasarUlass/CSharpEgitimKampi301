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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db=new EgitimKampiEFTravelDbEntities();
        private void BtnList_Click(object sender, EventArgs e)
        {
            var values=db.Tbl_Location.ToList();
            dataGridView1.DataSource = values;
        }
    }
}
