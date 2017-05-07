using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace NoteBook
{
	public class NoteBook
	{
		#region Объявление Переменных
		//Список записей
		public List<Note> listNotes;
		//Путь к файлу (по умолчанию notes.dat)
		string strPath;
		#endregion
		//-----------------------------------------------------
		#region Реализация Свойств

		#endregion

		//-----------------------------------------------------
		//-----------------------------------------------------
		#region Конструкторы
		public NoteBook()
		{
			listNotes = new List<Note>();
			strPath = "notes.dat";
		}
		//-----------------------------------------------------
		public NoteBook(string _path)
		{
			listNotes = new List<Note>();
			strPath = _path;

			if (strPath == "")
				strPath = "notes.dat";
		}
		#endregion
		//-----------------------------------------------------
		//-----------------------------------------------------

		//-----------------------------------------------------
		//Загрузить данные Записной книжки
		public void LoadDataBase()
		{
			LoadDataBase(strPath);
		}
		//-----------------------------------------------------
		//Загрузить из указанного файла данные Записной книжки
		public void LoadDataBase(string _path)
		{
			strPath = _path;

			listNotes.Clear();

			if (!File.Exists(strPath))
			{
				File.Create(strPath);
			}

			using (BinaryReader binReader = new BinaryReader(File.Open(strPath, FileMode.Open)))
			{
				while (binReader.PeekChar() > -1)
				{
					listNotes.Add(new Note());

					listNotes[listNotes.Count - 1].Surname = binReader.ReadString();
					listNotes[listNotes.Count - 1].Name = binReader.ReadString();
					listNotes[listNotes.Count - 1].Patronymic = binReader.ReadString();
					listNotes[listNotes.Count - 1].BirthdayDay = binReader.ReadInt32();
					listNotes[listNotes.Count - 1].BirthdayMonth = binReader.ReadInt32();
					listNotes[listNotes.Count - 1].BirthdayYear = binReader.ReadInt32();
					listNotes[listNotes.Count - 1].Telephone = binReader.ReadString();
					listNotes[listNotes.Count - 1].Email = binReader.ReadString();
					listNotes[listNotes.Count - 1].Description = binReader.ReadString();
				}
			}
		}
		//-----------------------------------------------------
		//Сохранить данные записной книжки
		public void SaveDataBase()
		{
			SaveDataBase(strPath);
		}
		//-----------------------------------------------------
		//Сохранить в указанный файл данные записной книжки
		public void SaveDataBase(string _path)
		{
			strPath = _path;

			using (BinaryWriter binWriter = new BinaryWriter(File.Open(strPath, FileMode.Create)))
			{
				for (int i = 0; i < listNotes.Count(); i++)
				{
					binWriter.Write(listNotes[i].Surname.ToString());
					binWriter.Write(listNotes[i].Name.ToString());
					binWriter.Write(listNotes[i].Patronymic.ToString());
					binWriter.Write(listNotes[i].BirthdayDay);
					binWriter.Write(listNotes[i].BirthdayMonth);
					binWriter.Write(listNotes[i].BirthdayYear);
					binWriter.Write(listNotes[i].Telephone.ToString());
					binWriter.Write(listNotes[i].Email.ToString());
					binWriter.Write(listNotes[i].Description.ToString());
				}
			}
		}
		//-----------------------------------------------------
		//Добавление элемента
		public void Add(Note _note)
		{
			listNotes.Add(_note);
			Sort();
		}
		//-----------------------------------------------------
		//Удаление элемента
		public void Delete(Note _note)
		{
			listNotes.Remove(_note);
		}
		//-----------------------------------------------------
		//Удаление элемента
		public void Delete(int _index)
		{
			if (_index >= listNotes.Count)
				return;

			listNotes.RemoveAt(_index);
		}
		//-----------------------------------------------------
		public void Sort()
		{ 
			if (listNotes.Count <= 0)
				return;

			for (int j = listNotes.Count - 1; j > 0; j--)
				for (int i = 0; i < j; i++ )
				{
					if (listNotes[i].Surname.CompareTo(listNotes[i + 1].Surname) > 0)
					{
						Note noteTMP;
						noteTMP = listNotes[i];
						listNotes[i] = listNotes[i + 1];
						listNotes[i + 1] = noteTMP;
					}
				}
		}
		//-----------------------------------------------------
	}
}