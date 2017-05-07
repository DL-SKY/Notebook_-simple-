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
	public partial class Form3 : Form
	{
		public int iListIndex = 0;

		public Form3()
		{
			InitializeComponent();
		}
		//-----------------------------------------------------
		private void Form2_Load(object sender, EventArgs e)
		{
			Text = "Редактирование записи";

			btnExit.Text = "Выход";
			btnAdd.Text = "Сохранить";

			textBox1.Text = Program.form1.notebook.listNotes[iListIndex].Surname;
			textBox2.Text = Program.form1.notebook.listNotes[iListIndex].Name;
			textBox3.Text = Program.form1.notebook.listNotes[iListIndex].Patronymic;
			monthCalendar1.SelectionStart = new DateTime(Program.form1.notebook.listNotes[iListIndex].BirthdayYear,
														 Program.form1.notebook.listNotes[iListIndex].BirthdayMonth,
														 Program.form1.notebook.listNotes[iListIndex].BirthdayDay);
			monthCalendar1.SelectionEnd = monthCalendar1.SelectionStart;
			monthCalendar1.SetDate(new DateTime(Program.form1.notebook.listNotes[iListIndex].BirthdayYear,
														 Program.form1.notebook.listNotes[iListIndex].BirthdayMonth,
														 Program.form1.notebook.listNotes[iListIndex].BirthdayDay));
			monthCalendar1.ShowTodayCircle = false;
			textBox5.Text = Program.form1.notebook.listNotes[iListIndex].Telephone;
			textBox6.Text = Program.form1.notebook.listNotes[iListIndex].Email;
			textBox7.Text = Program.form1.notebook.listNotes[iListIndex].Description;	
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

			Program.form1.notebook.listNotes[iListIndex] = note;
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
