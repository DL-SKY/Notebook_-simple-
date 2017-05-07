using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook
{
	public class Note
	{
		#region Объявление Переменных
		//ФИО
		string strSurname;
		string strName;
		string strPatronymic;
		//Дата рождения
		int dateBirthdayDay;
		int dateBirthdayMonth;
		int dateBirthdayYear;
		//Телефон
		string strTelephone;
		//E-mail
		string strEmail;
		//Комментарий
		string strDescription;
		#endregion
		//-----------------------------------------------------
		#region Реализация Свойств
		//реализация свойств
		public string Surname
		{
			get { return strSurname;}
			set { strSurname = value;}
		}
		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}
		public string Patronymic
		{
			get { return strPatronymic; }
			set { strPatronymic = value; }
		}
		public int BirthdayDay
		{
			get { return dateBirthdayDay; }
			set { dateBirthdayDay = value; }
		}
		public int BirthdayMonth
		{
			get { return dateBirthdayMonth; }
			set { dateBirthdayMonth = value; }
		}
		public int BirthdayYear
		{
			get { return dateBirthdayYear; }
			set { dateBirthdayYear = value; }
		}
		public string Telephone
		{
			get { return strTelephone; }
			set { strTelephone = value; }
		}
		public string Email
		{
			get { return strEmail; }
			set { strEmail = value; }
		}
		public string Description
		{
			get { return strDescription; }
			set { strDescription = value; }
		}
		//-----------------------------------------------------
		#endregion

		//-----------------------------------------------------
		//-----------------------------------------------------
		#region Конструкторы
		//Конструктор
		public Note()
		{
			//ФИО
			strSurname = "";
			strName = "";
			strPatronymic = "";
			//Дата рождения
			dateBirthdayDay = 1;
			dateBirthdayMonth = 1;
			dateBirthdayYear = 1;
			//Телефон
			strTelephone = "";
			//E-mail
			strEmail = "";
			//Комментарий
			strDescription = "";
		}
		#endregion
		//-----------------------------------------------------
		//-----------------------------------------------------

		//-----------------------------------------------------
		public override bool Equals(object _obj)
		{
			if (_obj == null) return false;
			Note objAsPart = _obj as Note;
			if (objAsPart == null) return false;
			else return Equals(objAsPart);
		}
		//-----------------------------------------------------
		public bool Equals(Note _other)
		{
			if (_other == null) 
				return false;

			else if (
					this.Surname	!= _other.Surname &&
					this.Name		!= _other.Name &&
					this.Patronymic != _other.Patronymic &&
					this.BirthdayDay != _other.BirthdayDay &&
					this.BirthdayMonth != _other.BirthdayMonth &&
					this.BirthdayYear != _other.BirthdayYear &&
					this.Telephone != _other.Telephone &&
					this.Email != _other.Email
					)
				return false;

			else return true;
		}
		//-----------------------------------------------------
	}
}
