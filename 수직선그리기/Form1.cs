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

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			for (int x = 0; x < 100; x++)
			{
				e.Graphics.DrawLine(
					Pens.Black,
					x*2,
					y,
					x*2,
					y + 50
				);
			}
			y++;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Invalidate();
		}
	}
}