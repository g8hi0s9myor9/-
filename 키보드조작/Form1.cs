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
			MessageBox.Show("키보드가 눌러졌습니다.");
		}
	}
}
