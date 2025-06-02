using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker_DataLayer;
using System.Data;

namespace Tracker_BusinessLogic
{
    public class clsPerson
    {
        public enum enMode { AddMode , UpdateMode }
        private enMode _Mode { get; set; } = enMode.AddMode;

        /// <summary>
        /// Person ID for this person
        /// </summary>
        public int PersonID { get; set; }
        /// <summary>
        /// first name for this person
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// last name for this person
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// email address
        /// </summary>
        public string Email { get; set; }
        // phone number
        public string PhoneNumber { get; set; }

        public string NationalNo { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        private clsPerson(int PersonID,string NationalNo ,string FirstName, string LastName, string Email, string PhoneNumber)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            _Mode = enMode.UpdateMode;
        }

        public clsPerson()
        {
            PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.PhoneNumber = "";
            this.NationalNo = "";
            _Mode = enMode.AddMode;
        }
        
        private async Task<bool> _AddNewPerson()
        {
            int? PersonID =  await clsPersonData.AddNewPerson(NationalNo, FirstName, LastName, Email, PhoneNumber);
            if (PersonID != null)
            {
                this.PersonID = PersonID.Value;
                return true;
            }
            else return false;
        }

        private async Task<bool> _UpdatePerson()
        {
            return await clsPersonData.UpdatePerson(PersonID, NationalNo, FirstName, LastName, Email, PhoneNumber);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddMode:
                    if (await _AddNewPerson())
                    {
                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    return false;
                case enMode.UpdateMode:
                    return await _UpdatePerson();
                default:
                    return false;
            }
        }

        public static async Task<DataTable> GetAllPeople()
        {
            return await clsPersonData.GetAllPeople();
        }
        public static async Task<List<clsPerson>> GetListOfPerson()
        {
            List<clsPerson> People = new List<clsPerson>();

            try
            {
                DataTable dtPeople = await clsPersonData.GetAllPeople();
                foreach (DataRow Person in dtPeople.Rows)
                {
                    int PersonID = (int)Person["PersonID"];
                    string NationalNo = "";
                    if (Person["NationalNo"] != null)
                         NationalNo = (string)Person["NationalNo"];


                    string fullName = Person["FullName"].ToString();
                    string[] names = fullName.Split(' ');

                    string FirstName = names[0];
                    string LastName = names[1];


                    string Email = (string)Person["Email"];
                    string Phone = (string)Person["Phone"];
                    clsPerson PersonInfo = new clsPerson(PersonID, NationalNo, FirstName, LastName, Email, Phone);
                    People.Add(PersonInfo);
                }
            }
            catch (Exception e) 
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            
            return  People;
        }

        public static async Task<clsPerson> FindPersonByID(int PersonID)
        {
            DataTable result = await clsPersonData.FindPersonByPersonID(PersonID);

            if (result != null && result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                string NationalNo = "";

                string FirstName = row["FirstName"].ToString();
                string LastName = row["LastName"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNumber = row["Phone"].ToString();

                if (row["NationalNo"] != DBNull.Value)
                    NationalNo = row["NationalNo"].ToString();

                clsPerson Person = new clsPerson(PersonID, NationalNo, FirstName, LastName, Email, PhoneNumber);
                return Person;
            }
            else return null;

        }

        public static async Task<clsPerson> FindPersonByNationalNo(string NationalNo)
        {
            DataTable result = await clsPersonData.FindPersonByNationalNo(NationalNo);

            if (result != null && result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];

                int PersonID = (int)row["PersonID"];
                string FirstName = row["FirstName"].ToString();
                string LastName = row["LastName"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNumber = row["Phone"].ToString();

                clsPerson Person = new clsPerson(PersonID, NationalNo, FirstName, LastName, Email, PhoneNumber);
                return Person;
            }
            else return null;
        }

        public static async Task<bool> IsExist(string NationalNo)
        {
            return await clsPersonData.IsExist(NationalNo);
        }

        public static async Task<bool> DeletePerson(int PersonID)
        {
            return await clsPersonData.DeletePerson(PersonID);
        }
    }
}
