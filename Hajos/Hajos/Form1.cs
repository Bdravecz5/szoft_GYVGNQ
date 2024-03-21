namespace Hajos
{
    public partial class Form1 : Form
    {
        List<Kerdes> �sszesK�rd�s;
        List<Kerdes> Akt�vK�rd�sek;
        int Akt�vK�rd�s = 5;
        public Form1()
        {
            InitializeComponent();
        }
        List<Kerdes> K�rd�sBeolvas�s()
        {
            List<Kerdes> k�rd�sek = new List<Kerdes>();
            StreamReader sr = new StreamReader("text.txt", true);

            while (!sr.EndOfStream)
            {

                string sor = sr.ReadLine() ?? string.Empty;

                string[] t�mb = sor.Split("\t");
                if (t�mb.Length != 7) continue;

                Kerdes k = new Kerdes();
                k.K�rd�sSz�veg = t�mb[1];
                k.V�lasz1 = t�mb[2];
                k.V�lasz2 = t�mb[3];
                k.V�lasz3 = t�mb[4];
                k.URL = t�mb[5];

                int.TryParse(t�mb[6], out int j�v�lasz);

                k.HelyesV�lasz = j�v�lasz;

                k�rd�sek.Add(k);
            }
            sr.Close();
            return k�rd�sek;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = Akt�vK�rd�sek;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Akt�vK�rd�sek = new List<Kerdes>();
            �sszesK�rd�s = K�rd�sBeolvas�s();
            for (int i = 0; i < 7; i++)
            {
                Akt�vK�rd�sek.Add(�sszesK�rd�s[0]);
                �sszesK�rd�s.RemoveAt(0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            internal class V�laszGomb : TextBox
        {
            public V�laszGomb()
            {
                BackColor = Color.LightGray;
                Multiline = true;
                ReadOnly = true;

                MouseEnter += V�laszGomb_MouseEnter;
                MouseLeave += V�laszGomb_MouseLeave;

                BorderStyle = BorderStyle.None;
                Cursor = Cursors.Hand;
            }

            private void V�laszGomb_MouseLeave(object? sender, EventArgs e)
            {
                BorderStyle = BorderStyle.None;
            }
        
            private void V�laszGomb_MouseEnter(object? sender, EventArgs e)
            {
                BorderStyle = BorderStyle.FixedSingle;
            }
        }
    
    }
    }

