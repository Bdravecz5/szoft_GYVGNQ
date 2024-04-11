using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace adatkovetes
{
    public partial class Form1 : Form
    {
        BindingList<CountryData> countrylist = new();
        public Form1()
        {
            InitializeComponent();
            countryDataBindingSource.DataSource = countrylist;

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("europeancountries.csv");
            var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var tomb = csv.GetRecords<CountryData>();
            foreach (var item in tomb)
            {
                countrylist.Add(item);
            }
        }

        private void Szerkesztés_Click(object sender, EventArgs e)
        {
            FormCountryData formCountryData = new FormCountryData();
            formCountryData.Country = (CountryData)countryDataBindingSource.Current;
            formCountryData.Show();
        }

        private void Törlés_Click(object sender, EventArgs e)
        {
            FormCountryData fcd = new FormCountryData();
            fcd.Country = countryDataBindingSource.Current as CountryData;
            fcd.ShowDialog();
        }
    }
}