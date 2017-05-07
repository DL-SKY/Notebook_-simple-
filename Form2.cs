using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteBook
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		//-----------------------------------------------------
		private void Form2_Load(object sender, EventArgs e)
		{
			Text = "Добавление записи";

			btnExit.Text = "Выход";
			btnAdd.Text = "Добавить";			
		}
		//-----------------------------------------------------
		private void btnAdd_Click(object sender, EventArgs e)
		{
			Note note = new Note();
			note.Surname = textBox1.Text;
			note.Name = textBox2.Text;
			note.Patronymic = textBox3.Text;
			note.BirthdayDay = monthCalendar1.SelectionStart.Day;
			note.BirthdayMonth = monthCalendar1.SelectionStart.Month;
			note.BirthdayYear = monthCalendar1.SelectionStart.Year;
			note.Telephone = textBox5.Text;
			note.Email = textBox6.Text;
			note.Description = textBox7.Text;			

			Program.form1.notebook.Add(note);
			//Program.form1.notebook.Sort();
			Program.form1.UpdateDB();

			Close();
		}
		//-----------------------------------------------------
		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}
		//-----------------------------------------------------
	}
}
