using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCam_Capture;
namespace yazlab
{
    public partial class Form1 : Form
    {
        
        
        

        public Form1()
        {
            InitializeComponent();


        }
        public int red = 0, green = 0, blue = 0;
        public int u=12;
        public int aynalandiMi = 0;
        public bool sizes = false;
        public Bitmap tmp;
        
        public void sagaDondur()
        {
            Bitmap kmp = (Bitmap)pictureBox1.Image;
            pictureBox1.Width = pictureBox1.Height;
            pictureBox1.Height = pictureBox1.Width;
            Bitmap b = new Bitmap(kmp.Height, kmp.Width);
            int i;
            int j;
            for (i = 0; i < kmp.Width; i++)
            {
                for (j = 0; j < kmp.Height; j++)
                {

                    //tmp.SetPixel(tmp.Width-1-i,j, tmp.GetPixel(j,i));
                    b.SetPixel(b.Width - 1 - j, i, kmp.GetPixel(i, j));
                }

            }
            pictureBox1.Image = b;
            

        }
        public void sagaDondurtmp()
        {
            Bitmap kmp = (Bitmap)tmp;
            
            Bitmap b = new Bitmap(kmp.Height, kmp.Width);
            int i;
            int j;
            for (i = 0; i < kmp.Width; i++)
            {
                for (j = 0; j < kmp.Height; j++)
                {

                    //tmp.SetPixel(tmp.Width-1-i,j, tmp.GetPixel(j,i));
                    b.SetPixel(b.Width - 1 - j, i, kmp.GetPixel(i, j));
                }

            }
            tmp = b;


        }
        public void solaDondur()
        {
            Bitmap kmp = (Bitmap)pictureBox1.Image;
            pictureBox1.Width = pictureBox1.Height;
            pictureBox1.Height = pictureBox1.Width;
            Bitmap b = new Bitmap(kmp.Height, kmp.Width);
            int i;
            int j;
            for (i = 0; i < kmp.Width; i++)
            {
                for (j = 0; j < kmp.Height; j++)
                {


                    b.SetPixel(j, b.Height - 1 - i, kmp.GetPixel(i, j));
                }

            }
            pictureBox1.Image = b;

        }
        public void aynala()
        {
            Image img = pictureBox1.Image;
            Bitmap bmp = new Bitmap(img);
            int width = bmp.Width;
            int height = bmp.Height;
            Bitmap bmp2 = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {

                for (int i = 0, j = width - 1; i < width; i++, j--)
                {
                    Color p = bmp.GetPixel(i, y);
                    bmp2.SetPixel(j, y, p);

                }
            }

            pictureBox1.Image = bmp2;

        }

        public void aynalaTmp()
        {
           // Image img = pictureBox1.Image;
            Bitmap bmp = new Bitmap(tmp);
            int width = bmp.Width;
            int height = bmp.Height;
            Bitmap bmp2 = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {

                for (int i = 0, j = width - 1; i < width; i++, j--)
                {
                    Color p = bmp.GetPixel(i, y);
                    bmp2.SetPixel(j, y, p);

                }
            }

            tmp= bmp2;

        }
        public void reSize()
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {
                int x, y;
                x = Convert.ToInt32(textBox1.Text);
                y = Convert.ToInt32(textBox2.Text);

                Image yeni = pictureBox1.Image;
                Bitmap bmp = new Bitmap(yeni);
                Bitmap yenibmp = new Bitmap(bmp, x, y);

                pictureBox1.Image = yenibmp;
                //tmp = yenibmp;
            }
        }
        public void reSizetmp()
        {
            int x, y;
            x = Convert.ToInt32(textBox1.Text);
            y = Convert.ToInt32(textBox2.Text);

            Image yeni = tmp;
            Bitmap bmp = new Bitmap(yeni);
            Bitmap yenibmp = new Bitmap(bmp, x, y);

            
            tmp = yenibmp;


        }
       
