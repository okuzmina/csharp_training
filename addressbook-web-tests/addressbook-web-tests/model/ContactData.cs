using System;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Collections.Generic;
using System;
using LinqToDB.Mapping;
using System.Linq;


namespace WebAddressbookTest
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string middleName = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string homePhone = "";
        private string mobilePhone = "";
        private string workPhone = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private DateTime birthday;
        private DateTime anniversary;
        private string secondaryAddress = "";
        private string home = "";
        private string notes = "";
        private string allPhones;
        private string allEmails;
        private string allDetails;
        private string homePhoneRow;
        private string mobilePhoneRow;
        private string workPhoneRow;
        private string emailRow;
        private string email2Row;
        private string email3Row;
        private string allEmailsRows;
        private string phoneRows;

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (LastName == other.LastName)
            {
                if (FirstName == other.FirstName)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "first name = " + FirstName + "\nlast name = " + LastName + "\naddress = " + Address;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName == other.LastName)
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return LastName.CompareTo(other.LastName);
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string row)
        {
            if (row == null || row == "")
            {
                return "";
            }
            return Regex.Replace(row, "[ -()]", "") + "\r\n";
        }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public int BDay { get; set; }

        [Column(Name = "bmonth")]
        public string BMonth { get; set; }

        [Column(Name = "byear")]
        public string BYear { get; set; }

        [Column(Name = "aday")]
        public int ADay { get; set; }

        [Column(Name = "amonth")]
        public string AMonth { get; set; }

        [Column(Name = "ayear")]
        public string AYear { get; set; }

        [Column(Name = "address2")]
        public string SecondaryAddress { get; set; }

        [Column(Name = "phone2")]
        public string Home { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    string firstRow = FirstName + " " + LastName + "\r\n";
                    string secondRow = Address + "\r\n";

                    if (String.IsNullOrEmpty(HomePhone))
                    {
                        homePhoneRow = "";
                    }
                    else
                    {
                        homePhoneRow = "H: " + HomePhone + "\r\n";
                    }

                    if (String.IsNullOrEmpty(MobilePhone))
                    {
                        mobilePhoneRow = "";
                    }
                    else
                    {
                        mobilePhoneRow = "M: " + MobilePhone + "\r\n";
                    }

                    if (String.IsNullOrEmpty(WorkPhone))
                    {
                        workPhoneRow = "";
                    }
                    else
                    {
                        workPhoneRow = "W: " + WorkPhone + "\r\n";
                    }

                    phoneRows = homePhoneRow + mobilePhoneRow + workPhoneRow;

                    if (Email != "")
                    {
                        emailRow = Email + "\r\n";
                    }
                    else
                    {
                        emailRow = "";
                    }

                    if (Email2 != "")
                    {
                        email2Row = Email2 + "\r\n";
                    }
                    else
                    {
                        email2Row = "";
                    }

                    if (Email3 != "")
                    {
                        email3Row = Email3 + "\r\n";
                    }
                    else
                    {
                        email3Row = "";
                    }
                    allEmailsRows = emailRow + email2Row + email3Row;

                    string emptyRow = "\r\n";

                    return allDetails = firstRow + secondRow + emptyRow + phoneRows + emptyRow + allEmailsRows;
                }
            }
            set
            {
                allDetails = value;
            }
        }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
