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
    public partial class Frm_Statistics : Form
    {
        public Frm_Statistics()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db =new EgitimKampiEFTravelDbEntities();
        private void Frm_Statistics_Load(object sender, EventArgs e)
        {

            lblLocationCount.Text = db.Tbl_Location.Count().ToString();
            lblSumCapacity.Text=db.Tbl_Location.Sum(x=>x.Capacity).ToString();
            lblGuideCount.Text=db.Tbl_Guide.Count().ToString();
            lblAveCapacity.Text=db.Tbl_Location.Average(x=>x.Capacity)?.ToString("F2");
            lblAveLocationPrice.Text = (Math.Round((double)db.Tbl_Location.Average(x => x.Price), 2)).ToString("F2") + " ₺";
            int lastCountryId = db.Tbl_Location.Max(x => x.LocationId);

            lblLastCountryName.Text = db.Tbl_Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();
            lblCapadociaLocationCapacity.Text = db.Tbl_Location.Where(x => x.City == "Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();
            lblTurkAveCapacity.Text = db.Tbl_Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity)?.ToString("F2");
            
            var romaGuideId=db.Tbl_Location.Where(x=>x.City=="Roma").Select(y=>y.GuideId).FirstOrDefault();
            lblRomaGuideName.Text=db.Tbl_Guide.Where(x=>x.GuideId==romaGuideId).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault();

            var maxCapacity=db.Tbl_Location.Max(y=>y.Capacity);
            lblMaxCapacityLocation.Text=db.Tbl_Location.Where(x=>x.Capacity==maxCapacity).Select(z=>z.City).FirstOrDefault().ToString();

            var maxPrice=db.Tbl_Location.Max(x=>x.Price);
            lblMaxPriceLocation.Text=db.Tbl_Location.Where(y=>y.Price==maxPrice).Select(z=>z.City).FirstOrDefault().ToString();

            var yasarGuideId=db.Tbl_Guide.Where(x=>x.GuideName=="Yaşar" && x.GuideSurname=="Ulaş").Select(y=>y.GuideId).FirstOrDefault();
            lblYasarUlasLocationCount.Text=db.Tbl_Location.Where(y=>y.GuideId==yasarGuideId).Count().ToString();




        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