        public void fotoKaydet()
        {
            string gunAdi = DateTime.Now.DayOfWeek.ToString();
            string gun = DateTime.Now.Day.ToString();
            string saat = DateTime.Now.Minute.ToString();
            string saniye = DateTime.Now.Second.ToString();


            pictureBox1.Image.Save(@"C:\Users\Umut\Documents\pshopex\" + gunAdi + gun + saat + saniye + ".jpg", ImageFormat.Jpeg);


        }
        public void reOpen()
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {
                string dosyaYolu = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                tmp = new Bitmap(pictureBox1.Image);
    }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Resim Dosyaları |" + ".bmp; *.jpg;.gif;*.jpeg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                tmp = new Bitmap(pictureBox1.Image);
            }

            chart1.Series["Kırmızı"].Points.Clear();
            chart1.Series["Yeşil"].Points.Clear();
            chart1.Series["Mavi"].Points.Clear();
            chart1.Series["K+Y+M"].Points.Clear();
            sizes = false;
            aynalandiMi = 0;
            u = 12;

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {
                Bitmap temp = (Bitmap)pictureBox1.Image;
                Bitmap bmap = temp;
                Color c;
                for (int i = 0; i < bmap.Width; i++)
                {
                    for (int j = 0; j < bmap.Height; j++)
                    {
                        c = bmap.GetPixel(i, j);
                        bmap.SetPixel(i, j,
          Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                    }
                }
                pictureBox1.Image = bmap;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {
                Bitmap temp = (Bitmap)pictureBox1.Image;

                Color c;
                for (int i = 0; i < temp.Width; i++)
                {
                    for (int j = 0; j < temp.Height; j++)
                    {
                        c = temp.GetPixel(i, j);


                        byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                        temp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                }
                pictureBox1.Image = temp;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {
                solaDondur();
                u--;

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {
                sagaDondur();
                u++;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {
                aynala();
                aynalandiMi++;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            reOpen();
            u = 12;
            aynalandiMi = 0;
        }
        private void button10_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {

                fotoKaydet();

            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            for(int w=0;w<u%4;w++)
            {
                sagaDondurtmp();
            }
            if (aynalandiMi % 2 == 1)
            {
                aynalaTmp();
            }
            if(sizes==true)
            {
                reSizetmp();

            }

            Bitmap bmp = new Bitmap(tmp);
            

            int width = bmp.Width;
            int height = bmp.Height;
            red = 1;
            green = 0;
            blue = 0;
            Bitmap rbmp = new Bitmap(bmp);
            Bitmap gbmp = new Bitmap(bmp);
            Bitmap bbmp = new Bitmap(bmp);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p = bmp.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    
                    rbmp.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));
                }
            }

            pictureBox1.Image = rbmp;
            u = 12;
            aynalandiMi = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            for (int w = 0; w < u%4; w++)
            {
                sagaDondurtmp();
            }
            if(aynalandiMi%2==1)
            {
                aynalaTmp();
            }
            if (sizes == true)
            {
                reSizetmp();

            }
            Bitmap bmp = new Bitmap(tmp);
            green = 1;
            blue = 0;
            red = 0;
            int width = bmp.Width;
            int height = bmp.Height;

            Bitmap rbmp = new Bitmap(bmp);
            Bitmap gbmp = new Bitmap(bmp);
            Bitmap bbmp = new Bitmap(bmp);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p = bmp.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    
                        gbmp.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));
                    
                }
            }

            pictureBox1.Image = gbmp;
            u = 12;
            aynalandiMi = 0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            for (int w = 0; w < u%4; w++)
            {
                sagaDondurtmp();
            }
            if (aynalandiMi % 2 == 1)
            {
                aynalaTmp();
            }
            if (sizes == true)
            {
                reSizetmp();

            }
            Bitmap bmp = new Bitmap(tmp);
            blue = 1;
            red = 0;
            green = 0;
            int width = bmp.Width;
            int height = bmp.Height;

            Bitmap rbmp = new Bitmap(bmp);
            Bitmap gbmp = new Bitmap(bmp);
            Bitmap bbmp = new Bitmap(bmp);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p = bmp.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    bbmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));
                }
            }

            pictureBox1.Image = bbmp;
            u=12;
            aynalandiMi = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Fotoğraf Yükleyin.");
            }
            else
            {
                chart1.Series["Kırmızı"].Points.Clear();
                chart1.Series["Yeşil"].Points.Clear();
                chart1.Series["Mavi"].Points.Clear();
                chart1.Series["K+Y+M"].Points.Clear();
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                int[] histogram_r = new int[256];
                float max = 0;
                int[] histogram_b = new int[256];
                int[] histogram_g = new int[256];
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        int redValue = bmp.GetPixel(i, j).R;
                        histogram_r[redValue]++;
                        if (max < histogram_r[redValue])
                            max = histogram_r[redValue];

                        int greenValue = bmp.GetPixel(i, j).G;
                        histogram_g[greenValue]++;
                        if (max < histogram_g[greenValue])
                            max = histogram_g[greenValue];


                        int blueValue = bmp.GetPixel(i, j).B;
                        histogram_b[blueValue]++;
                        if (max < histogram_b[blueValue])
                            max = histogram_b[blueValue];
                    }
                }

                for (int i = 0; i < histogram_r.Length; i++)
                {
                    
                    chart1.Series["Yeşil"].Points.Add(histogram_g[i]);
                    chart1.Series["Mavi"].Points.Add(histogram_b[i]);
                    chart1.Series["Kırmızı"].Points.Add(histogram_r[i]);
                }

            }

        }
        private void button11_Click(object sender, EventArgs e)
        {
            reSize();
            sizes = true;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int x;
            x = trackBar1.Value;

            Image yeni = pictureBox1.Image;
            Bitmap bmp = new Bitmap(yeni);
            Bitmap yenibmp = new Bitmap(bmp, (bmp.Height * x) / 15, (bmp.Width * x) / 15);
            pictureBox1.Image = yenibmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            chart1.Series["Kırmızı"].Points.Clear();
            chart1.Series["Yeşil"].Points.Clear();
            chart1.Series["Mavi"].Points.Clear();
            chart1.Series["K+Y+M"].Points.Clear();
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int[] histogram_r = new int[256];
            float max = 0;
            int[] histogram_b = new int[256];
            int[] histogram_g = new int[256];
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = bmp.GetPixel(i, j).R;
                    histogram_r[redValue]++;
                    if (max < histogram_r[redValue])
                        max = histogram_r[redValue];

                    int greenValue = bmp.GetPixel(i, j).G;
                    histogram_g[greenValue]++;
                    if (max < histogram_g[greenValue])
                        max = histogram_g[greenValue];


                    int blueValue = bmp.GetPixel(i, j).B;
                    histogram_b[blueValue]++;
                    if (max < histogram_b[blueValue])
                        max = histogram_b[blueValue];
                }
            }
            for (int i = 0; i < histogram_r.Length; i++)
            {

                chart1.Series["K+Y+M"].Points.Add(histogram_r[i] + histogram_g[i] + histogram_b[i]);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string gunAdi = DateTime.Now.DayOfWeek.ToString();
            string gun = DateTime.Now.Day.ToString();
            string saat = DateTime.Now.Minute.ToString();
            string saniye = DateTime.Now.Second.ToString();
            this.chart1.SaveImage(@"C:\Users\Umut\Documents\pshopex\" + gunAdi + gun + saat + saniye + "histogram" + ".jpg", ImageFormat.Jpeg);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            webCamCapture1.Start(0);
            

        }

        private void button15_Click(object sender, EventArgs e)
        {
            webCamCapture1.Stop();
            
        }

        private void webCamCapture1_ImageCaptured_1(object source, WebcamEventArgs e)
        {
            pictureBox1.Image = e.WebCamImage;
            tmp = new Bitmap(pictureBox1.Image);

            
        }
    }
    }
   


    
