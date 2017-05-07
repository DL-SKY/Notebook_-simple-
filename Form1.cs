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
	public partial class Form1 : Form
	{
		public NoteBook notebook = new NoteBook();

		//-----------------------------------------------------
		public Form1()
		{
			InitializeComponent();
		}
		//-----------------------------------------------------
		private void Form1_Load(object sender, EventArgs e)
		{
			Text = "Записная книжка";

			btnExit.Text = "Выход";
			btnAdd.Text = "Добавить";
			btnDelete.Text = "Удалить";
			btnEdit.Text = "Редактировать";

			dataGridView1.Columns[0].HeaderText = "Фамилия";
			dataGridView1.Columns[1].HeaderText = "Имя";
			dataGridView1.Columns[2].HeaderText = "Отчество";
			dataGridView1.Columns[3].HeaderText = "Дата рождения";
			dataGridView1.Columns[4].HeaderText = "Телефон";
			dataGridView1.Columns[5].HeaderText = "E-mail";
			dataGridView1.Columns[6].HeaderText = "Описание";

			label2.Text = "";
			label2.Text = notebook.listNotes.Count.ToString();

			notebook.LoadDataBase();

			UpdateDB();
		}
		//-----------------------------------------------------
		private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
		{
			notebook.SaveDataBase();
		}	
		//-----------------------------------------------------
		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		//-----------------------------------------------------
		public void UpdateDB()
		{
			notebook.Sort();

			dataGridView1.ClearSelection();
			dataGridView1.RowCount = notebook.listNotes.Count();

			for (int i = 0; i < notebook.listNotes.Count(); i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = notebook.listNotes[i].Surname;
				dataGridView1.Rows[i].Cells[1].Value = notebook.listNotes[i].Name;
				dataGridView1.Rows[i].Cells[2].Value = notebook.listNotes[i].Patronymic;
				dataGridView1.Rows[i].Cells[3].Value = new DateTime(notebook.listNotes[i].BirthdayYear,
																	notebook.listNotes[i].BirthdayMonth,
																	notebook.listNotes[i].BirthdayDay).ToShortDateString();
				dataGridView1.Rows[i].Cells[4].Value = notebook.listNotes[i].Telephone;
				dataGridView1.Rows[i].Cells[5].Value = notebook.listNotes[i].Email;
				dataGridView1.Rows[i].Cells[6].Value = notebook.listNotes[i].Description;
				dataGridView1.Rows[i].Cells[7].Value = i;
			}

			label2.Text = "Всего: " + notebook.listNotes.Count().ToString();
		}
		//-----------------------------------------------------
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.RowCount < 1)
				return;

			label2.Text = "Всего: " + notebook.listNotes.Count().ToString();
		}
		//-----------------------------------------------------
		private void btnAdd_Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.ShowDialog();
		}
		//-----------------------------------------------------
		private void btnPicAdd_Click(object sender, EventArgs e)
		{
			btnAdd_Click(sender, e);
		}
		//-----------------------------------------------------
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dataGridView1.RowCount <= 0)
				return;

			if (dataGridView1.CurrentRow.Index >= 0)
			{ 
				int i = dataGridView1.CurrentRow.Index;

				notebook.Delete((int)dataGridView1.Rows[i].Cells[7].Value);

				UpdateDB();
			}			
		}
		//-----------------------------------------------------
		private void btnPicDelete_Click(object sender, EventArgs e)
		{
			btnDelete_Click(sender, e);
		}
		//-----------------------------------------------------
		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (dataGridView1.RowCount <= 0)
				return;

			if (dataGridView1.CurrentRow.Index >= 0)
			{
				int i = dataGridView1.CurrentRow.Index;

				Form3 form3 = new Form3();
				form3.iListIndex = (int)dataGridView1.Rows[i].Cells[7].Value;
				form3.ShowDialog();
			}
		}
		//-----------------------------------------------------
		private void btnPicEdit_Click(object sender, EventArgs e)
		{
			btnEdit_Click(sender, e);
		}	
		//-----------------------------------------------------
	}
}
