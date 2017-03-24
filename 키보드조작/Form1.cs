using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 키보드조작
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Left)
			{
				textBox1.Left--;
			}
			if(e.KeyCode == Keys.Right)
			{
				textBox1.Left++;
			}
			if(e.KeyCode == Keys.Up)
			{
				textBox1.Top--;
			}
			if(e.KeyCode == Keys.Down)
			{
				textBox1.Top++;
			}
		}
	}
}
