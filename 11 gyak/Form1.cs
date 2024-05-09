using System.Windows.Forms;

namespace _11_gyak
{
    public partial class Form1 : Form
    {
        private object context;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();

            UserControl userControl1 = new UserControl();

            panel1.Controls.Add(userControl1);

            userControl1.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            UserControl userControl2 = new UserControl();

            panel1.Controls.Add(userControl2);

            userControl2.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public userControl1()
        {
            InitializeComponent();

            FillDataSource();
            listBox1.DisplayMember = "Name";
        }

        private void FillDataSource()
        {
            listBox1.DataSource = (from i in context.Instructors
                                   where i.Name.Contains(textBox1.Text)
                                   select i).ToList();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            FillDataSource();
        }
    }
}