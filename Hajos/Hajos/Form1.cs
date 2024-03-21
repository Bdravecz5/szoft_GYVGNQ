namespace Hajos
{
    public partial class Form1 : Form
    {
        List<Kerdes> ÖsszesKérdés;
        List<Kerdes> AktívKérdések;
        int AktívKérdés = 5;
        public Form1()
        {
            InitializeComponent();
        }
        List<Kerdes> KérdésBeolvasás()
        {
            List<Kerdes> kérdések = new List<Kerdes>();
            StreamReader sr = new StreamReader("text.txt", true);

            while (!sr.EndOfStream)
            {

                string sor = sr.ReadLine() ?? string.Empty;

                string[] tömb = sor.Split("\t");
                if (tömb.Length != 7) continue;

                Kerdes k = new Kerdes();
                k.KérdésSzöveg = tömb[1];
                k.Válasz1 = tömb[2];
                k.Válasz2 = tömb[3];
                k.Válasz3 = tömb[4];
                k.URL = tömb[5];

                int.TryParse(tömb[6], out int jóválasz);

                k.HelyesVálasz = jóválasz;

                kérdések.Add(k);
            }
            sr.Close();
            return kérdések;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = AktívKérdések;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AktívKérdések = new List<Kerdes>();
            ÖsszesKérdés = KérdésBeolvasás();
            for (int i = 0; i < 7; i++)
            {
                AktívKérdések.Add(ÖsszesKérdés[0]);
                ÖsszesKérdés.RemoveAt(0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            internal class VálaszGomb : TextBox
        {
            public VálaszGomb()
            {
                BackColor = Color.LightGray;
                Multiline = true;
                ReadOnly = true;

                MouseEnter += VálaszGomb_MouseEnter;
                MouseLeave += VálaszGomb_MouseLeave;

                BorderStyle = BorderStyle.None;
                Cursor = Cursors.Hand;
            }

            private void VálaszGomb_MouseLeave(object? sender, EventArgs e)
            {
                BorderStyle = BorderStyle.None;
            }
        
            private void VálaszGomb_MouseEnter(object? sender, EventArgs e)
            {
                BorderStyle = BorderStyle.FixedSingle;
            }
        }
    
    }
    }

