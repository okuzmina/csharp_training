using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTest
{
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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

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

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

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

        public string Homepage { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime Anniversary { get; set; }

        public string SecondaryAddress { get; set; }

        public string Home { get; set; }

        public string Notes { get; set; }

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

                    if (String.IsNullOrEmpty(homePhone))
                    {
                        homePhoneRow = "";
                    }
                    else
                    {
                        homePhoneRow = "H: " + homePhone + "\r\n";
                    }

                    if (String.IsNullOrEmpty(mobilePhone))
                    {
                        mobilePhoneRow = "";
                    }
                    else
                    {
                        mobilePhoneRow = "M: " + mobilePhone + "\r\n";
                    }

                    if (String.IsNullOrEmpty(workPhone))
                    {
                        workPhoneRow = "";
                    }
                    else
                    {
                        workPhoneRow = "W: " + homePhone + "\r\n";
                    }

                    phoneRows = homePhoneRow + mobilePhoneRow + workPhoneRow;

                    if (email != "")
                    {
                        emailRow = email + "\r\n";
                    }
                    else
                    {
                        emailRow = "";
                    }

                    if (email2 != "")
                    {
                        email2Row = email2 + "\r\n";
                    }
                    else
                    {
                        email2Row = "";
                    }

                    if (email3 != "")
                    {
                        email3Row = email3 + "\r\n";
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
    }
}
