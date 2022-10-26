using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HOME_4._4
{



    public partial class Form1 : Form
    {

        public Bitmap b;
        public Graphics g;
        public Random r = new Random();
        public Pen penRed = new Pen(Color.OrangeRed, 1);
        public Pen penBlue = new Pen(Color.Blue, 1);
        public Pen penPurple = new Pen(Color.Black, 1);
       double successPr ;


        //private void trackBar1_Scroll(object sender, EventArgs e)
        //{
        //    label1.Text = "Number of trials: " + trackBar1.Value.ToString();
        //}

        //private void trackBar2_Scroll(object sender, EventArgs e)
        //{
        //}
        //    //label2.Text = "Number of trajectories: " + trackBar2.Value.ToString();

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private int fromYrealToYVirtual(double y, double minY, double maxY, int h)
        {
            if ((maxY - minY) == 0)
                return 0;

            return Convert.ToInt32(h - ((y - minY) * h) / (maxY - minY));
        }
        private int fromXrealToXVirtual(double x, double minX, double maxX, int w)
        {
            if ((maxX - minX) == 0)
            {
                return 0;
            }
            return Convert.ToInt32(((x - minX) * w) / (maxX - minX));
        }

        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "0,5";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            this.richTextBox1.AppendText("|Fr abs | Fr rel | Fr norm \n");
            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);


            int trialsCount = trackBar4.Value;
            int numerOfTrajectories = 50;
            Boolean success = Double.TryParse(comboBox1.Text, out successPr);
            if (!success || (success & (successPr > 1 || successPr < 0))) successPr = 0.5;
            int TrajectoryNumber = trackBar3.Value;


            for (int i = 1; i <= numerOfTrajectories; i++)
            {
                List<Point> punti1 = new List<Point>();
                List<Point> punti2 = new List<Point>();
                List<Point> punti3 = new List<Point>();

                double Y = 0;
                for (int X = 1; X <= trialsCount; X++)
                {
                    double Uniform = r.NextDouble();
                    if (Uniform < successPr)
                        Y = Y + 1;
                    int xDevice = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int yDevice = fromYrealToYVirtual(Y, 0, trialsCount, pictureBox1.Height);

                    int x2Device = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int y2Device = fromYrealToYVirtual(Y * trialsCount / (X + 1), 0, trialsCount, pictureBox1.Height);

                    int x3Device = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int y3Device = fromYrealToYVirtual(Y * (Math.Sqrt(trialsCount)) / (Math.Sqrt(X + 1)), 0, trialsCount * successPr, pictureBox1.Height);

                    punti1.Add(new Point(xDevice, yDevice));
                    punti2.Add(new Point(x2Device, y2Device));
                    punti3.Add(new Point(x3Device, y3Device));
                }
                Point p1 = punti1[trialsCount - 1];
                Point p2 = punti2[trialsCount - 1];
                Point p3 = punti3[trialsCount - 1];

                this.richTextBox1.AppendText("|  " + p1.Y.ToString() + "   |  " + p2.Y.ToString() + "   |    " + p3.Y.ToString() + "  \n");

                this.g.DrawLines(penRed, punti1.ToArray());
                this.g.DrawLines(penBlue, punti2.ToArray());
                this.g.DrawLines(penPurple, punti3.ToArray());

            }
            this.pictureBox1.Image = b;

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Number of trials: " + trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Number of trajectories: " + trackBar4.Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    
}