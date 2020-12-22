using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USR_Vectors
{
    public partial class Form1 : Form
    {
        public double _aX, _aY, _aL, _bX, _bY, _bL, _cX, _cY, _cL;
        public int _fullH, _fullW, _x0, _y0, _dtab = 25;

        private void clear_button_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            _fullH = pictureBox1.Height;
            _fullW = pictureBox1.Width;
            Brush Pen = new SolidBrush(Color.White);
            g.FillRectangle(Pen, 0, 0, _fullW, _fullH);
            _x0 = 0;
            _y0 = 0;
            pbALabel.Visible = false; pbALabel.BackColor = Color.White;
            pbBLabel.Visible = false; pbBLabel.BackColor = Color.White;
            pbCLabel.Visible = false; pbCLabel.BackColor = Color.White;
        }

        public void Calculate()
        {
            if (radioButtonPlus.Checked == true)
            {
                _cX = _aX + _bX;
                _cY = _aY + _bY;
            }
            if (radioButtonMinus.Checked == true)
            {
                _cX = _aX - _bX;
                _cY = _aY - _bY;
            }
            _aL = Math.Sqrt(_aX * _aX + _aY * _aY);
            _bL = Math.Sqrt(_bX * _bX + _bY * _bY);
            _cL = Math.Sqrt(_cX * _cX + _cY * _cY);
        }

        private void calc_button_Click(object sender, EventArgs e)
        {
            DrawAxis();
            DrawTable();
            Input();
            Calculate();
            Output();
            DrawVector();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void DrawAxis()
        {
            Graphics g = pictureBox1.CreateGraphics();
            _fullH = pictureBox1.Height;
            _fullW = pictureBox1.Width;

            g.DrawLine(new Pen(Brushes.Black, 2), new Point(0, _fullH / 2), new Point(_fullW, _fullH / 2));
            g.DrawLine(new Pen(Brushes.Black, 2), new Point(_fullW / 2, 0), new Point(_fullW / 2, _fullH));
        }
        public void DrawTable()
        {
            Graphics g = pictureBox1.CreateGraphics();
            _fullH = pictureBox1.Height;
            _fullW = pictureBox1.Width;
            while (_x0 <= _fullW)
            {
                g.DrawLine(new Pen(Brushes.Black, 0.5f), new Point(_x0, 0), new Point(_x0, _fullH));
                _x0 += _dtab;
            }
            while (_y0 <= _fullH)
            {
                g.DrawLine(new Pen(Brushes.Black, 0.5f), new Point(0, _y0), new Point(_fullW, _y0));
                _y0 += _dtab;
            }
        }
        public void Input()
        {
            try
            {
                _aX = Convert.ToDouble(textBox1.Text);
                _aY = Convert.ToDouble(textBox2.Text);
                _bX = Convert.ToDouble(textBox4.Text);
                _bY = Convert.ToDouble(textBox5.Text);
            }
            catch
            {

            }

        }
        public void Output()
        {
            textBox3.Text = Convert.ToString(Math.Round(_aL, 2));
            textBox6.Text = Convert.ToString(Math.Round(_bL, 2));
            textBox9.Text = Convert.ToString(Math.Round(_cL, 2));
            textBox7.Text = Convert.ToString(_cX);
            textBox8.Text = Convert.ToString(_cY);
        }                                       
        public void DrawVector()
        {
            Graphics g = pictureBox1.CreateGraphics();
            _fullH = pictureBox1.Height;
            _fullW = pictureBox1.Width;
            Point center, a, b, c;
            center = new Point(_fullW / 2, _fullH / 2);
            a = new Point(_fullW / 2 + Convert.ToInt32(Math.Round(_aX)),
                _fullH / 2 + Convert.ToInt32(Math.Round(-_aY)));
            b = new Point(_fullW / 2 + Convert.ToInt32(Math.Round(_bX)),
                _fullH / 2 + Convert.ToInt32(Math.Round(-_bY)));
            g.DrawLine(new Pen(Brushes.Blue, 2), center, a);
            pbALabel.Location = new Point(_fullW / 2 + 10 + Convert.ToInt32(Math.Round(_aX)),
                _fullH / 2 + 10 + Convert.ToInt32(Math.Round(-_aY))); pbALabel.Visible = true;
            g.DrawLine(new Pen(Brushes.Blue, 2), center, b);
            pbBLabel.Location = new Point(_fullW / 2 + 10 + Convert.ToInt32(Math.Round(_bX)),
                _fullH / 2 + 10 + Convert.ToInt32(Math.Round(-_bY))); pbBLabel.Visible = true;
            if (radioButtonPlus.Checked == true)
            {
                c = new Point(_fullW / 2 + Convert.ToInt32(Math.Round(_cX)),
                _fullH / 2 + Convert.ToInt32(Math.Round(-_cY)));
                g.DrawLine(new Pen(Brushes.Red, 2), center, c);
                pbCLabel.Location = new Point(_fullW / 2 + 10 + Convert.ToInt32(Math.Round(_cX)),
                _fullH / 2 + 10 + Convert.ToInt32(Math.Round(-_cY))); pbCLabel.Visible = true;
            }
            if (radioButtonMinus.Checked == true)
            {
                g.DrawLine(new Pen(Brushes.Red, 2), a, b);
                pbCLabel.Location = new Point(_fullW / 2 - 10 + Convert.ToInt32(Math.Round(_bX)),
                _fullH / 2 + 20 + Convert.ToInt32(Math.Round(-_bY))); pbCLabel.Visible = true;
            }
        }
    }
}