using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 수직선그리기
{
	public partial class Form1 : Form
	{
		int y;
		Bitmap _도화지;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_도화지 = new Bitmap(this.Width, this.Height);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.DrawImage(_도화지, 0, 0);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Graphics g = Graphics.FromImage(_도화지);
			g.Clear(Color.White);

			for (int x = 0; x < 100; x++)
			{
				g.DrawLine(
					Pens.Black,
					x * 2,
					y,
					x * 2,
					y + 50
				);
			}
			y++;

			Invalidate();
		}
	}
}