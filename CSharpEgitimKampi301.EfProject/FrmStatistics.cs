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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            lblLocationCount.Text = db.TblLocations.Count().ToString();
            lblSumCapasity.Text = db.TblLocations.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.TblGuides.Count().ToString();
            lblAvgCapasity.Text = db.TblLocations.Average(x => x.Capacity).ToString();
            lblAvgLocationPrice.Text = db.TblLocations.Average(x => x.Price).ToString() + "₺";

            int lastCountryId = db.TblLocations.Max(x => x.LocationId);
            lblLastCountryName.Text = db.TblLocations.Where(x => x.LocationId ==
            lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCappodociaLocationCapasity.Text = db.TblLocations.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeAvgCapasity.Text = db.TblLocations.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var RomeGuidId = db.TblLocations.Where(x => x.City == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuidName.Text = db.TblGuides.Where(x => x.GuideId == RomeGuidId).
                Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var MaxCapasity = db.TblLocations.Max(x => x.Capacity);
            lblMaxCapasityLocation.Text =
    db.TblLocations.Where(x => x.Capacity == MaxCapasity).Select(y => y.City).FirstOrDefault().ToString();

            var maxPrice = db.TblLocations.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.TblLocations.Where
                (x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var guidIdByNameAliYıldız = db.TblGuides.Where(x => x.GuideName == "Ali" && x.GuideSurname == "Yıldız").
                Select(y => y.GuideId).FirstOrDefault();
            lblAliYıldızLocationCount.Text =
                db.TblLocations.Where(x => x.GuideId == guidIdByNameAliYıldız).Count().ToString();
        }

    }
}
